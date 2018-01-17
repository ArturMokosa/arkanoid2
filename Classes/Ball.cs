using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace arkanoid.Classes
{
    class Ball : DrawableGameComponent
    {
        public bool run { get; set; }

        public int size;

        public int DirX { get; set; }
        public int DirY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        int speed = 1;

        SpriteBatch spriteBatch;
        Texture2D pixel;
        GraphicsDevice graphics;
        Random rnd = new Random();

        public Ball(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int size) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.size = size;
            
            run = false;
            
            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[]{Color.White});
            
            ResetBallPosition();
            ResetBallDirection();
        }

        public void ResetBallPosition()
        {
            PosX = graphics.Viewport.Width / 2 - size / 2;
            PosY = graphics.Viewport.Height - graphics.Viewport.Height / 3;
        }

        public void ResetBallDirection()
        {
            do
            {
                DirX = rnd.Next(-5, 5);

            } while (DirX == 0);

            do
            {
                DirY = rnd.Next(-5, 5);

            } while (DirY == 0);

        }

        public override void Update(GameTime gameTime)
        {
            if (run)
            {
                CheckWallColision();
                PosX += DirX * speed;
                PosY += DirY * speed;
            }

            
            base.Update(gameTime);
        }

        public void CheckWallColision()
        {
            if(PosX <= graphics.Viewport.X || PosX + size >= graphics.Viewport.Width)
            {
                DirX *= -1;

            }

            if(PosY <= 0)
            {
                DirY *= -1;
            }

            if (PosY >= graphics.Viewport.Height - 10)
            {
                run = false;
                ResetBallDirection();
                ResetBallPosition();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(PosX, PosY, size, size), Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }



    }
}
