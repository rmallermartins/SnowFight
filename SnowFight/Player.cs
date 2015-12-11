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
    public class Player : IPlayer
    {
        public Texture2D Texture { get; set; }
        public IAnimation Animation { get; set; }
        public ISprite Sprite { get; set; }
        public IInput Input { get; set; }
        public float MovSpeed { get; set; } = 1;
        public Keys LeftMovKey { get; set; }
        public Keys RightMovKey { get; set; }

        public Player()
        {
            Animation = new Animation();
            Sprite = new Sprite();
            Input = new Input();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("run_cycle");

            Animation.CurrRect = new Rectangle(Animation.CurrIndex * 128, 0, 128, 128);
        }

        public void Update(GameTime gameTime)
        {
            Input.Update(gameTime);

            handleInput(gameTime);
        }

        private void handleInput(GameTime gameTime)
        {
            var movement = MovSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Input.Press(LeftMovKey))
            {
                moveLeft(movement);
            }
            else if (Input.Press(RightMovKey))
            {
                moveRight(movement);
            }
        }

        private void moveLeft(float movement)
        {
            if (!Sprite.Flip)
                Sprite.Flip = true;

            if (Sprite.Position.X - movement - Sprite.Origin.X > 0)
                Sprite.Position -= new Vector2(movement, 0);
        }

        private void moveRight(float movement)
        {
            if (Sprite.Flip)
                Sprite.Flip = false;

            if (Sprite.Position.X + movement + Sprite.Origin.X < 1280)
                Sprite.Position += new Vector2(movement, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Sprite.Position, Animation.CurrRect, 
                Sprite.DrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale, 
                Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
