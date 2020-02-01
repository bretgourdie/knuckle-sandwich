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

        public CrouchAttackSystem(IDictionary<Type, FighterState> states) : base(
            states,
            typeof(CrouchAttackSystem))
        { }

        public override void Process(Entity entity)
        {
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
                        entity.AddComponent(getState<CrouchAttack>());
                    }

                    else if (inIdleYDeadZone(yInput))
                    {
                        entity.RemoveComponent<CrouchAttack>();
                        entity.AddComponent(getState<NeutralAttack>());
                    }
                }

                if (isTryingToUp(yInput))
                {
                    entity.RemoveComponent<CrouchAttack>();
                    entity.AddComponent(getState<Jump>());
                }

                else if (isTryingToDown(yInput))
                {
                    entity.RemoveComponent<CrouchAttack>();
                    entity.AddComponent(getState<Crouch>());
                }

                else
                {
                    entity.RemoveComponent<Crouch>();
                    entity.AddComponent(getState<Idle>());
                }
            }
        }
    }
}
