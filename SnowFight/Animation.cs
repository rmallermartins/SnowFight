using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public class Animation : IAnimation
    {
        private readonly string _textureName;
        private Texture2D _texture;
        private int _animIndex = 0;

        public bool Flip { get; set; } = false;
        public Vector2 Origin { get; set; } = new Vector2(0, 0);
        public Color DrawColor { get; set; } = Color.White;
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        public Animation(string textureName)
        {
            _textureName = textureName;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_textureName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var sourceRectangle = new Rectangle(_animIndex * 128, 0, 128, 128);

            spriteBatch.Draw(_texture, Position, sourceRectangle, DrawColor, 0, Origin,
                1, Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
