using System;
using UnityEngine;
using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class PlayerEquipmentManager: MonoBehaviour
{
    [SerializeField] private GameObject chestMountPosition;

    [SerializeField] private EquipableItem chest;

    [SerializeField] private bool debug_unequip_all;

    [SerializeField] private float unequipRespawnDistance = 2;

    public void Equip(Tuple<EquipableItem, Item.ItemDelegate> tuple)
    {
        if (tuple == null) return; 

        switch(tuple.Item1.GetEquipmentMountPosition())
        {
            case EquipmentMountPosition.Chest:
                chest = tuple.Item1;
                chest.transform.SetParent(transform);
                chest.transform.position = chestMountPosition.transform.position;
                break;
            default:
                break;
        }

        tuple.Item2.Invoke(GetComponent<Status>());
    }

    public void Unequip(Tuple<EquipableItem, Item.ItemDelegate> tuple)
    {
        if (tuple == null) return;

        switch(tuple.Item1.GetEquipmentMountPosition())
        {
            case EquipmentMountPosition.Chest:
                if (chest == tuple.Item1)
                {
                    chest.transform.SetParent(null);
                    chest.transform.position = chest.transform.position + transform.forward * unequipRespawnDistance;
                    chest.gameObject.AddComponent<Rigidbody>();
                    chest = null;
                }
                break;
            default:
                break;
        }

        tuple.Item2.Invoke(GetComponent<Status>());
    }

    private void Update()
    {
        if(debug_unequip_all)
        {
            debug_unequip_all = false;

            Unequip(chest.Unequip(GetComponent<Status>()));
        }
    }
}