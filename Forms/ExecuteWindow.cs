using System;
using System.Data;
using System.Data.Odbc;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SQLParamParser.Config;
using SQLParamParser.PluginInfrastructure;

namespace SQLParamParser.Forms
{
    public partial class ExecuteWindow : Form
    {
        private readonly Settings _settings;
        private int _maxRows;

        private static readonly IScintillaGateway Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

        private static string GetCurrentText()
        {
            return Editor.GetText(Editor.GetLength() + 1);
        }

        public ExecuteWindow(Settings settings)
        {
            InitializeComponent();
            _settings = settings;

            PageSizeEdit_ValueChanged(null, null);

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               DataGridView,
               new object[] { true });
        }

        private void SetButtonsState()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
               {
                   ExecuteButton.Enabled = !_isExecuting;
                   TerminateButton.Enabled = _isExecuting;
               });
            }
            else
            {
                ExecuteButton.Enabled = !_isExecuting;
                TerminateButton.Enabled = _isExecuting;
            }
        }

        private Thread _executingThread;
        private bool _isExecuting;
        private bool _exetionStopRequest;

        private void TerminateButton_Click(object sender, EventArgs e)
        {
            if (!_isExecuting)
            {
                return;
            }

            _exetionStopRequest = true;

            _executingThread.Join();

            SetButtonsState();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            if (_isExecuting)
            {
                return;
            }

            _isExecuting = true;
            DataGridView.DataSource = null;

            SetButtonsState();

            _executingThread = new Thread(() =>
            {
                try
                {
                    var result = new DataTable("Result");

                    using (var connection = new OdbcConnection(_settings.ConnectionString))
                    {
                        connection.Open();

                        var query = GetCurrentText();

                        var command = new OdbcCommand(query, connection);
                        var adapter = new OdbcDataAdapter(command)
                        {
                            MissingMappingAction = MissingMappingAction.Passthrough,
                            MissingSchemaAction = MissingSchemaAction.AddWithKey
                        };

                        for (var rowIndex = 0; rowIndex < _maxRows; rowIndex++)
                        {
                            var addedRows = adapter.Fill(rowIndex, 1, result);

                            if (_exetionStopRequest)
                            {
                                return;
                            }

                            if (addedRows < 1)
                            {
                                break;
                            }
                        }
                    }

                    Invoke((MethodInvoker)(() =>
                    {
                        DataGridView.DataSource = result;
                    }));
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    MessageBox.Show(new WindowWrapper(PluginBase.nppData._nppHandle), ex.Message, Main.PluginName, MessageBoxButtons.OK);
                }
                finally
                {
                    _isExecuting = false;

                    if (_exetionStopRequest)
                    {
                        _exetionStopRequest = false;
                    }
                    else
                    {
                        SetButtonsState();
                    }
                }
            });

            _executingThread.IsBackground = true;
            _executingThread.Start();
            _exetionStopRequest = false;
        }

        private void PageSizeEdit_ValueChanged(object sender, EventArgs e)
        {
            _maxRows = (int)MaxRowsEdit.Value;
        }
    }
}
