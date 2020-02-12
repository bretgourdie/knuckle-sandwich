using KnuckleSandwich.Gameplay.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace KnuckleSandwich.Shared.Entities
{
    class Butter : Entity
    {


        public Butter(
            Texture2D butterTexture,
            PlayerIndex playerIndex)
        {
            AddComponent(new AttackingComponent(butterTexture, playerIndex));
        }
    }
}
