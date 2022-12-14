namespace Hack.Test
{
    public class BorderWindow : IGraphics
    {
        private readonly Pen pen;

        public BorderWindow()
        {
            pen = new(Color.GreenYellow)
            {
                Width = 2
            };
        }
        public void Render(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rectagle = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            g.DrawRectangle(pen, rectagle);
        }
    }
}
