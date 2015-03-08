using LadyBird.Sprites;
using Microsoft.Xna.Framework;

namespace LadyBird
{
    public interface ICollidable
    {
        void CollideWith(SolidSprite other);

        Rectangle BoundingBox { get; }
    }
}