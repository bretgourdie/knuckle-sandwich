using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class IdleSystem : FighterStateProcessingSystem
    {
        public IdleSystem() : base(typeof(Idle))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var yInput = yAxis(entity);
            var xInput = xAxis(entity);

            if (isTryingToAttack(attackButton(entity)))
            {
                entity.RemoveComponent<Idle>();
                addState<NeutralAttack>(entity);
            }

            else if (isTryingToUp(yInput))
            {
                entity.RemoveComponent<Idle>();
                addState<Jump>(entity);
            }

            else if (isTryingToDown(yInput))
            {
                entity.RemoveComponent<Idle>();
                addState<Crouch>(entity);
            }

            else if (isTryingToLeft(xInput) || isTryingToRight(xInput))
            {
                entity.RemoveComponent<Idle>();
                addState<Walk>(entity);
            }
        }
    }
}
