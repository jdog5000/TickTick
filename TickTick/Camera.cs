using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class Camera
{
    public Vector2 pos;
    private int worldWidth;
    private int worldHeight;

    public Camera(Viewport viewport)
    {
        pos = new Vector2();
    }

    public Vector2 Pos
    {
        get { return pos; }
        set
        {

            worldWidth = Level.numberOfCols * 72;
            worldHeight = Level.numberOfRows * 55;

            float leftBarrier = 0;
            float rightBarrier = worldWidth - TickTick.windowSize.X;
            float topBarrier = 0;
            float bottomBarrier = worldHeight - TickTick.windowSize.Y;
            pos = value;
            pos.X = Math.Clamp(pos.X, rightBarrier, leftBarrier);
            pos.Y = Math.Clamp(pos.Y, topBarrier, bottomBarrier);

        }
    }

    public Matrix GetTransformation()
    {
        Matrix transform = Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0));

        return transform * TickTick.spriteScale;
    }

    public Matrix Reset()
    {
        Matrix reset = TickTick.spriteScale;

        return reset;
    }
}

