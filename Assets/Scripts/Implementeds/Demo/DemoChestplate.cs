using UnityEngine;
using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class DemoChestplate : EquipableItem
{
    [SerializeField] Effect effect;

    private void Awake()
    {
        SetEquipmentMountPosition(EquipmentMountPosition.Chest);
    }

    #region Obtain
    protected override bool OnPreItemObtained(Status status)
    {
        Debug.Log("Before Obtain");
        return true;
    }

    protected override Item OnItemObtained(Status status)
    {
        Debug.Log("Obtained");
        status.RemoveEffect(effect);
        return this;
    }

    protected override void OnPostItemObtained(Status status)
    {
        Debug.Log("After Obtain");
    }
    #endregion

    #region Equip
    protected override bool OnPreItemEquipped(Status status)
    {
        Debug.Log("Before Equip");
        return true;
    }

    protected override EquipableItem OnItemEquipped(Status status)
    {
        Debug.Log("Equipped");
        status.AddEffect(effect);
        return this;
    }

    protected override void OnPostItemEquipped(Status status)
    {
        Debug.Log("After Equip");
    }
    #endregion

    #region Unequip
    protected override bool OnPreItemUnequipped(Status status)
    {
        Debug.Log("Before Unequip");
        return true;
    }

    protected override EquipableItem OnItemUnequipped(Status status)
    {
        Debug.Log("Unequipped");
        return this;
    }

    protected override void OnPostItemUnequipped(Status status)
    {
        Debug.Log("After Unequip");
        status.RemoveEffect(effect);
    }
    #endregion
}
