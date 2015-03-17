using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird.Sprites
{
    public class AnimatedSprite : Sprite
    {
        public Animation Animation { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public State SpriteState { get; set; }

        public enum State
        {
            Waiting,
            Walking,
            Jumping,
            Fighting,
            Eating
        }
        
        public AnimatedSprite(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }

        public void SetAnimation(Animation animation)
        {
            Animation = animation;
        }

        public virtual void AnimationComplete()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Animation != null)
            {
                Animation.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (SourceRectangle.IsEmpty)
            {
                spriteBatch.Draw(SpriteTexture,Position,Color.White);
            }
            else
            {
                spriteBatch.Draw(SpriteTexture,Position,SourceRectangle,Color.White);
            }
        }
    }
}
