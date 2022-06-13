using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class DemoHealthGainEffect : Effect
{
    float increased;

    public override Effect Act(Status status)
    {
        increased = status.maxHP * .1f;
        status.maxHP += increased;
        return this;
    }

    public override Effect Deact(Status status)
    {
        status.maxHP -= increased;
        return this;
    }
}
