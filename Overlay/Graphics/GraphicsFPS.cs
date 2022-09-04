namespace Overlay.Graphics
{
    public class GraphicsFPS : IGraphics
    {
        readonly Font font;
        readonly Brush brush;
        readonly PointF pointF;
        readonly Stopwatch sw;
        int fpsCount;
        string renderStrFps = "FPS:";
        public GraphicsFPS()
        {
            font = new("Arial", 30);
            brush = Brushes.Gold;
            pointF = new PointF(10, 10);
            sw = Stopwatch.StartNew();
        }
        private void Update()
        {
            if (sw.ElapsedMilliseconds <= 1000)
            {
                fpsCount++;
            }
            else
            {
                renderStrFps = $"FPS: {fpsCount}";
                fpsCount = 0;
                sw.Restart();
            }
        }

        public void Render(PaintEventArgs e)
        {
            Update();
            e.Graphics.DrawString(renderStrFps, font, brush, pointF);
        }
    }
}
