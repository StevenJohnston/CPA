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
    /// Score class used to draw scores
    /// </summary>
    
    public class Score : Microsoft.Xna.Framework.DrawableGameComponent
    {
        const int THREE = 3;
        const int FIVE = 5;
        const int TEN = 10;
        const int THREEEIGHTYSEVEN = 387;
        const int FIFTYONE = 51;
        int[, ,] numberLayout =  new int[TEN,FIVE,THREE]
        {
            {
                {1,1,1},
                {1,0,1},
                {1,0,1},
                {1,0,1},
                {1,1,1}

            },
            {
                {0,0,1},
                {0,0,1},
                {0,0,1},
                {0,0,1},
                {0,0,1},
            },
            {
                {1,1,1},
                {0,0,1},
                {1,1,1},
                {1,0,0},
                {1,1,1},
            },
            {
                {1,1,1},
                {0,0,1},
                {1,1,1},
                {0,0,1},
                {1,1,1},
            },
            {
                {1,0,1},
                {1,0,1},
                {1,1,1},
                {0,0,1},
                {0,0,1},
            },
            {
                {1,1,1},
                {1,0,0},
                {1,1,1},
                {0,0,1},
                {1,1,1},
            },
            {
                {1,1,1},
                {1,0,0},
                {1,1,1},
                {1,0,1},
                {1,1,1},
            },
            {
                {1,1,1},
                {0,0,1},
                {0,0,1},
                {0,0,1},
                {0,0,1},
            },
            {
                {1,1,1},
                {1,0,1},
                {1,1,1},
                {1,0,1},
                {1,1,1},
            },
            {
                {1,1,1},
                {1,0,1},
                {1,1,1},
                {0,0,1},
                {0,0,1},
            },
        };
        public int score = 0;
        Vector2 pos;
        SpriteBatch spriteBatch;
        Texture2D whiteSquare;
        /// <summary>
        /// Constructor to see texture and position
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="pos"></param>
        public Score(Game game,SpriteBatch spriteBatch,Vector2 pos)
            : base(game)
        {
            whiteSquare = game.Content.Load<Texture2D>("square");
            this.spriteBatch = spriteBatch;
            this.pos = pos;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// Draws doted line in the middle of screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void drawLine(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < TEN; i++)
                spriteBatch.Draw(whiteSquare, new Rectangle(THREEEIGHTYSEVEN, i * FIFTYONE, whiteSquare.Width, whiteSquare.Height), Color.Brown);
            base.Draw(gameTime);
        }
        /// <summary>
        /// Draws score without the use of a sprite font
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void drawScore(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int x = 0; x < THREE; x++)
                for (int y = 0; y < FIVE; y++)
                    if (numberLayout[score, y, x] != 0)
                        spriteBatch.Draw(whiteSquare, new Rectangle(x * whiteSquare.Width + (int)pos.X, y * whiteSquare.Height + (int)pos.Y, whiteSquare.Width, whiteSquare.Height), Color.Chocolate);
        }
    }
}
