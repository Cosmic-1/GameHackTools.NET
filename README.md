# GameHackTools.NET

![alt text](https://github.com/Cosmic-1/OverlayWindow.NET/blob/master/Image/Img.jpg)

## Usage
You need to implement this interface.
```C#
    public interface IGraphics
    {
        void Render(PaintEventArgs e);
    }
```

Add an element to this OverlayWindow class:
```C#
        OverlayWindow window = new("NAME GAME", => here <=);
```
Or add to the list:
```C#
        window.GraphicsCollection.Add(=> here <=);
```

Render method example:

```C#
  public void Render(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rectagle = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            g.DrawRectangle(pen, rectagle);
        }
```

## Problem
Full screen doesn't work.
I know this problem and will solve the problem soon.
Run the game in a window only or window without border. 
