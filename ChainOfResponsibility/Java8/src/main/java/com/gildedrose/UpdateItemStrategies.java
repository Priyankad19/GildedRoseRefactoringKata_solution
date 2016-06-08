package com.gildedrose;

import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


class UpdateItemStrategies {

    private static final int MAX_QUALITY = 50;
    private static final int MIN_SELLIN = 0;

    @FunctionalInterface
    interface Rule {
        ItemWrapper apply(Item item);
    }

    private static class ItemWrapper {
        public final Item item;
        public final boolean goNext;
        ItemWrapper(Item item,boolean goNext){
            this.item = item;
            this.goNext = goNext;
        }
        static ItemWrapper nextRule(Item item){
            return new ItemWrapper(item,true);
        }
        ItemWrapper(Item item){
         this(item,false);
        }

    }

    private static final Map<Item,List<Rule>> rules = new HashMap<Item,List<Rule>>(){{
        put(Item.make("Aged Brie"), Arrays.asList(
                i -> new ItemWrapper(i.decSellIn(),true),
                i -> isQualityLessThenMax(i)?new ItemWrapper(i.incQuality()):new ItemWrapper(i)
        ));

        put(Item.make("Sulfuras, Hand of Ragnaros"),Arrays.asList(
                i -> new ItemWrapper(i)
        ));

        put(Item.make("Backstage passes to a TAFKAL80ETC concert"),Arrays.asList(

            i -> new ItemWrapper(i.decSellIn(),true),

            i -> (isQualityLessThenMax(i) && isSellInNegative(i))? new ItemWrapper(i.zeroQuality()):ItemWrapper.nextRule(i),

            i -> (isQualityLessThenMax(i) && i.sellIn < 6)? new ItemWrapper(i.incQuality().incQuality().incQuality()):ItemWrapper.nextRule(i),

            i -> (isQualityLessThenMax(i) && i.sellIn < 11)? new ItemWrapper(i.incQuality().incQuality()):ItemWrapper.nextRule(i),

            i -> (isQualityLessThenMax(i))? new ItemWrapper(i.incQuality()):ItemWrapper.nextRule(i),

            i -> new ItemWrapper(i)
        ));

        put(Item.make("Regular"),Arrays.asList(

            i -> new ItemWrapper(i.decSellIn(),true),

            i -> (isQualityPositive(i) && isSellInNegative(i))? new ItemWrapper(i.decQuality().decQuality()):ItemWrapper.nextRule(i),

            i -> (isQualityPositive(i))? new ItemWrapper(i.decQuality()):ItemWrapper.nextRule(i),

            i -> new ItemWrapper(i)
        ));

    }};

    public static Item execute(final Item i){
        if(rules.containsKey(i))return applyRule(rules.get(i),i);
        else return applyRule(rules.get(Item.make("Regular")),i);
    }

    static Item applyRule(final List<Rule> rules, final Item i){
        ItemWrapper itemWrapper = rules.get(0).apply(i);
        if(itemWrapper.goNext)
           return  applyRule(rules.subList(1,rules.size()), itemWrapper.item);
        else
        return itemWrapper.item;
    }

    private static boolean isSellInNegative(Item item) {
        return item.sellIn < MIN_SELLIN;
    }

    private static boolean isQualityPositive(Item item) {
        return item.quality > MIN_SELLIN;
    }

    private static boolean isQualityLessThenMax(Item item){
        return item.quality < MAX_QUALITY;
    }

}
