using System.Xml.Schema;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using arkanoid.Classes;
using System.Collections.Generic;

namespace arkanoid
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball ball;
        Paddle paddle;
        List<Brick> lstBricks;
        Texture2D pixel; 


        int ballSize = 6;
        int paddleWidth = 40;
        int paddleHeight = 10;
        int brickHeight = 20;
        int brickWidth = 50;
        int brickRows = 6;

        int gameWidth = 500;
        int gameHeight = 600;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = gameWidth;
            graphics.PreferredBackBufferHeight = gameHeight;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new Ball(this, GraphicsDevice, spriteBatch, ballSize);
            paddle = new Paddle(this, GraphicsDevice, spriteBatch, paddleWidth, paddleHeight);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            lstBricks = new List<Brick>();

            Components.Add(ball);
            Components.Add(paddle);
            CreateBricks();
        }

        public void CreateBricks()
        {
            for (int i = 0; i < gameWidth / brickWidth; i++)
            {
                for (int j = 1; j < brickRows + 1; j++)
                {
                    lstBricks.Add(new Brick(this, GraphicsDevice, spriteBatch, brickWidth, brickHeight, i * brickWidth + i,
                        j * brickHeight + j));
                }
            }

            foreach (var brick in lstBricks)
            {
                Components.Add(brick); 
            } 
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && !ball.run)
                ball.run = true;

            paddle.PosX = Mouse.GetState().X;

            paddle.CheckPaddleBallCollison(ball);


            foreach (var item in lstBricks)
            {
                if (item.CheckBalColision(ball))
                {
                    item.active = false;
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(51, 51, 51));
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(0,GraphicsDevice.Viewport.Height - 20,GraphicsDevice.Viewport.Width, 1), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}