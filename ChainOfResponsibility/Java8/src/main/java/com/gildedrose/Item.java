package com.gildedrose;

public class Item {

    public final String name;
    public final int sellIn;
    public final int quality;

    public Item(String name, int sellIn, int quality) {
        this.name = name;
        this.sellIn = sellIn;
        this.quality = quality;
    }

    public static Item make(String name){
        return new Item(name,0,0);
    }

    public Item sellIn(int sellIn) {
        return new Item(name,sellIn,quality);
    }

    public Item quantity(int quality) {
        return new Item(name,sellIn,quality);
    }

    public Item incQuality(){
        return quantity(this.quality + 1);
    }

    public Item decSellIn() {
        return sellIn( this.sellIn - 1);
    }

    public Item decQuality() {
        return quantity(this.quality - 1);
    }

    public Item zeroQuality() {
        return quantity(this.quality - this.quality);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        return name.equals(((Item) o).name);
    }

    @Override
    public int hashCode() {
        return name != null ? name.hashCode() : 0;
    }

    @Override
    public String toString() {
        return this.name + ", " + this.sellIn + ", " + this.quality;
    }


}
