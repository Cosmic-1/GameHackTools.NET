namespace Overlay.Graphics
{
    public class GraphicsBorderWindow : IGraphics
    {
        private readonly Pen pen;

        public GraphicsBorderWindow()
        {
            pen = new(Color.GreenYellow)
            {
                Width = 2
            };
        }
        public void Render(PaintEventArgs e)
        {
            var rectagle = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            e.Graphics.DrawRectangle(pen, rectagle);
        }
    }
}
