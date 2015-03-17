#region Using Statements

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace LadyBird.Sprites
{
    
    public class Sprite
    {
        public String Name { get; set; }
        public Texture2D SpriteTexture { get; set; }
        public Vector2 Position { get; set; }

        public Sprite(Texture2D spriteTexture, Vector2 position)
        {
            SpriteTexture = spriteTexture;
            Position = position;
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, Color.White);
        }

        public virtual Sprite CloneSprite(int x, int y)
        {
            return new Sprite(SpriteTexture,new Vector2(x,y));
        }
    }
}
