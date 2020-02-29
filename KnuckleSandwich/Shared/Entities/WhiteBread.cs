using KnuckleSandwich.Gameplay.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace KnuckleSandwich.Shared.Entities
{
    class WhiteBread : Entity
    {
        public WhiteBread(
            Texture2D breadTexture,
            PlayerIndex playerIndex)
        {
            AddComponent(new FighterComponent(playerIndex, breadTexture));
        }
    }
}
