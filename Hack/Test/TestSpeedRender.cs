namespace Hack.Test
{
    public class TestSpeedRender : IGraphics
    {
        private readonly Random random;
        private readonly Pen enemy;
        private readonly Pen team;
        public TestSpeedRender()
        {
            random = new Random();
            enemy = new Pen(Color.Red);
            team = new Pen(Color.Green);
        }

        public void Render(PaintEventArgs e)
        {
            var listEnemys = new List<Rectangle>();
            var listTeam = new List<Rectangle>();
            int height, width, x, y;
            Rectangle rectagle;

            for (int i = 0; i < 32; i++)
            {
                if (e.ClipRectangle.Width != 0 || e.ClipRectangle.Height != 0)
                {
                    try
                    {
                        width = random.Next(20, 70);
                        height = random.Next(30, 100);

                        x = random.Next(width, e.ClipRectangle.Width - width);
                        y = random.Next(height, e.ClipRectangle.Height - height);

                        rectagle = new Rectangle(x, y, width, height);

                        listEnemys.Add(rectagle);

                        width = random.Next(20, 70);
                        height = random.Next(30, 100);

                        x = random.Next(width, e.ClipRectangle.Width - width);
                        y = random.Next(height, e.ClipRectangle.Height - height);

                        rectagle = new Rectangle(x, y, width, height);
                        listTeam.Add(rectagle);
                    }
                    catch { }

                }
            }

            if (listEnemys.Any())
            {
                e.Graphics.DrawRectangles(enemy, listEnemys.ToArray());
            }
            if (listTeam.Any())
            {
                e.Graphics.DrawRectangles(team, listTeam.ToArray());
            }
        }
    }
}
