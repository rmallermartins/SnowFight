using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public interface IPlayer
    {
        IAnimation Animation { get; set; }
        ISprite Sprite { get; set; }
        Texture2D Texture { get; set; }
        IInput Input { get; set; }
        float MovSpeed { get; set; }
        Keys LeftMovKey { get; set; }
        Keys RightMovKey { get; set; }

        void LoadContent(ContentManager content);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
