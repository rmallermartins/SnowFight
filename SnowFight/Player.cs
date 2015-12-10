using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SnowFight
{
    public class Player : IPlayer
    {
        public Texture2D Texture { get; set; }
        public IAnimation Animation { get; set; }
        public ISprite Sprite { get; set; }

        public Player()
        {
            Animation = new Animation();
            Sprite = new Sprite();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("run_cycle");

            Animation.CurrRect = new Rectangle(Animation.CurrIndex * 128, 0, 128, 128);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Sprite.Position, Animation.CurrRect, 
                Sprite.DrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale, 
                Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
