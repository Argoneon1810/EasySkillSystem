using System.Collections;
using UnityEngine;
using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class BaseHealthRegainEffect : Effect
{
    public float baseHealthRegainPercent = 0.03f;
    IEnumerator healthRegainCoroutine;

    public override Effect Act(Status status)
    {
        healthRegainCoroutine = HealthRegainWorker(status);
        StartCoroutine(healthRegainCoroutine);
        return this;
    }

    public override Effect Deact(Status status)
    {
        StopCoroutine(healthRegainCoroutine);
        return this;
    }

    IEnumerator HealthRegainWorker(Status status)
    {
        while(true)
        {
            status.currentHP += status.maxHP * baseHealthRegainPercent;
            yield return new WaitForSeconds(1f);
        }
    }
}
