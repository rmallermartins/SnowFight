using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public interface IAnimation
    {
        bool Flip { get; set; }
        Vector2 Origin { get; set; }
        Color DrawColor { get; set; }
        Vector2 Position { get; set; }

        void LoadContent(ContentManager content);
        void Draw(SpriteBatch spriteBatch);
    }
}
