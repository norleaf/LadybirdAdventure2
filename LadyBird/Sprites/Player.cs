using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LadyBird.Sprites
{
    class Player: MovingSprite, ICollidable
    {
        Vector2 _right = new Vector2(1, 0);
        Vector2 _left = new Vector2(-1, 0);
        private Animation runAnimation;
        
        

        public Player(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            int width = 78;
            int height = 62;
            int rowheight = 63;

            runAnimation = new Animation(this,100);
            
            runAnimation.Frames.Add(new Rectangle(0, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width*2, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width*3, rowheight, width, height));
            SetAnimation(runAnimation);

            Speed = 3;
        }

        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                HorSpeed = 5;
                effect = SpriteEffects.None;
                runAnimation.Loop = true;
            } 
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                HorSpeed = -5;
                effect = SpriteEffects.FlipHorizontally;
                runAnimation.Loop = true;
            }
            else
            {
                if(Grounded(1)) HorSpeed = 0;
                runAnimation.Loop = false;
            }    
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Grounded(1))
            {
                VerSpeed = -6;
            }
            
            
        }

        

        
    }
}
