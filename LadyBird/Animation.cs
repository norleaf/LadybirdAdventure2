using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LadyBird.Sprites;
using Microsoft.Xna.Framework;

namespace LadyBird
{
    public class Animation
    {
        private double _millisecondsSinceLastFrameUpdate;
        private AnimatedSprite _sprite;
        private int _currentFrame;
        public List<Rectangle> Frames { get; set; }
        public bool Loop { get; set; }
        public int Delay { get; set; }

        public Animation(AnimatedSprite sprite, int delay)
        {
            _sprite = sprite;
            Delay = delay;
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > _millisecondsSinceLastFrameUpdate + Delay)
            {
                _sprite.SourceRectangle = NextFrame();
                _millisecondsSinceLastFrameUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        private Rectangle NextFrame()
        {
            if (_currentFrame == Frames.Count - 1 && Loop) _currentFrame = 0;
            else if (_currentFrame < Frames.Count - 1) _currentFrame++;
            else _sprite.AnimationComplete();
            return Frames[_currentFrame];
        }
    }
}
