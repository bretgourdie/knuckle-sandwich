using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class CrouchSystem : FighterStateProcessingSystem
    {
        public CrouchSystem(IDictionary<Type, FighterState> states)
            : base(states, typeof(Crouch)) { }

        public override void Process(Entity entity)
        {
            var yAxis = base.yAxis(entity);

            if (attackButton(entity).IsPressed)
            {
                entity.RemoveComponent<Crouch>();
                entity.AddComponent(getState<CrouchAttack>());
            }

            else if (isTryingToDown(yAxis))
            {
                entity.RemoveComponent<Crouch>();
                entity.AddComponent(getState<Idle>());
            }

            else if (isTryingToUp(yAxis))
            {
                entity.RemoveComponent<Crouch>();
                entity.AddComponent(getState<Jump>());
            }
        }
    }
}
