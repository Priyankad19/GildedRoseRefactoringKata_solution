using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public abstract class Item
    {
        public Item() { }
        public Item(string name)
            : this(name, 0, 0) { }

        protected Item(string name, int sellIn, int quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }
        protected string Name { get; set; }

        protected int SellIn { get; set; }

        protected int Quality { get; set; }

        public abstract Item CalculateSellIn();
        public abstract Item CalculateQuality();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Item otherObject = (Item)obj;
            if (this.Name.Equals(otherObject.Name, System.StringComparison.CurrentCultureIgnoreCase) && this.Quality == otherObject.Quality && this.SellIn == otherObject.SellIn)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}
