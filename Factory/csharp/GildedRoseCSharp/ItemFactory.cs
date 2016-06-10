using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public static class ItemFactory
    {
        public static Item GetItemByType(string name, int sellIn, int quality)
        {
            switch (name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(name,sellIn,quality);
                case "Aged Brie":
                    return new AgedBrie(name, sellIn, quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePasses(name, sellIn, quality);
                default:
                    return new Regular(name, sellIn, quality);
            }
        }
    }
}
