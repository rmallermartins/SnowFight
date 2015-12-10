using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SnowFight
{
    public class Player : IPlayer
    {
        public IAnimation Animation { get; set; }

        public Player()
        {
            Animation = new Animation("run_cycle");
        }

        public void LoadContent(ContentManager content)
        {
            Animation.LoadContent(content);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch);
        }
    }
}
