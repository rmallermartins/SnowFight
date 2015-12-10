using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public interface IPlayer
    {
        IAnimation Animation { get; set; }

        void LoadContent(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
