using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird.Sprites
{
    public class SolidSprite : AnimatedSprite
    {
        public SolidSprite(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }

        public virtual Rectangle BoundingBox
        {
            get
        }
    }
}
