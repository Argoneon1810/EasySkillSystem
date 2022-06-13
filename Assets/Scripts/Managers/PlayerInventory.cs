using System;
using System.Collections.Generic;
using UnityEngine;
using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void Obtain(Tuple<Item, Item.ItemDelegate> tuple)
    {
        if (tuple == null) return;

        items.Add(tuple.Item1);

        tuple.Item2.Invoke(GetComponent<Status>());
    }
}