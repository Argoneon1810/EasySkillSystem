using System;

namespace EasySkillSystem.Base.Generic
{
    public class ConsumableItem : Item
    {

        protected virtual bool OnPreItemConsumed(Status status) { return true; }
        protected virtual Item OnItemConsumed(Status status) { return this; }
        protected virtual void OnPostItemConsumed(Status status)
        {
            Destroy(gameObject);
        }

        public Tuple<Item, ItemDelegate> Consume(Status consumerStatus)
        {
            return OnPreItemConsumed(consumerStatus)
                ? new Tuple<Item, ItemDelegate>(OnItemConsumed(consumerStatus), OnPostItemConsumed)
                : null
            ;
        }
    }
}