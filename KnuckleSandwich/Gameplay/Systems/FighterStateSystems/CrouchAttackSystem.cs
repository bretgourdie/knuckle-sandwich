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

            var crouchAttack = entity.GetComponent<CrouchAttack>();

            if (crouchAttack.TimeSpentInState >= attackTime)
            {
                var yInput = yAxis(entity);
                var xInput = xAxis(entity);

                if (isTryingToAttack(attackButton(entity)))
                {
                    if (isTryingToDown(yInput))
                    {
                        entity.RemoveComponent<CrouchAttack>();
                        addState<CrouchAttack>(entity);
                    }

                    else if (inIdleYDeadZone(yInput))
                    {
                        entity.RemoveComponent<CrouchAttack>();
                        addState<NeutralAttack>(entity);
                    }
                }

                if (isTryingToUp(yInput))
                {
                    entity.RemoveComponent<CrouchAttack>();
                    addState<CrouchAttack>(entity);
                }

                else if (isTryingToDown(yInput))
                {
                    entity.RemoveComponent<CrouchAttack>();
                    addState<Crouch>(entity);
                }

                else
                {
                    entity.RemoveComponent<Crouch>();
                    addState<Idle>(entity);
                }
            }
        }
    }
}
