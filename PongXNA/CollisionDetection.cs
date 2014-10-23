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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class CollisionDetection : Microsoft.Xna.Framework.GameComponent
    {
        Ball ball;
        Paddle paddle;
        Rectangle ballRect;
        Rectangle paddleRect;
        SoundEffect paddleHit;
        int ballDirection;
        const int NINE = 9;
        const int ELEVEN = 11;
        const int TWENTYONE = 21;
        const int BALL_Y_VELOCITY_CHANGE = 5;
        public CollisionDetection(Game game,Ball ball,Paddle paddle,int ballDirection)
            : base(game)
        {
            paddleHit = game.Content.Load<SoundEffect>("click");
            this.ballDirection = ballDirection;
            this.ball = ball;
            this.paddle = paddle;
            // TODO: Construct any child components here
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
            // TODO: Add your update code here
            ballRect = ball.getBounds();
            paddleRect = paddle.getBounds();
            if (ballRect.Intersects(paddleRect))
            {
                if (paddle.isLeftPlayer)
                {
                    if (Math.Abs((ball.pos.X - NINE) - (paddle.pos.X + paddle.tex.Width)) < Math.Abs(ball.velocity.X))
                    {
                        ball.velocity.X = Math.Abs(ball.velocity.X) * ballDirection;
                        ball.velocity.Y += ((ball.pos.Y + ball.tex.Height / 2) - ((paddle.pos.Y - TWENTYONE) + paddle.tex.Height / 2)) / BALL_Y_VELOCITY_CHANGE;
                        paddleHit.Play();
                    }
                }
                else
                {
                    if (Math.Abs((ball.pos.X + ball.tex.Width) - (paddle.pos.X+ELEVEN)) < Math.Abs(ball.velocity.X))
                    {
                        ball.velocity.X = Math.Abs(ball.velocity.X) * ballDirection;
                        ball.velocity.Y += ((ball.pos.Y + ball.tex.Height / 2) - ((paddle.pos.Y - TWENTYONE) + paddle.tex.Height / 2)) / BALL_Y_VELOCITY_CHANGE;
                        paddleHit.Play();
                    }
                }
            }
            base.Update(gameTime);
        }
    }
}
