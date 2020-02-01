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

        public JumpAttackSystem() : base(typeof(JumpAttack))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterState>();
            if (fc.TimeSpentInState > attackTime)
            {
                entity.RemoveComponent<JumpAttack>();
                addState<Jump>(entity);
            }
        }
    }
}
