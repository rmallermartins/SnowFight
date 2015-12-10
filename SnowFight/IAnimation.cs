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
        int CurrIndex { get; set; }
        Rectangle CurrRect { get; set; }
    }
}
