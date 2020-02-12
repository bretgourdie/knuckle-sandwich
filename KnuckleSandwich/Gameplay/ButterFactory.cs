using KnuckleSandwich.Shared.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace KnuckleSandwich.Gameplay
{
    class ButterFactory
    {
        static readonly Texture2D ButterTexture;

        static ButterFactory()
        {
            ButterTexture = Nez.Core.Content.Load<Texture2D>(Nez.Content.Sprites.Bread.Butter);
        }

        public static Butter GetButter(int playerTag)
        {
            return new Butter(ButterTexture, playerTag);
        }
    }
}
