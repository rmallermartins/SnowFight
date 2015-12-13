using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public class SnowSystem
    {
        private SnowFlake[] particles;
        private Random randomNumber;
        
        public SnowSystem()
        {
            particles = new SnowFlake[50];
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i] = new SnowFlake();
            }
            randomNumber = new Random();
        }

        public void LoadContent(ContentManager content)
        {
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].LoadContent(content);
                particles[i].Sprite.Position = new Vector2(randomNumber.Next(0, 1380), randomNumber.Next(-720, 100));
                particles[i].Sprite.Scale = (float)randomNumber.NextDouble() * 0.5f;
                particles[i].Gravity = randomNumber.Next(50, 100);
                particles[i].RotationSpeed = (float)(randomNumber.NextDouble() - 0.5) * 0.05f;
            }
        }

        public void Update(GameTime gameTime)
        {
            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].Sprite.Position += new Vector2(-0.3f, 
                    (float)(particles[i].Gravity * gameTime.ElapsedGameTime.TotalSeconds));
                particles[i].Sprite.Rotation += particles[i].RotationSpeed;

                if (particles[i].Sprite.Position.Y > 800)
                {
                    particles[i].Sprite.Position = new Vector2(randomNumber.Next(0, 1280), randomNumber.Next(-720, 100));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(SnowFlake sf in particles)
            {
                sf.Draw(spriteBatch);
            }
        }
    }
}
