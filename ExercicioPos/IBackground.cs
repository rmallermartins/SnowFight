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
        void LoadContent(ContentManager content);
        void Draw(SpriteBatch spriteBatch);
    }
}
