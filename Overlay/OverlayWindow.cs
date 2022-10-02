using Overlay.Forms;

namespace Overlay
{
    public class OverlayWindow : IDisposable
    {
        public WindowInformation WindowInformation => windowInformation;
        public List<IGraphics> GraphicsCollection => graphicsCollection;

        private readonly FormOverlay overlay;
        private readonly List<IGraphics> graphicsCollection;
        private readonly WindowInformation windowInformation;

        public OverlayWindow(string nameWindow, params IGraphics[] graphics)
        {
            this.windowInformation = new(nameWindow);
            this.graphicsCollection = new();

            if (graphics is not null) graphicsCollection.AddRange(graphics);

            overlay = new(GraphicsCollection, WindowInformation);
        }

        public void Show()
        {
            overlay.Show();
        }

        public void Update()
        {
            overlay.UpdateGraphics();
        }

        public void Dispose()
        {
            overlay.Close();
        }
    }
}
