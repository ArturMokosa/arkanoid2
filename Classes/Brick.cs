using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace arkanoid.Classes
{
    class Brick : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D pixel;

        public bool active { get; set; }

        int width;
        int height;
        int posX;
        int posY;

        public Brick(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int width, int height, int posX,
            int posY) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.height = height;
            this.width = width;
            this.posX = posX;
            this.posY = posY;
            
            active = true;
            
            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] {Color.White});
        }

        public bool CheckBalColision(Ball ball)
        {
            if (active && ball.PosX >= posX && ball.PosX <= posX + width && ball.PosY <= posY + height &&
                ball.PosY >= posY)
            {
                ball.DirY = -ball.DirY;
                return true;
            }
            
            return false;
        }


        public override void Draw(GameTime gameTime)
        {
            
            if (active)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(pixel, new Rectangle(posX, posY, width, height), Color.White);
                spriteBatch.End();
            }
            

            //base.Draw(gameTime);
        }
    }
}
