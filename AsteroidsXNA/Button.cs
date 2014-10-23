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
    public class Button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private SpriteFont font;
        private string text;
        private Rectangle rectangle;
        private Color defaultColor;
        private Color color;

        public bool isClicked;


        public Button(Game game, SpriteBatch spriteBatch, Vector2 pos, string text, SpriteFont font, Color color) 
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.position = pos;
            this.text = text;
            this.font = font;
            this.color = color;
            this.defaultColor = color;
            rectangle = new Rectangle((int)pos.X,(int)pos.Y,(int)font.MeasureString(text).X,(int)font.MeasureString(text).Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            isClicked = false;

            MouseState ms = Mouse.GetState();
            if (rectangle.Contains(ms.X, ms.Y))
            {
                this.color = Color.Yellow;

                if (ms.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }
            else
            {
                this.color = defaultColor;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, text, position, color);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
