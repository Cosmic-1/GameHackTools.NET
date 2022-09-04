# OverlayWindow.NET

![alt text](https://github.com/Cosmic-1/OverlayWindow.NET/blob/master/Image/Img.jpg)

## Usage
Change the name of the game to NAME_GAME_WINDOW.

You need to implement this interface.
```C#
    public interface IGraphics
    {
        void Render(PaintEventArgs e);
    }
```

And add a class to this array.
```C#
readonly IGraphics[] paints = {
        new GraphicsBorderWindow(),
        new GraphicsFPS(),
       new GraphicsTestSpeedRender(),
        };
```
Render method example:

```C#
 public void Render(PaintEventArgs e)
{
  var renderStrFps = "FPS: ";
  var font = new Font("Arial", 30);
  var brush = Brushes.Gold;
  var pointF = new PointF(10, 10);
  e.Graphics.DrawString(renderStrFps, font, brush, pointF);
}
```
