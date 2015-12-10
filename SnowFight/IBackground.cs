using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public interface IBackground
    {
        Texture2D Texture { get; set; }
        ISprite Sprite { get; set; }

        void LoadContent(ContentManager content);
        void Draw(SpriteBatch spriteBatch);
    }
}
