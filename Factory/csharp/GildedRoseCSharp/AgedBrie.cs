using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override Item CalculateSellIn()
        {
            return new AgedBrie(this.Name, this.SellIn - 1, this.Quality);
        }

        public override Item CalculateQuality()
        {
            if (this.Quality < 50)
                 return new AgedBrie(this.Name, this.SellIn, this.Quality+1);
            return new AgedBrie(this.Name, this.SellIn, this.Quality);
        }
    }
}
