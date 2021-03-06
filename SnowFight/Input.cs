﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowFight
{
    public class Input : IInput
    {
        public KeyboardState ActualState { get; set; }
        public KeyboardState LastState { get; set; }

        public void Update(GameTime gameTime)
        {
            LastState = ActualState;
            ActualState = Keyboard.GetState();
        }

        public bool Press(Keys key)
        {
            return ActualState.IsKeyDown(key);
        }

        public bool Pressed(Keys key)
        {
            return LastState.IsKeyUp(key) && ActualState.IsKeyDown(key);
        }

        public bool Released(Keys key)
        {
            return LastState.IsKeyDown(key) && ActualState.IsKeyUp(key);
        }
    }
}
