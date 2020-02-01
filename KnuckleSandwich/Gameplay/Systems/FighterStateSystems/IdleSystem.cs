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
        public IdleSystem(IDictionary<Type, FighterState> states) :
            base(states, typeof(Idle))
        { }

        public override void Process(Entity entity)
        {
            var yInput = yAxis(entity);
            var xInput = xAxis(entity);

            if (isTryingToAttack(attackButton(entity)))
            {
                entity.RemoveComponent<Idle>();
                entity.AddComponent(getState<NeutralAttack>());
            }

            else if (isTryingToUp(yInput))
            {
                entity.RemoveComponent<Idle>();
                entity.AddComponent(getState<Jump>());
            }

            else if (isTryingToDown(yInput))
            {
                entity.RemoveComponent<Idle>();
                entity.AddComponent(getState<Crouch>());
            }

            else if (isTryingToLeft(xInput) || isTryingToRight(xInput))
            {
                entity.RemoveComponent<Idle>();
                entity.AddComponent(getState<Walk>());
            }
        }
    }
}
