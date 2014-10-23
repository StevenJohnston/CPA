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
    /// paddle class used to draw paddles and hold paddle information
    /// </summary>
    public class Paddle : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        public Texture2D tex;
        public Vector2 pos;
        Vector2 screen;
        public Vector2 origin;
        Rectangle rect;
        Keys keyUp;
        Keys keyDown;
        const int speed = 5;
        Ball ball;
        int ballRedirect;
        public bool isLeftPlayer = false;
        const int PADDLESPACE = 20;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="tex">used to set texture</param>
        /// <param name="leftPlayer">bool to check if left player</param>
        /// <param name="screen">screen dimensions</param>
        /// <param name="up">key to move this paddle up</param>
        /// <param name="down">key to move this paddle down</param>
        /// <param name="ball">the ball </param>
        public Paddle(Game game,SpriteBatch spriteBatch, Texture2D tex,bool leftPlayer,Vector2 screen,Keys up,Keys down,Ball ball)
            : base(game)
        {
            this.screen = screen;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.ball = ball;
            ballRedirect = leftPlayer ? 1 : -1;
            isLeftPlayer = leftPlayer;
            pos.X = leftPlayer ? (tex.Width/2) + PADDLESPACE : screen.X - (tex.Width/2) - PADDLESPACE;
            pos.Y = screen.Y / 2;
            origin = new Vector2(tex.Width/2,tex.Height/2);
            this.keyUp = up;
            this.keyDown = down;
            rect = new Rectangle(0, 0, (int)(tex.Width), (int)(tex.Height));
            CollisionDetection cD = new CollisionDetection(game, ball, this,ballRedirect);
            game.Components.Add(cD);
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
        /// moves paddle and makes sure paddle stays on screen
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(keyUp))
                pos.Y-=speed;
            if (ks.IsKeyDown(keyDown))
                pos.Y += speed;
            
            if (pos.Y < 0+rect.Height/2)
                pos.Y = 0+rect.Height/2;
            if(pos.Y > screen.Y-(rect.Height/2))
                pos.Y = screen.Y-(rect.Height/2);

            base.Update(gameTime);
        }
        /// <summary>
        /// Draws paddles on screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, new Rectangle(0,0,tex.Width,tex.Height), Color.SaddleBrown, 0f, origin, 1f, SpriteEffects.None, 1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        ///returns the rectangle of for the paddle
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)pos.X,(int)pos.Y-20,tex.Width,tex.Height);
        }
    }
}
