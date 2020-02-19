using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class NeutralAttackSystem : FighterStateProcessingSystem
    {
        const float _attackTime = 0.5f;

        public NeutralAttackSystem() : base(typeof(NeutralAttack))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var tauntInput = tauntButton(entity);

            if (!isTryingToTaunt(tauntInput))
            {
                var xInput = xAxis(entity);
                var yInput = yAxis(entity);

                if (isTryingToUp(yInput))
                {
                    cleanupForStateChange(entity);
                    addState<Jump>(entity);
                }

                else if (isTryingToDown(yInput))
                {
                    cleanupForStateChange(entity);
                    addState<Crouch>(entity);
                }

                else if (isTryingToLeft(xInput) || isTryingToRight(xInput))
                {
                    cleanupForStateChange(entity);
                    addState<Walk>(entity);
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
            entity.RemoveComponent<NeutralAttack>();
        }
    }
}
