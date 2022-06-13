using System;
using UnityEngine;

namespace EasySkillSystem.Base.Generic
{
    public class Item : MonoBehaviour
    {
        public delegate void ItemDelegate(Status status);

        protected virtual bool OnPreItemObtained(Status status) { return true; }
        protected virtual Item OnItemObtained(Status status) { return this; }
        protected virtual void OnPostItemObtained(Status status)
        {
            gameObject.SetActive(false);
        }
        protected virtual bool OnPreItemDisposed(Status status) { return true; }
        protected virtual Item OnItemDisposed(Status status) { return this; }
        protected virtual void OnPostItemDisposed(Status status)
        {
            gameObject.SetActive(true);
        }

        public Tuple<Item, ItemDelegate> Obtain(Status obtainerStatus)
        {
            return OnPreItemObtained(obtainerStatus)
                ? new Tuple<Item, ItemDelegate>(OnItemObtained(obtainerStatus), OnPostItemObtained)
                : null
            ;
        }
        public Tuple<Item, ItemDelegate> Dispose(Status disposerStatus)
        {
            return OnPreItemDisposed(disposerStatus)
                ? new Tuple<Item, ItemDelegate>(OnItemDisposed(disposerStatus), OnPostItemDisposed)
                : null
            ;
        }
    }
}