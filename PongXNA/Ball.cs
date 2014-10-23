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
    public class Ball : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteFont myFont;
        public Texture2D tex;
        SpriteBatch spriteBatch;
        public Vector2 pos;
        public Vector2 origin;
        public Vector2 velocity;
        float rotation;
        Score leftPlayer;
        Score rightPlayer;
        Vector2 screen;
        bool newGame=true;
        bool gamePaused = true;
        Random r = new Random();
        string winningString ="";
        Game game;
        const int maxScore = 3;
        int[] change = new int[2]{ -1, 1 };
        const int MAX_Y_VELOCITY = 9;
        const int BALL_X_VELOCITY_INCREASE_INTERVAL = 120;
        bool playerOneHacks = false;
        int time;
        Vector2 whereBall;
        Game1 mainGame;
        Song winSound;
        SoundEffect pointSound;

        /// <summary>
        /// constructor for that ball class used to set dimensions of the ball 
        /// and add defualts to variables 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="screen"></param>
        public Ball(Game game,SpriteBatch spriteBatch,Vector2 screen)
            : base(game)
        {
            winSound = game.Content.Load<Song>("chimes");
            pointSound = game.Content.Load<SoundEffect>("ding");
            this.mainGame = (Game1)game;
            this.game = game;
            myFont = game.Content.Load<SpriteFont>("myfont");
            this.pos = screen / 2;
            this.screen = screen;
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("white-ball-md");
            origin = new Vector2(tex.Width/2,tex.Height/2);
            rotation = 0f;
            resetScores();
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
        /// Used to update the balls postion using the velocity
        /// adds speed to the ball at given interval
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            whereBall = new Vector2(-50, -200);
            if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt) && Keyboard.GetState().IsKeyDown(Keys.D1))
                playerOneHacks = true;
            time++;
            if (time > BALL_X_VELOCITY_INCREASE_INTERVAL)
            {
                velocity.X += (int)Math.Ceiling(velocity.X / int.MaxValue);
                time = 0;
            }
            if (velocity.Y > MAX_Y_VELOCITY) velocity.Y = MAX_Y_VELOCITY;
            if (!gamePaused)
            {
                Vector2 tempV = velocity;
                Vector2 tempPos = pos;
                
                if (velocity.X < 0 && playerOneHacks)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Math.Abs((tempPos.X - 9) - (26 + 12)) < Math.Abs(tempV.X)+1)
                        {
                            break;
                        }
                        else
                        {
                            if (tempPos.Y + tempV.Y -tex.Height/2 < 0 || tempPos.Y+tempV.Y+tex.Height/2 > screen.Y)
                            {
                                tempV.Y *= -1;
                            }
                            tempPos += tempV;

                        }

                    }

                    whereBall = tempPos;
                }
            }

            KeyboardState ks = Keyboard.GetState();
            if (!newGame&&ks.IsKeyDown(Keys.Space))
            {
                newGame = true;
                gamePaused = true;
                winningString = "";
                mainGame.resetPaddle();

            }
            else if (ks.IsKeyDown(Keys.Enter) && gamePaused)
            {
                time = 0;
                gamePaused = false;
                velocity = new Vector2(r.Next( 3,9) * change[r.Next(0, 2)], r.Next(3, 9) * change[r.Next(0, 2)]);
            }
            
            rotation = (float)Math.Atan2(velocity.Y,velocity.X);
            if (pos.Y +velocity.Y-tex.Height/2 < 0 || pos.Y + velocity.Y+tex.Height/2 > screen.Y)
                velocity.Y *= -1;

            pos += velocity;
            if (pos.X < -tex.Width / 2)
            {
                pos = screen / 2;
                velocity = Vector2.Zero;
                if (rightPlayer.score + 1 == maxScore)
                {
                    MediaPlayer.Play(winSound);
                    winningString = "Sabir(" + (rightPlayer.score + 1) + ") has won. Steven(" + leftPlayer.score + ") has Lost.\n      Press Space to play Again.";
                    gamePaused = false;
                    newGame = false;
                    resetScores();
                }
                else
                {
                    pointSound.Play();
                    rightPlayer.score++;
                    gamePaused = true;
                }
            }
            else if (pos.X > screen.X + tex.Width/2)
            {
                pos = screen / 2;
                if (leftPlayer.score + 1 == maxScore)
                {
                    MediaPlayer.Play(winSound);
                    winningString = "Steven(" + (leftPlayer.score + 1) + ") has won. Sabir(" + rightPlayer.score + ") has Lost.\n      Press Space to play Again.";
                    gamePaused = false;
                    newGame = false;
                    resetScores();

                }
                else
                {
                    pointSound.Play();
                    leftPlayer.score++;
                    gamePaused = true;
                }
                velocity = Vector2.Zero;
            }
            // TODO: Add your update code here
            base.Update(gameTime);
        }
        /// <summary>
        /// draws the ball and the cheat ball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (winningString == "")
            {
                leftPlayer.drawScore(gameTime, spriteBatch);
                rightPlayer.drawScore(gameTime, spriteBatch);
                rightPlayer.drawLine(gameTime, spriteBatch);
                spriteBatch.Draw(tex, pos, new Rectangle(0, 0, tex.Width, tex.Height), Color.Tomato, 0f, origin, 1f, SpriteEffects.None, 1f);

                spriteBatch.Draw(tex, new Vector2(49,whereBall.Y), new Rectangle(0, 0, tex.Width, tex.Height), Color.Green, 0f, origin, new Vector2(1,1), SpriteEffects.None, 1f);
                
            }
            else
                spriteBatch.DrawString(myFont, winningString, new Vector2(200, 200), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// gets rectangle for the ball at current position
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)(pos.X-10),(int)(pos.Y),tex.Width,tex.Height);
        }
        /// <summary>
        /// resets the left and right players score
        /// </summary>
        public void resetScores()
        {
            try
            {
                game.Components.Remove(leftPlayer);
                game.Components.Remove(rightPlayer);
            }
            catch (Exception) { }
            leftPlayer = new Score(game, spriteBatch, new Vector2(300, 20));
            rightPlayer = new Score(game, spriteBatch, new Vector2(425, 20));
            game.Components.Add(leftPlayer);
            game.Components.Add(rightPlayer);
        }
    }
}
