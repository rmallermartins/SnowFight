using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public class SnowFlake
    {
        public Texture2D Texture { get; set; }
        public ISprite Sprite { get; set; }
        public float Gravity { get; set; } = 0;
        public float RotationSpeed { get; set; } = 0;

        public SnowFlake()
        {
            Sprite = new Sprite();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("snowFlake");
            Sprite.Origin = new Vector2(Texture.Width/2, Texture.Height/2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Sprite.Position, null,
                    Sprite.DrawColor, Sprite.Rotation, Sprite.Origin, Sprite.Scale,
                    Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
