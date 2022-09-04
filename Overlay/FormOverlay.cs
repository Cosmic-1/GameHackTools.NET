namespace Overlay
{
    public partial class FormOverlay : Form
    {
        #region Graphics
        readonly IGraphics[] paints = {
        new GraphicsBorderWindow(),
        new GraphicsFPS(),
       new GraphicsTestSpeedRender(),
        };
        #endregion

        private const string NAME_GAME_WINDOW = "Left 4 Dead 2 - Direct3D 9";

        public FormOverlay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var paint in paints)
                paint.Render(e);

            base.OnPaint(e);
        }

        private void UpdateGraphics_Tick(object sender, EventArgs e)
        {
            this.HookWindowUpdate();
            this.Refresh();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            var result = this.SearchWindowGame(NAME_GAME_WINDOW);
            if (result is false) MessageBox.Show("");
            this.WindowTransparent();
        }
    }
}