using KnuckleSandwich.Gameplay.Components;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems
{
    class ResetSystem : EntityProcessingSystem
    {
        public ResetSystem() : base(
            new Matcher().All(
                typeof(FighterComponent)
                ))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            if (fc.ResetInput.IsPressed)
            {
                var gameplayScene = new GameplayScene();

                Core.StartSceneTransition(
                    new FadeTransition(() => new GameplayScene()));
            }
        }
    }
}
