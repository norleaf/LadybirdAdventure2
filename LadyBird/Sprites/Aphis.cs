using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird.Sprites
{
    public class Aphis : MovingSprite
    {
        public Aphis(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            Name = "Aphis";
           // HorSpeed = 2;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }

        //public override void CollideWith(SolidSprite other)
        //{
        //    if(other is Player)
        //    Game1.Instance.Level.MarkDead(this);
        //}

        public override Sprite CloneSprite(int x, int y)
        {
            Aphis newAphis = new Aphis(SpriteTexture, new Vector2(x,y));
            return newAphis;
        }
    }
}
