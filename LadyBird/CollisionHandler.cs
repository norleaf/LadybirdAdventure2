using System;
using System.Collections.Generic;
using LadyBird.Sprites;
using Microsoft.Xna.Framework;

namespace LadyBird
{
    public class CollisionHandler : IUpdateable
    {
        public List<SolidSprite> SolidsList { get; set; }
        public List<MovingSprite> MovingList { get; set; } 
        private static CollisionHandler _instance;

        public static CollisionHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CollisionHandler();
                }
                return _instance;
            }
        }

        private CollisionHandler()
        {
            SolidsList = new List<SolidSprite>();
            MovingList = new List<MovingSprite>();
        }


        public void Update(GameTime gameTime)
        {
            foreach (var movingSprite in MovingList)
            {
                foreach (var solid in SolidsList)
                {
                    if (solid.BoundingBox.Intersects(movingSprite.BoundingBox))
                    {
                        //solid.BoundingBox.Contains()
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
