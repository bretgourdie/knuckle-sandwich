using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Entities
{
    class Win2 : Entity
    {
        public Win2()
        {
            var texture = Core.Content.Load<Texture2D>(Content.Sprites.Gameplay.Win2);

            AddComponent(new SpriteRenderer(texture));
        }
    }
}
