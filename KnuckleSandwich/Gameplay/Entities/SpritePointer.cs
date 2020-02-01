using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Nez;

namespace KnuckleSandwich.Gameplay.Entities
{
    class SpritePointer : Entity
    {
        public SpritePointer()
        {
            AddComponent(new SpritePointing());
            Position = new Vector2(
                Constants.Width / 2,
                Constants.Height / 2);
        }
    }
}
