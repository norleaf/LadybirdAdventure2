﻿using System;
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
                //if the _boundingBox is not yet set, we must set it.
                if (_boundingBox.IsEmpty)
                {
                    if (SourceRectangle.IsEmpty)
                    {
                        Console.WriteLine("Source is empty");
                        //If no source rectangle is set then we are not animating, which means we use the entire with and height of the spritetexture
                        _boundingBox = new Rectangle((int)Position.X,(int)Position.Y,(int)SpriteTexture.Width,(int)SpriteTexture.Height);
                        Console.WriteLine("Bounding: " + _boundingBox.X + "," + _boundingBox.Y + "," + _boundingBox.Width + "," + _boundingBox.Height);
                    }
                    else
                    {
                        Console.WriteLine("Else:");
                        Console.WriteLine("SourceRect: " + SourceRectangle.X + "," + SourceRectangle.Y + "," + SourceRectangle.Width + "," + SourceRectangle.Height); 
                        Console.WriteLine("Bounding: " + _boundingBox.X + "," + _boundingBox.Y + "," + _boundingBox.Width + "," + _boundingBox.Height);

                        //We use the width and height of the source rectangle which defines the current frame visible from the spritesheet.
                        _boundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)SourceRectangle.Width, (int)SourceRectangle.Height);
                        Console.WriteLine("Bounding: " + _boundingBox.X + "," + _boundingBox.Y + "," + _boundingBox.Width + "," + _boundingBox.Height);
                    }
                }
                
                return _boundingBox;
            }
        }
    }
}
