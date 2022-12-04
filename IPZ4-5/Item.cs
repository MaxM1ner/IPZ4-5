using System;

namespace IPZ4_5
{
    public abstract class Item
    {
        public virtual string Type { get; }
        internal string WearType { get; set; }
        public int WearAmount { get; private set; }
        public virtual void DoChanges()
        {
            WearIt();
        }
        public void WearIt()
        {
            WearAmount++;
        }
        public Item(string wearType, int wearAmount)
        {
            WearType = wearType;
            WearAmount = wearAmount;
        }
    }
}
