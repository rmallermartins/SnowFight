using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SnowFight
{
    public class Sprite : ISprite
    {
        public bool Flip { get; set; } = false;
        public Vector2 Origin { get; set; } = new Vector2(0, 0);
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color DrawColor { get; set; } = Color.White;
        public float Rotation { get; set; } = 0;
        public float Scale { get; set; } = 1;
    }
}
