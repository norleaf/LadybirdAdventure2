using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LadyBird.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LadyBird
{
    public class Level
    {
        public List<Sprite> LevelSprites { get; set; }
        public List<Sprite> MonsterSprites { get; set; }
        public List<Sprite> BackgroundSprites { get; set; }
        public List<Sprite> DeadSprites { get; set; }
        

        public Level()
        {
            LevelSprites = new List<Sprite>();
            MonsterSprites = new List<Sprite>();
            BackgroundSprites = new List<Sprite>();
            DeadSprites = new List<Sprite>();
        }

        public void MarkDead(Sprite sprite)
        {
            DeadSprites.Add(sprite);
        }

        public void RemoveDeadSprites()
        {
            foreach (MovingSprite sprite in DeadSprites)
            {
                MonsterSprites.Remove(sprite);
                Game1.Instance.CollisionHandler.MovingList.Remove(sprite);
            }
            DeadSprites.Clear();
        }

        public void Update(GameTime gameTime)
        {
            //Start by removing sprites that died in the previous tick
            RemoveDeadSprites();

            foreach (Sprite backgroundSprite in BackgroundSprites)
            {
                backgroundSprite.Update(gameTime);
            }
            foreach (Sprite sprite in MonsterSprites)
            {
                sprite.Update(gameTime);
            }
            foreach (Sprite sprite in LevelSprites)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in BackgroundSprites)
            {
                sprite.Draw(spriteBatch);
            }
            foreach (Sprite sprite in MonsterSprites)
            {
                sprite.Draw(spriteBatch);
            }
            foreach (Sprite sprite in LevelSprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
