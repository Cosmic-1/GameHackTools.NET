using Overlay.Data;

namespace Overlay
{
    public partial class FormOverlay : Form
    {
        private GraphicsCollection graphicsCollection;
        private WindowInformation windowInformation;

        public FormOverlay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //render all graphics
            this.graphicsCollection.RenderAll(e);

            base.OnPaint(e);
        }

        private void UpdateGraphics_Tick(object sender, EventArgs e)
        {
            //update the window
            this.HookWindowUpdate();
            //Refresh the window. If you want to change update, you need to change interval in the Timer. Current 16 ms.
            this.Refresh();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls?view=netframeworkdesktop-4.8
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.WindowTransparent();

            this.windowInformation = new("Left 4 Dead 2 - Direct3D 9");
            this.graphicsCollection = new(new IGraphics[] { new GraphicsBorderWindow(), new GraphicsFPS(), new GraphicsTestSpeedRender() });
            //Finds the game window  
            if (windowInformation.IsValid is false)
                MessageBox.Show("Game not found. Run the game.");
        }

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        private void HookWindowUpdate()
        {
            //update information the window
            windowInformation.UpdateWindow();

            if (windowInformation.ForegroundWindow)
            {
                var rect = windowInformation.WindowRectangleClient;
                this.Size = rect.Size;
                this.Top = rect.Top;
                this.Left = rect.Left;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = true;
            }
            else
            {
                this.Size = Size.Empty;
                this.Top = 0;
                this.Left = 0;

                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}