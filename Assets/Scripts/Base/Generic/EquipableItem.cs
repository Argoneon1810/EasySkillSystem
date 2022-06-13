using System;

namespace EasySkillSystem.Base.Generic
{
    public class EquipableItem : Item
    {
        private EquipmentMountPosition _equipmentMountPosition;
        public EquipmentMountPosition GetEquipmentMountPosition() => _equipmentMountPosition;
        protected void SetEquipmentMountPosition(EquipmentMountPosition equipmentMountPosition) => _equipmentMountPosition = equipmentMountPosition;

        protected virtual bool OnPreItemEquipped(Status status) { return true; }
        protected virtual EquipableItem OnItemEquipped(Status status) { return this; }
        protected virtual void OnPostItemEquipped(Status status) { }
        protected virtual bool OnPreItemUnequipped(Status status) { return true; }
        protected virtual EquipableItem OnItemUnequipped(Status status) { return this; }
        protected virtual void OnPostItemUnequipped(Status status) { }

        public Tuple<EquipableItem, ItemDelegate> Equip(Status equipperStatus)
        {
            return OnPreItemEquipped(equipperStatus)
                ? new Tuple<EquipableItem, ItemDelegate>(OnItemEquipped(equipperStatus), OnPostItemEquipped)
                : null
            ;
        }

        public Tuple<EquipableItem, ItemDelegate> Unequip(Status unequipperStatus)
        {
            return OnPreItemUnequipped(unequipperStatus)
                ? new Tuple<EquipableItem, ItemDelegate>(OnItemUnequipped(unequipperStatus), OnPostItemUnequipped)
                : null
            ;
        }
    }
}