//Name: Steven Johnston
//Program: 2250
//Section: 1
//date: 11/26/2013
//Program Name Pong
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SJohnstonAssignment4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ballTex;
        Texture2D paddleTex;
        Vector2 screen;
        SpriteFont myfont;
        public Paddle playerLeft;
        public Paddle playerRight;
        /// <summary>
        /// Called to start game
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            graphics.ApplyChanges();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddleTex = Content.Load<Texture2D>("paddle");
            myfont = Content.Load<SpriteFont>("myfont");
            screen = new Vector2(graphics.PreferredBackBufferWidth , graphics.PreferredBackBufferHeight);
            Ball ball = new Ball(this,spriteBatch,screen);
            playerLeft = new Paddle(this, spriteBatch, paddleTex, true, screen,Keys.A,Keys.Z,ball);
            playerRight = new Paddle(this, spriteBatch, paddleTex, false, screen,Keys.Up,Keys.Down,ball);
            ball.DrawOrder = 4;
            playerLeft.DrawOrder = 1;
            playerRight.DrawOrder = 2;
            this.Components.Add(ball);
            this.Components.Add(playerLeft);
            this.Components.Add(playerRight);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// draws player one and players two's name
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);
            spriteBatch.Begin();
            spriteBatch.DrawString(myfont,"Steven",new Vector2(40,20),Color.SaddleBrown);
            spriteBatch.DrawString(myfont, "Sabir", new Vector2(screen.X - 100, 20), Color.SaddleBrown);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// used to reset paddle positions back to center of screen
        /// </summary>
        public void resetPaddle()
        {
            playerRight.pos.Y = screen.Y / 2;
            playerLeft.pos.Y = screen.Y / 2;
        }
    }
}
