using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowFight
{
    public class Player
    {
        private SnowBall snowBall;
        private float freezeTime;
        private Rectangle collisionMask;
        private float slide;

        public Texture2D Texture { get; set; }
        public IAnimation Animation { get; set; }
        public ISprite Sprite { get; set; }
        public IInput Input { get; set; }
        public float MovSpeed { get; set; } = 1;
        public Keys LeftMovKey { get; set; }
        public Keys RightMovKey { get; set; }
        public Keys ThrowSnowballKey { get; set; }
        public int ThrowDir { get; set; }
        public Rectangle CollisionMask { get { return collisionMask; } }
        public SnowBall SnowBall { get { return snowBall; } }

        public Player()
        {
            Animation = new Animation();
            Sprite = new Sprite();
            Input = new Input();
            snowBall = new SnowBall();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("run_cycle");
            Animation.CurrRect = new Rectangle(Animation.CurrIndex * 128, 0, 128, 128);

            snowBall = new SnowBall();
            snowBall.LoadContent(content);

            collisionMask = new Rectangle((int)Sprite.Position.X - 64,
                (int)Sprite.Position.Y - Texture.Height / 2, 60, Texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            collisionMask.X = (int)Sprite.Position.X - 64 / 2;
            collisionMask.Y = (int)Sprite.Position.Y - Texture.Height / 2;

            Input.Update(gameTime);
            handleMovementInput(gameTime);
            handleThrowInput();
            snowBall.Update(gameTime);

            if (slide > 0 && Sprite.Position.X + slide + Sprite.Origin.X < 1280)
            {
                Sprite.Position += new Vector2(slide, 0);
                slide = Math.Max(slide - 5 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            if (slide < 0 && Sprite.Position.X - slide - Sprite.Origin.X > 0)
            {
                Sprite.Position += new Vector2(slide, 0);
                slide = Math.Min(slide + 5 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            if (freezeTime > 0)
            {
                MovSpeed = 150;
                freezeTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void handleThrowInput()
        {
            if (Input.Pressed(ThrowSnowballKey) && !snowBall.IsActive)
            {
                throwBall();
            }
        }

        private void throwBall()
        {
            snowBall.ThrowForce = 1000 * ThrowDir;
            snowBall.Sprite.Position = new Vector2(Sprite.Position.X, Sprite.Position.Y - 70);
            snowBall.Gravity = 12;
            snowBall.Throw();
        }

        private void handleMovementInput(GameTime gameTime)
        {
            var movement = MovSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Input.Press(LeftMovKey))
            {
                slide = 0;
                moveLeft(movement);
            }
            else if (Input.Press(RightMovKey))
            {
                slide = 0;
                moveRight(movement);
            }
            else if (Input.Released(LeftMovKey))
            {
                slide = -movement;
            }
            else if (Input.Released(RightMovKey))
            {
                slide = movement;
            }
        }

        private void moveLeft(float movement)
        {
            if (Sprite.Position.X - movement - Sprite.Origin.X > 0)
                Sprite.Position -= new Vector2(movement, 0);
        }

        private void moveRight(float movement)
        {
            if (Sprite.Position.X + movement + Sprite.Origin.X < 1280)
                Sprite.Position += new Vector2(movement, 0);
        }

        public bool Hits(Player enemy)
        {
            return snowBall.CollisionMask.Intersects(enemy.CollisionMask);
        }

        public void Freeze()
        {
            freezeTime = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (freezeTime > 0)
            {
                spriteBatch.Draw(Texture, Sprite.Position, Animation.CurrRect,
                    Sprite.FreezedDrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale,
                    Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }
            else
            { 
                spriteBatch.Draw(Texture, Sprite.Position, Animation.CurrRect, 
                    Sprite.DrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale, 
                    Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

            snowBall.Draw(spriteBatch);
        }
    }
}
