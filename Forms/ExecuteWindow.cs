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

        DataTable _sourceTable = new DataTable();

        private static readonly IScintillaGateway Editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

        private static string GetCurrentText()
        {
            return Editor.GetText(Editor.GetLength() + 1);
        }

        public ExecuteWindow(Settings settings)
        {
            InitializeComponent();
            _settings = settings;

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               DataGridView,
               new object[] { true });
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            ExecuteButton.Enabled = false;
            DataGridView.DataSource = null;

            var thread = new Thread(() =>
            {
                var connectionString = _settings.ConnectionString;

                using (var connection = new OdbcConnection(connectionString))
                {

                    try
                    {
                        connection.Open();

                        var query = GetCurrentText();

                        var command = new OdbcCommand(query, connection);
                        var adapter = new OdbcDataAdapter(command);

                        _sourceTable.Clear();
                        adapter.Fill(_sourceTable);

                        DataGridView.DataSource = _sourceTable;
                    }
                    catch (Exception ex)
                    {
                        ExecuteButton.Enabled = true;
                        MessageBox.Show(new WindowWrapper(PluginBase.nppData._nppHandle), ex.Message, Main.PluginName, MessageBoxButtons.OK);
                    }
                }

                ExecuteButton.Enabled = true;
            });

            thread.IsBackground = true;

            thread.Start();
        }
    }
}
