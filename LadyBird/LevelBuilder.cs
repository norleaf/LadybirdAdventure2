using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LadyBird.Sprites;

namespace LadyBird
{
    public class LevelBuilder
    {
        Level level = new Level();
        public SolidSprite Dummy { get; set; }
        public Aphis Aphis { get; set; }

        public LevelBuilder()
        {
            
        }

        public void CleanData()
        {
            level.BackgroundSprites.Clear();
            level.MonsterSprites.Clear();
            level.LevelSprites.Clear();
        }

        public Level LoadLevel1()
        {
            CleanData();
            level.MonsterSprites.Add(Aphis.CloneSprite(300, 500));
            level.MonsterSprites.Add(Aphis.CloneSprite(500, 650));
            level.LevelSprites.Add(Dummy.CloneSprite(-700,700));
            foreach (MovingSprite monsterSprite in level.MonsterSprites)
            {
                Game1.Instance.CollisionHandler.MovingList.Add(monsterSprite);
            }
            return level;
        }
    }
}
