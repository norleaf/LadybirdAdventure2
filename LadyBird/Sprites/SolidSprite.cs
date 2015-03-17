using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird.Sprites
{
    public class SolidSprite : AnimatedSprite
    {
        private Rectangle _boundingBox;

        public SolidSprite(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }

        public virtual Rectangle BoundingBox
        {
            get
            {
                if (SourceRectangle.IsEmpty)
                {
                    //If no source rectangle is set then we are not animating, which means we use the entire with and height of the spritetexture
                    _boundingBox = new Rectangle((int)Position.X,(int)Position.Y,(int)SpriteTexture.Width,(int)SpriteTexture.Height);
                }
                else
                {
                    //We use the width and height of the source rectangle which defines the current frame visible from the spritesheet.
                    _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)SourceRectangle.Width, (int)SourceRectangle.Height);
                }
                return _boundingBox;
            }
        }

        public override Sprite CloneSprite(int x, int y)
        {
            return new SolidSprite(SpriteTexture, new Vector2(x,y));
        }
    }
}
