using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(string name, int sellIn, int quality) : base(name, sellIn, quality) { }
        public override Item CalculateSellIn()
        {
            return new BackstagePasses(this.Name, this.SellIn - 1, this.Quality);
        }
        public override Item CalculateQuality()
        {
            if (this.Quality < 50)
            {
                if (this.SellIn < 0)
                    return new BackstagePasses(this.Name, this.SellIn, 0);
                else if (this.SellIn < 6)
                    return new BackstagePasses(this.Name, this.SellIn, this.Quality + 3);
                else if (this.SellIn < 11)
                    return new BackstagePasses(this.Name, this.SellIn, this.Quality + 2);
                else
                    return new BackstagePasses(this.Name, this.SellIn, this.Quality + 1);
            }
            return new BackstagePasses(this.Name, this.SellIn, this.Quality);
        }
    }
}
