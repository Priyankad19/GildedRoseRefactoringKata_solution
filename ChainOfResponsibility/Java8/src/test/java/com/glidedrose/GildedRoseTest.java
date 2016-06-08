package com.glidedrose;

import static org.junit.Assert.*;

import com.gildedrose.*;
import org.junit.Test;

public class GildedRoseTest {

    @Test
    public void shouldDecreaseQualityTwiceIfSellByDateIsPassed() {
        //given
        Item[] items = new Item[] { new Item("+5 Dexterity Vest", 0, 20) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(18, app.items[0].quality);
    }

    @Test
    public void qualityOfItemShouldNotBeNegative() {
        //given
        Item[] items = new Item[] { new Item("+5 Dexterity Vest", 0, 0) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    public void shouldIncreaseQualityOf_AgedBrie_OlderItGets() {
        //given
        Item[] items = new Item[] { new Item("Aged Brie", 2, 0) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(1, app.items[0].sellIn);
        assertEquals(1, app.items[0].quality);

    }

    //- The Quality of an item is never more than 50 except "Sulfuras", being a legendary item
    @Test
    public void shouldAllowQualityMoreThan50ForLegendaryItems_Sulfuras() {
        //given
        Item[] items = new Item[] { new Item("Aged Brie", 2, 50) ,new Item("Sulfuras, Hand of Ragnaros", 0, 80) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(1, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);

        assertEquals(0, app.items[1].sellIn);
        assertEquals(80, app.items[1].quality);

    }

    @Test
    public void shouldNotIncreaseOrDecreaseLegendaryItemQualityAndItIsNotToBeSold_Sulfuras() {
        //given
        Item[] items = new Item[] { new Item("Sulfuras, Hand of Ragnaros", 0, 80) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(0, app.items[0].sellIn);
        assertEquals(80, app.items[0].quality);
    }

    //- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less
    //  and by 3 when there are 5 days or less but Quality drops to 0 after the concert
    @Test
    public void shouldIncreaseInQualityBy1_IfMoreThan10Days_BackstagePasses() {
        //given
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(14, app.items[0].sellIn);
        assertEquals(21, app.items[0].quality);
    }

    @Test
    public void shouldIncreaseInQualityBy2_IfLessThanOrEqualTo10Days_BackstagePasses() {
        //given
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 10, 20) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(9, app.items[0].sellIn);
        assertEquals(22, app.items[0].quality);
    }

    @Test
    public void shouldIncreaseInQualityBy3_IfLessThanOrEqualTo5Days_BackstagePasses() {
        //given
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 5, 20) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(4, app.items[0].sellIn);
        assertEquals(23, app.items[0].quality);

    }

    @Test
    public void shouldZeroTheQualityAfterSellInDate_BackstagePasses() {
        //given
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 0, 20) };
        GildedRose app = new GildedRose(items);
        //when
        app.updateQuality();
        //then
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }
}
