using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SnowFight
{
    public class Background : IBackground
    {
        private readonly string _textureName;

        public Texture2D Texture { get; set; }
        public ISprite Sprite { get; set; }

        public Background(string textureName)
        {
            _textureName = textureName;
            Sprite = new Sprite();
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>(_textureName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Sprite.Position, null, Sprite.DrawColor, 
                Sprite.Rotation, Sprite.Origin, Sprite.Scale, 
                Sprite.Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
