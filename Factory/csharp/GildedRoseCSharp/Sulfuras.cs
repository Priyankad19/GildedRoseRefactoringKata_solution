using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
   public class Sulfuras : Item
    {
       public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality) { }
        public override Item CalculateSellIn()
        {
            return this;
         }

        public override Item CalculateQuality()
        {
            return this;
        }
    }
}
