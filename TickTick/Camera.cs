using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class Camera : GameObject
{
    private int worldWidth;
    private int worldHeight;

    public Camera(Viewport viewport)
    {
        localPosition = new Vector2();
    }

    public Vector2 Pos
    {
        get { return localPosition; }
        set
        {

            worldWidth = Level.numberOfCols * 72;
            worldHeight = Level.numberOfRows * 55;

            float leftBarrier = 0;
            float rightBarrier = worldWidth;
            float topBarrier = 0;
            float bottomBarrier = worldHeight;
            localPosition = value;
            localPosition.X = Math.Clamp(localPosition.X, leftBarrier, rightBarrier);
            localPosition.Y = Math.Clamp(localPosition.Y, topBarrier, bottomBarrier);

        }
    }

    public Matrix GetTransformation()
    {
        Matrix transform = Matrix.CreateTranslation(new Vector3(-localPosition.X, -localPosition.Y, 0));

        return transform * TickTick.spriteScale;
    }

    public new Matrix Reset()
    {
        Matrix reset = TickTick.spriteScale;

        return reset;
    }
}

