using System;
using System.Windows.Forms;

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                /// <summary>
                /// Start of GUI application
                /// </summary>
                internal sealed class Program
                {
                    /// <summary>
                    /// Program entry point.
                    /// </summary>
                    [STAThread]
                    private static void Main(string[] args)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new objMainForm());
                    }
                }
            }
        }
    }
}
