namespace Hack
{
    public partial class HackForm : Form
    {
#nullable disable
        private const string NAME_GAME_WINDOW = "Left 4 Dead 2 - Direct3D 9";
        private OverlayWindow window;
#nullable enable

        public HackForm()
        {
            InitializeComponent();
        }

        private void HackForm_Load(object sender, EventArgs e)
        {
            window = new(NAME_GAME_WINDOW, new FPS(), new BorderWindow(), new TestSpeedRender());
            window.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            window.Update();
        }
    }
}