using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LadyBird.Sprites
{
    public class Player: MovingSprite
    {
        Vector2 _right = new Vector2(1, 0);
        Vector2 _left = new Vector2(-1, 0);
        private Animation runAnimation;
        private Animation eatAnimation;
        private Animation chewAnimation;
        private Aphis aphis;
        

        public Player(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            int width = 78;
            int height = 62;
            int rowheight = 63;

            Speed = 3;

            runAnimation = new Animation(this, 100);
            eatAnimation = new Animation(this, 120);
            chewAnimation = new Animation(this, 120);
            
            runAnimation.Frames.Add(new Rectangle(0, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width*2, rowheight, width, height));
            runAnimation.Frames.Add(new Rectangle(width*3, rowheight, width, height));
            SetAnimation(runAnimation);

            width = 98;

            eatAnimation.Frames.Add(new Rectangle(0, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width*2, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width * 3, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width * 4, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width * 5, 0, width, height));
            eatAnimation.Frames.Add(new Rectangle(width * 6, 0, width, height));


            chewAnimation.Frames.Add(new Rectangle(width, 0, width, height));
            chewAnimation.Frames.Add(new Rectangle(width * 6, 0, width, height));
            chewAnimation.Frames.Add(new Rectangle(width, 0, width, height));
            chewAnimation.Frames.Add(new Rectangle(width * 6, 0, width, height));
            chewAnimation.Frames.Add(new Rectangle(width * 2, 0, width, height));
            
        }

        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (SpriteState != State.Eating)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    HorSpeed = 5;
                    effect = SpriteEffects.None;
                    runAnimation.Loop = true;
                    SpriteState = State.Walking;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    HorSpeed = -5;
                    effect = SpriteEffects.FlipHorizontally;
                    runAnimation.Loop = true;
                    SpriteState = State.Walking;

                }
                else
                {
                    if (Grounded(1)) HorSpeed = 0;
                    runAnimation.Loop = false;
                    SpriteState = State.Waiting;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && Grounded(1))
                {
                    VerSpeed = -6;
                    SpriteState = State.Jumping;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    SetAnimation(eatAnimation);
                }
            }
            else
            {
                HorSpeed = 0;
                runAnimation.Loop = false;
            }
            //JsonSerializer serializer = new JsonSerializer();
                //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                //serializer.NullValueHandling = NullValueHandling.Ignore;

                //using (StreamWriter sw = new StreamWriter(@"C:\Users\Hans\Documents\json.txt"))
                //using (JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    Sprite s1 = new Sprite(null, new Vector2(0, 0));
                //    Sprite s2 = new Sprite(null, new Vector2(100, 540));
                //    s1.Name = "Tofu";
                //    s2.Name = "Sushi";
                //   serializer.Serialize(writer, s1);
                //   serializer.Serialize(writer, s2);
    
                //}
            
        }

        public override void AnimationComplete()
        {
            if (Animation == eatAnimation)
            {
                SetAnimation(chewAnimation);
                Game1.Instance.Level.MarkDead(aphis);
                eatAnimation.Restart();
            }
            else if (Animation == chewAnimation)
            {
                SetAnimation(runAnimation);
                chewAnimation.Restart();
                SpriteState = State.Waiting;
            }
        }

        public override void CollideWith(SolidSprite other)
        {
            if (other is Aphis && other != aphis)
            {
                SpriteState = State.Eating;
                SetAnimation(eatAnimation);
                aphis = (Aphis) other;
                //Game1.Instance.Level.MarkDead(other);
            }
        }
    }
}
