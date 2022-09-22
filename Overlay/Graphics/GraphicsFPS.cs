namespace Overlay.Graphics
{
    public class GraphicsFPS : IGraphics
    {
        readonly Font font;
        readonly Brush brush;
        readonly PointF pointF;
        readonly FPS fps;
        public GraphicsFPS()
        {
            font = new("Arial", 16);
            brush = Brushes.Gold;
            pointF = new PointF(10, 10);
            fps = new();
        }


        public void Render(PaintEventArgs e)
        {
            fps.Update();
            e.Graphics.DrawString(fps.ToString(), font, brush, pointF);
        }
    }

    public class FPS
    {
        static readonly TimeSpan FpsUpdate = TimeSpan.FromSeconds(1);

        Stopwatch sw;
        int fpsCount;
        double fps;
        public double Fps => fps;

        public FPS()
        {
            sw = Stopwatch.StartNew();
        }

        public void Update()
        {
            var fpsTimerMs = sw.Elapsed;
            if (fpsTimerMs > FpsUpdate)
            {
                fps = fpsCount / fpsTimerMs.TotalSeconds;
                sw.Restart();
                fpsCount = 0;
            }

            fpsCount++;
        }

        public override string ToString()
        {
            return $"FPS: {fps}";
        }
    }
}
