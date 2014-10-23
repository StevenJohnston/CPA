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
    public class AstroidList : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private List<Asteroid> asteroids;
        private Random r = new Random();

        public AstroidList(Game game, 
            SpriteBatch spriteBatch,
            Texture2D tex,
            Rectangle screen,
            int numOfAsteroids)
            : base(game)
        {
            asteroids = new List<Asteroid>();

            for (int i = 0; i  < numOfAsteroids; i ++)
            {
                asteroids.Add(new Asteroid(game, spriteBatch, tex, RandomPosition(screen), RandomSpeed(), screen));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Vector2 RandomSpeed()
        {
            int tmp = r.Next(1, 2);

            if (tmp == 1)
            {
                return new Vector2(r.Next(1, 3), r.Next(1, 3));
            }
            else
            {
                return new Vector2(r.Next(-3, -1), r.Next(-3, -1));
            }

            //return new Vector2(r.Next(1, 3) * PLUS_OR_MINUS[r.Next(0, 2)], r.Next(1, 3) * PLUS_OR_MINUS[r.Next(0, 2)]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        private Vector2 RandomPosition(Rectangle screen)
        {
            return new Vector2(r.Next(screen.X, screen.Width), r.Next(screen.Y, screen.Height));
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
            foreach (var asteroid in asteroids)
            {
                asteroid.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the component to draw itself.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
