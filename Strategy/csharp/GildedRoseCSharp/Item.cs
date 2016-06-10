using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class Item
    {
        public Item() { }
        public Item(string name)
            : this(name, 0, 0) { }

        private Item(string name, int sellIn, int quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public Item incSellIn()
        {
            return new Item(Name, SellIn + 1, Quality);
        }

        public Item incQuality()
        {
            return new Item(Name, SellIn, Quality + 1);
        }

        public Item decSellIn()
        {
            return new Item(Name, SellIn - 1, Quality);
        }

        public Item decQuality()
        {
            return new Item(Name, SellIn, Quality - 1);
        }

        public Item zeroQuality()
        {
            return new Item(Name, SellIn, 0);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Item otherObject = (Item)obj;
            if (this.Name.Equals(otherObject.Name, System.StringComparison.CurrentCultureIgnoreCase))
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
