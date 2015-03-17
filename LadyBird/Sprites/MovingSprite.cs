using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird.Sprites
{
    public class MovingSprite : SolidSprite, ICollidable
    {
        public float Rotation { get; private set; }
        public SpriteEffects effect;
        public static float gravity = 0.2f;
        
        public float Speed { get; set; }
        public float HorSpeed { get; set; }
        public float VerSpeed { get; set; }
        private Game1 game;

        public MovingSprite(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            SourceRectangle = new Rectangle(0,0, SpriteTexture.Width, SpriteTexture.Height);
            game = Game1.Instance;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (VerSpeed < 10) VerSpeed += gravity;
            //are we standing on anything?
            if (Grounded((int)VerSpeed))
            {
                while (!Grounded(Math.Sign(VerSpeed)))
                {
                    Position = new Vector2(Position.X, Position.Y + Math.Sign(VerSpeed));
                }
                VerSpeed = 0;
            }
            if (Walled((int) HorSpeed))
            {
                while (!Walled(Math.Sign(HorSpeed)))
                {
                    Position = new Vector2(Position.X + Math.Sign(HorSpeed),Position.Y);
                }
                HorSpeed = 0;
            }
            Position = new Vector2(Position.X + HorSpeed, Position.Y + VerSpeed);
        }


        public bool Walled(int distance)
        {
            bool result = false;
            Rectangle nextBoundingBox = new Rectangle((int)Position.X + distance, (int)Position.Y, SourceRectangle.Width, SourceRectangle.Height-1);
            foreach (SolidSprite otherSprite in game.Level.LevelSprites)
            {
                if (otherSprite != this)
                {
                    if (nextBoundingBox.Intersects(otherSprite.BoundingBox))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool Grounded(int distance)
        {
            {
                bool result = false;

                Rectangle nextBoundingBox = new Rectangle((int)Position.X, (int)Position.Y + distance, SourceRectangle.Width, SourceRectangle.Height);
                foreach (SolidSprite otherSprite in game.Level.LevelSprites)
                {
                    if (otherSprite!=this)
                    {
                        if (nextBoundingBox.Intersects(otherSprite.BoundingBox))
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
        }

        public Vector2 Center
        {
            get
            {
                return new Vector2(BoundingBox.Width / 2, BoundingBox.Height / 2);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, SourceRectangle, Color.White, Rotation, new Vector2(0,0), 1, effect, 0 );
        }

        public virtual void CollideWith(SolidSprite other)
        {
            //throw new NotImplementedException();
        }
    }
}
