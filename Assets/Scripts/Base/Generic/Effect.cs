using UnityEngine;

namespace EasySkillSystem.Base.Generic
{
    public class Effect : MonoBehaviour
    {
        public virtual Effect Act(Status status)
        {
            return this;
        }

        public virtual Effect Deact(Status status)
        {
            return this;
        }
    }
}