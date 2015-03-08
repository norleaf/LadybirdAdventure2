#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace LadyBird.Sprites
{
    
    public class Sprite
    {
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
    }
}
