using System;
using System.Collections.Generic;
using UnityEngine;
using EasySkillSystem.Base.Generic;

namespace EasySkillSystem.Base
{
    public class Status : MonoBehaviour
    {
        public float currentHP = 100;
        public float maxHP = 100;

        List<Effect> effects = new List<Effect>();
        public void AddEffect(Effect effect)
        {
            effects.Add(effect.Act(this));
        }
        public void RemoveEffect(Effect effect)
        {
            effects.Remove(effect.Deact(this));
        }
        public Effect GetEffect(Type type)
        {
            foreach (Effect effect in effects)
                if (effect.GetType().Equals(type))
                    return effect;
            return null;
        }

        private void Update()
        {
            if (currentHP > maxHP) currentHP = maxHP;
        }
    }
}