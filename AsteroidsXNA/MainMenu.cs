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


namespace AsteroidsXNA.Components
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MainMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Button[] buttons = new Button[4];

        public Button[] Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }

        public MainMenu(Game game, SpriteBatch spriteBatch, Vector2 screenDim)
            : base(game)
        {
            SpriteFont font = game.Content.Load<SpriteFont>("fonts/regular");

            buttons[0] = new Button(game, spriteBatch, new Vector2((float)(screenDim.X / 2), 200), "Start", font, Color.White);
            buttons[1] = new Button(game, spriteBatch, new Vector2((float)(screenDim.X / 2), 250), "Help", font, Color.White);
            buttons[2] = new Button(game, spriteBatch, new Vector2((float)(screenDim.X / 2), 300), "About", font, Color.White);
            buttons[3] = new Button(game, spriteBatch, new Vector2((float)(screenDim.X / 2), 350), "Exit", font, Color.White);

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (var item in buttons)
            {
                item.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var item in buttons)
            {
                item.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
