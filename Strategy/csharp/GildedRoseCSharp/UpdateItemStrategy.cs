using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class UpdateItemStrategy
    {
        private static Dictionary<String, Func<Item, Item>> strategyDict = new Dictionary<String, Func<Item, Item>>{
            {"Sulfuras, Hand of Ragnaros", LegendaryItem },
            {"Aged Brie", AgedBrewItem },
            {"Backstage passes to a TAFKAL80ETC concert", BackstagePasses },
            {"Conjured Mana Cake", ConjuredItem }
        };

        public static Item UpdateItem(Item i)
        {
            if (strategyDict.ContainsKey(i.Name))
                return strategyDict[i.Name](i);
            else
                return RegularItem(i);
        }

        private static Item BackstagePasses(Item i)
        {
            i = i.decSellIn();

            if (i.Quality < 50)
            {
                if (i.SellIn < 0)
                    return i.zeroQuality();
                else if (i.SellIn < 6)
                    return i.incQuality().incQuality().incQuality();
                else if (i.SellIn < 11)
                    return i.incQuality().incQuality();
                else
                    return i.incQuality();
            }
            return i;
        } 

        private static Item RegularItem(Item i)
        {
            i = i.decSellIn();

            if (i.Quality > 0)
                if (i.SellIn < 0)
                    i = i.decQuality().decQuality();
                else
                    i = i.decQuality();

            return i;
        }

        private static Item LegendaryItem(Item i)
        {
            return i;
        }


        private static Item AgedBrewItem(Item i)
        {
            i = i.decSellIn();

            if (i.Quality < 50)
                return i.incQuality();

            return i;
        }


        private static Item ConjuredItem(Item i)
        {
            i = i.decSellIn();
            return i.decQuality().decQuality();

        }

    }
}
