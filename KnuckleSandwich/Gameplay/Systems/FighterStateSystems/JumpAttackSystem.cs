using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class JumpAttackSystem : FighterStateProcessingSystem
    {
        const float attackTime = 0.75f;

        public JumpAttackSystem(IDictionary<Type, FighterState> states) : base(
            states, typeof(JumpAttack))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterState>();
            if (fc.TimeSpentInState > attackTime)
            {
                entity.RemoveComponent<JumpAttack>();
                entity.AddComponent(getState<Jump>());
            }
        }
    }
}
