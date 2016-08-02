using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseCSharp.Test
{
    [TestClass]
    public class GlidedRoseTest
    {
        [TestMethod]
        public void shouldCheckDefaultOutput()
        {
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

            List<Item> ItemsReturned = app.UpdateQuality();

            List<Item> expectedOutput = new List<Item>()
                                          {
                                              ItemFactory.GetItemByType("+5 Dexterity Vest", 9, 19),
                                              ItemFactory.GetItemByType("Aged Brie", 1, 1),
                                              ItemFactory.GetItemByType("Elixir of the Mongoose", 4, 6),
                                              ItemFactory.GetItemByType("Sulfuras, Hand of Ragnaros", 0, 80),
                                              ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert",14,21),
                                              ItemFactory.GetItemByType("Conjured Mana Cake", 2, 4)
                                          };

            Assert.AreEqual<Item>(expectedOutput[0], ItemsReturned[0]);
            Assert.AreEqual<Item>(expectedOutput[1], ItemsReturned[1]);
            Assert.AreEqual<Item>(expectedOutput[2], ItemsReturned[2]);
            Assert.AreEqual<Item>(expectedOutput[3], ItemsReturned[3]);
            Assert.AreEqual<Item>(expectedOutput[4], ItemsReturned[4]);
            Assert.AreEqual<Item>(expectedOutput[5], ItemsReturned[5]);
        }



        //- Once the sell by date has passed, Quality degrades twice as fast
        [TestMethod]
        public void shouldDecreasetheQualityTwiceIfSellByDateIsPassed()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("+5 Dexterity Vest", 0, 20 ) };
            var app = new Program(Items);
            

            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("+5 Dexterity Vest", -1, 18 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);
        }

        //- The Quality of an item is never negative
        [TestMethod]
        public void qualityOfItemShouldNotBeNegative()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("+5 Dexterity Vest", 0, 0 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType( "+5 Dexterity Vest", -1, 0 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);
        }

        //- "Aged Brie" actually increases in Quality the older it gets
        [TestMethod]
        public void shouldincreasetheQualityof_AgedBrie()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Aged Brie", 2, 0 ) };
            var app = new Program(Items);
           

            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Aged Brie", 1, 1 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        //- The Quality of an item is never more than 50 except "Sulfuras", being a legendary item
        [TestMethod]
        public void qualityOfanItemShouldNotExceed50_ExceptSulfras()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Aged Brie", 2, 50 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() { ItemFactory.GetItemByType("Aged Brie", 1, 50 )};

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [TestMethod]
        public void shouldNotIncreaseOrDecreaseQualityof_Sulfuras()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Sulfuras, Hand of Ragnaros", 0, 80 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Sulfuras, Hand of Ragnaros",0,  80 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        //- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less 
        //  and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [TestMethod]
        public void shouldIncreaseInQualityBy1_IfMoreThan10Days_BackstagePasses()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 15, 20 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 14, 21 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        [TestMethod]
        public void shouldIncreaseInQualityBy2_IfLessThanOrEqualTo10Days_BackstagePasses()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 10, 20 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 9, 22 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        [TestMethod]
        public void shouldIncreaseInQualityBy3_IfLessThanOrEqualTo5Days_BackstagePasses()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 5, 20 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", 4, 23 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }

        [TestMethod]
        public void shouldZerotheQualityAfterSellInDate_BackstagePasses()
        {
            List<Item> Items = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert",  0,  20 ) };
            var app = new Program(Items);
            
            List<Item> expectedOutput = new List<Item>() {  ItemFactory.GetItemByType("Backstage passes to a TAFKAL80ETC concert", -1, 0 ) };

            Assert.AreEqual<Item>(expectedOutput[0], app.UpdateQuality()[0]);

        }
    }
}
