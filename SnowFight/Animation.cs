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
        public int CurrIndex { get; set; } = 0;
        public Rectangle CurrRect { get; set; } = new Rectangle();
    }
}
