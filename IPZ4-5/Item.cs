using System;

namespace IPZ4_5
{
    public abstract class Item
    {
        public virtual string Type { get; }
        internal string WearType { get; set; }
        private double _wearAmount = 0;
        internal int WearAmount { get; set; }
        public virtual void DoChanges()
        {
            WearIt();
        }
        public void WearIt()
        {
            _wearAmount++;
        }
        public Item(string wearType, int wearAmount)
        {
            WearType = wearType;
            WearAmount = wearAmount;
        }
    }
}
