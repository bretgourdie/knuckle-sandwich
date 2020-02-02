using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class JumpAttackSystem : FighterStateProcessingSystem
    {
        const float attackTime = 0.75f;

        public JumpAttackSystem() : base(typeof(JumpAttack))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var fc = entity.GetComponent<FighterState>();
            if (fc.TimeSpentInState > attackTime)
            {
                cleanupForStateChange(entity);
                addState<Jump>(entity);
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<JumpAttack>();
        }
    }
}
