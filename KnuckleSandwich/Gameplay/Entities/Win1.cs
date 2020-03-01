using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Entities
{
    class Win1 : Entity
    {
        public Win1()
        {
            var texture = Core.Content.Load<Texture2D>(Content.Sprites.Gameplay.Win1);

            AddComponent(new SpriteRenderer(texture));
        }
    }
}
