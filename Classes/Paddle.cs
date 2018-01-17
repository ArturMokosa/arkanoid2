using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace arkanoid.Classes
{
    class Paddle : DrawableGameComponent
    {
        int height;
        int width;
        
        
        public int PosX { get; set; }
        public int PosY { get; set; }
        
        
        SpriteBatch spriteBatch;
        Texture2D pixel;
        GraphicsDevice graphics;
        

        public Paddle(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int width, int height) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.width = width;
            this.height = height;
            
            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[]{Color.White});
            

            ResetPaddlePosition();
           
        }

     
        
        public void ResetPaddlePosition()
        {
            PosX = graphics.Viewport.Width - width / 222;
            PosY = graphics.Viewport.Height - 20;
        }

        public void CheckPaddleBallCollison(Ball ball)
        {
            int third = width / 3;

            if(ball.PosY + ball.size >= PosY && ball.PosX >= PosX && ball.PosX + ball.size <= PosX + width)
            {
                ball.DirY = -ball.DirY;
//                ball.DirX = -ball.DirX;
            }
            

        }

  
        

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(PosX, PosY, width, height), Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
