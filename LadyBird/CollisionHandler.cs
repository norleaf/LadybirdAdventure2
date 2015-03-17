using System;
using System.Collections.Generic;
using LadyBird.Sprites;
using Microsoft.Xna.Framework;

namespace LadyBird
{
    public class CollisionHandler : IUpdateable
    {
        public List<ICollidable> ListenerList { get; set; }
        public List<MovingSprite> MovingList { get; set; } 

        

        public CollisionHandler()
        {
            ListenerList = new List<ICollidable>();
            MovingList = new List<MovingSprite>();
        }


        public void Update(GameTime gameTime)
        {
            foreach (var listener in ListenerList)
            {
                Console.WriteLine("player?: "+listener.BoundingBox);
                foreach (var monster in MovingList)
                {
                 //   Console.WriteLine("aphis?: "+monster.BoundingBox);
                    if (monster.BoundingBox.Intersects(listener.BoundingBox))
                    {
                        Console.WriteLine("collide!!!");
                        listener.CollideWith(monster);
                    }
                }
            }
        }

        public bool Enabled { get; private set; }
        public int UpdateOrder{ get; private set; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
    }
}
