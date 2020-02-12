using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace KnuckleSandwich.Gameplay.Components
{
    class AttackingComponent : Component
    {
        private readonly PlayerIndex _playerIndex;
        private readonly Texture2D _butterTexture;

        public AttackingComponent(
            Texture2D butterTexture,
            PlayerIndex playerIndex)
        {
            _playerIndex = playerIndex;
            _butterTexture = butterTexture;
        }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            Entity.AddComponent(new BoxCollider()
            {
                IsTrigger = true,
                ShouldColliderScaleAndRotateWithTransform = true
            });

            Entity.AddComponent(
                new SpriteRenderer(
                    new Sprite(_butterTexture)
                )
            );
        }
    }
}
