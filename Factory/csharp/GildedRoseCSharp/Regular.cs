using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class Regular : Item
    {
        public Regular(string name, int sellIn, int quality) : base(name, sellIn, quality) { }
        public override Item CalculateSellIn()
        {
            return new Regular(this.Name, this.SellIn - 1, this.Quality);
        }

        public override Item CalculateQuality()
        {
            if (this.Quality > 0)
                if (this.SellIn < 0)
                    return new Regular(this.Name, this.SellIn, this.Quality - 2);
                else
                    return new Regular(this.Name, this.SellIn, this.Quality - 1);
            return new Regular(this.Name, this.SellIn, this.Quality);
        }
    }
}
