using System;
using System.Windows.Forms;

namespace SQLParamParser.PluginInfrastructure
{
    public class WindowWrapper : IWin32Window
    {
        public IntPtr Handle { get; private set; }

        public WindowWrapper(IntPtr handle)
        {
            Handle = handle;
        }
    }
}