using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCSharp
{
    public class Program
    {
        List<Item> Items;

        public List<Item> GetItems
        {
            get { return Items; }
            set { Items = value; }
        }

        public Program(List<Item> items)
        {
            this.Items = items;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            List<Item> Items = new List<Item>()
                                          {
                                              ItemFactory.GetItemByType("+5 Dexterity Vest", 10, 20),
                                              ItemFactory.GetItemByType("Aged Brie", 2, 0),
                                              ItemFactory.GetItemByType("Elixir of the Mongoose", 5, 7),
                                              ItemFactory.GetItemByType("Sulfuras, Hand of Ragnaros", 0, 80),
                                              ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert",15,20),
                                              ItemFactory.GetItemByType("Conjured Mana Cake", 3, 6)
                                          };

            var app = new Program(Items);

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            Items.ForEach(i => i.CalculateSellIn().CalculateQuality());
        }

    }
}
