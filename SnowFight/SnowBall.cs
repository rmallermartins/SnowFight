using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public class SnowBall
    {
        private Vector2 movement;
        private Rectangle collisionMask;

        public Texture2D Texture { get; set; }
        public ISprite Sprite { get; set; }
        public float ThrowForce { get; set; }
        public float Gravity { get; set; }
        public bool IsActive { get; set; }
        public Rectangle CollisionMask { get { return collisionMask; } }

        public SnowBall()
        {
            Sprite = new Sprite();
            movement = new Vector2();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("snowball");

            collisionMask = new Rectangle((int)Sprite.Position.X - Texture.Width/2, 
                (int)Sprite.Position.Y - Texture.Height/2, Texture.Width, Texture.Height);
        }

        public void Throw()
        {
            IsActive = true;
            movement.X = ThrowForce / 2;
            movement.Y = - Math.Abs(ThrowForce) / 2;
        }

        public void Update(GameTime gameTime)
        {
            collisionMask.X = (int)Sprite.Position.X - Texture.Width / 2;
            collisionMask.Y = (int)Sprite.Position.Y - Texture.Height / 2;

            if (IsActive)
            {
                movement.Y += Gravity;
                Sprite.Position += movement * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Sprite.Position.Y >= 532)
                {
                    Inactivate();
                }
            }
        }

        public void Inactivate()
        {
            IsActive = false;
            Sprite.Position = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(Texture, Sprite.Position, null,
                    Sprite.DrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale,
                    Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }
        }
    }
}
