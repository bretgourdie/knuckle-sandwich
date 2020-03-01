using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Entities;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems
{
    class WinSystem : EntityProcessingSystem
    {
        private readonly Entity[] winTexts;

        public WinSystem() : base(
            new Matcher().All(typeof(Winner)
                ))
        {
            winTexts = new Entity[]
            {
                new Win1(),
                new Win2()
            };
        }

        public override void Process(Entity entity)
        {
            var playerToCelebrate = entity.Tag;

            var celebration = winTexts[playerToCelebrate];

            Scene.AddEntity(
                winTexts[playerToCelebrate]);

            celebration.SetPosition(new Vector2(
                Constants.Width / 2,
                Constants.Height / 4));

            entity.RemoveComponent<Winner>();
        }
    }
}
