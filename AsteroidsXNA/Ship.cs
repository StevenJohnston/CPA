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
    public class Ship : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private const int MAX_VELOCITY = 5;
        private const int SPS = 5;
        private int shotTimer;

        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Rectangle screen;
        private Vector2 velocity;
        private Vector2 origin;

        private float rotationFactor;
        private float rotationChange;
        private Vector2 direction;

        private Random r = new Random();

        public List<Bullet> bullets = new List<Bullet>();
        private Game game;

        public Ship(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Rectangle screen)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.screen = screen;
            this.game = game;
            this.origin = new Vector2(this.tex.Width / 2, this.tex.Height / 2 + 10);

            this.direction = new Vector2(r.Next(1, 10), r.Next(-10, -1));
            this.rotationFactor = 0.0f;
            this.rotationChange = 0.1f;
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
            shotTimer++;
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.A))
            {
                rotationFactor -= rotationChange;
            }
            
            if (ks.IsKeyDown(Keys.D))
            {
                rotationFactor += rotationChange;
            }

            direction = new Vector2((float)Math.Sin(this.rotationFactor), 
                    (float)Math.Cos(this.rotationFactor));

            if (ks.IsKeyDown(Keys.W))
            {
                if ((velocity + direction * speed).Length() < MAX_VELOCITY && (velocity + direction).Length() > -MAX_VELOCITY)
                    velocity += direction*speed;
            }

            if(ks.IsKeyDown(Keys.Space))
            {
                if (shotTimer > 60 / SPS)
                {
                    bullets.Add(new Bullet(game, spriteBatch, position, direction, new Vector2(6, -6), screen, game.Content.Load<Texture2D>("img/bullet")));
                    shotTimer = 0;
                }
            }
            velocity *= 0.99f;

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!screen.Contains(new Rectangle((int)bullets[i].Position.X, (int)bullets[i].Position.Y, bullets[i].Texture.Width, bullets[i].Texture.Height)))
                {
                    bullets.RemoveAt(i);
                }
            }
            foreach (Bullet b in bullets)
            {
                b.Update(gameTime);
            }

            this.position += velocity;

            if (position.X + origin.X> screen.Width)
            {
                position.X = screen.X + origin.X + 1;
            }

            if (position.X + origin.X < screen.X)
            {
                position.X = screen.Width - origin.X -1;
            }

            if (position.Y + origin.Y > screen.Height)
            {
                position.Y = screen.Y + origin.Y + 1;
            }

            if (position.Y + origin.Y < screen.Y)
            {
                position.Y = screen.Height - origin.Y-1;
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            
            spriteBatch.Draw(this.tex, this.position, null, Color.White, this.rotationFactor, origin, 1f, SpriteEffects.None, 0f);

            spriteBatch.End();

            foreach (Bullet b in bullets)
            {
                if (b.Visible)
                {
                    b.Draw(gameTime);
                }
                b.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
