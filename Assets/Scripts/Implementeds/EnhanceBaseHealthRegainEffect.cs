using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;
using UnityEngine;

public class EnhanceBaseHealthRegainEffect : Effect
{
    [SerializeField] float enhancePercent = .2f;

    BaseHealthRegainEffect baseHealthRegainEffect;
    float enhancedAmount;

    public override Effect Act(Status status)
    {
        baseHealthRegainEffect = (BaseHealthRegainEffect) status.GetEffect(typeof(BaseHealthRegainEffect));
        if (baseHealthRegainEffect == null) return this;

        enhancedAmount = baseHealthRegainEffect.baseHealthRegainPercent * enhancePercent;

        baseHealthRegainEffect.baseHealthRegainPercent += enhancedAmount;

        return this;
    }

    public override Effect Deact(Status status)
    {
        if (baseHealthRegainEffect == null) return this;

        baseHealthRegainEffect.baseHealthRegainPercent -= enhancedAmount;

        return this;
    }
}
