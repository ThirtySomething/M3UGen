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
                /// UI for generating m3u playlists
                /// </summary>
                public partial class objMainForm : Form
                {
                    private M3UGen objM3UGen = null;
                    private MP3List objMP3List = null;

                    public objMainForm()
                    {
                        InitializeComponent();
                        this.objM3UGen = new M3UGen();
                        this.objMP3List = new MP3List();
                    }
                }
            }
        }
    }
}
