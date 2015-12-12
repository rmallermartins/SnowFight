using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowFight
{
    public interface IInput
    {
        KeyboardState LastState { get; set; }
        KeyboardState ActualState { get; set; }

        void Update(GameTime gameTime);
        bool Press(Keys key);
        bool Pressed(Keys key);
    }
}
