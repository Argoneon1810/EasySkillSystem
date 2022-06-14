using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;
using UnityEngine;

public class DefaultEffectLoader : MonoBehaviour
{
    private Status status;
    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<Status>();
        Effect[] defaultEffects =transform.GetComponentsInChildren<Effect>();
        foreach(Effect defaultEffect in defaultEffects)
        {
            status.AddEffect(defaultEffect);
        }
        Destroy(this);
    }
}
