using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class CrouchAttackSystem : FighterStateProcessingSystem
    {
        const float attackTime = 0.35f;

        public CrouchAttackSystem() : base(typeof(CrouchAttack))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var tauntInput = tauntButton(entity);

            if (!isTryingToTaunt(tauntInput))
            {
                var yInput = yAxis(entity);
                var xInput = xAxis(entity);

                if (isTryingToUp(yInput))
                {
                    cleanupForStateChange(entity);
                    addState<CrouchAttack>(entity);
                }

                else if (isTryingToDown(yInput))
                {
                    cleanupForStateChange(entity);
                    addState<Crouch>(entity);
                }

                else
                {
                    cleanupForStateChange(entity);
                    addState<Idle>(entity);
                }
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<CrouchAttack>();
        }
    }
}
