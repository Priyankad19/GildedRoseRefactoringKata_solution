package com.gildedrose;

import java.util.Arrays;

public class GildedRose {
    public Item[] items;

    public GildedRose(Item[] items) {
        this.items = items;
    }

    public void updateQuality() {
        items = Arrays.asList(items)
                .stream()
                .map(i -> UpdateItemStrategies.execute(i))
                .toArray(Item[]::new);
    }
}
