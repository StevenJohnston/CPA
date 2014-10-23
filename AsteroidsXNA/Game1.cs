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
using AsteroidsXNA.Components;

namespace AsteroidsXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ship player;
        AstroidList asteroidList;
        MainMenu mainMenu;

        string gameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = "menu";
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
            Rectangle screen = new Rectangle(0, 10, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;

            Texture2D playerTex = Content.Load<Texture2D>("img/ship");
            player = new Ship(this, 
                spriteBatch, 
                playerTex, 
                new Vector2(graphics.PreferredBackBufferWidth / 2 - playerTex.Width / 2, graphics.PreferredBackBufferHeight / 2 - playerTex.Height / 2),
                new Vector2(1, -1),
                screen);

            Texture2D asteroidTex = Content.Load<Texture2D>("img/asteroid-small");
            asteroidList = new AstroidList(this, spriteBatch, asteroidTex, screen, 5);

            mainMenu = new MainMenu(this, spriteBatch, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));



            Components.Add(player);
            Components.Add(asteroidList);
            Components.Add(mainMenu);

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
            {
                gameState = "menu";
            }

            if (mainMenu.Buttons[0].isClicked)
            {
                gameState = "playing";
                for (int i = 0; i < mainMenu.Buttons.Length; i++)
                {
                    mainMenu.Buttons[i].isClicked = false;
                }
            }

            if (mainMenu.Buttons[1].isClicked)
            {
                gameState = "controls";
            }

            if (mainMenu.Buttons[3].isClicked)
            {
                gameState = "exit";
            }

            switch (gameState)
            {
                case "menu":
                    mainMenu.Enabled = true;
                    mainMenu.Visible = true;
                    player.Enabled = false;
                    player.Visible = false;
                    asteroidList.Enabled = false;
                    asteroidList.Visible = false;
                    break;

                case "playing":
                    mainMenu.Enabled = false;
                    mainMenu.Visible = false;
                    player.Enabled = true;
                    player.Visible = true;
                    asteroidList.Enabled = true;
                    asteroidList.Visible = true;
                    break;

                case "controls":

                    break;

                case "exit":
                    this.Exit();
                    break;

                default:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
