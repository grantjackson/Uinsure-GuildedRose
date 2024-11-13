using GildedRose.Models;
using GildedRoseKata;

namespace GildedRose;

public static class ItemFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
    
    public static BasicItem GetItem(Item item) => item.Name switch
    {
        AgedBrie => new AgedBrie(item),
        Sulfuras => new Sulfuras(item),
        BackstagePass => new BackstagePass(item),
        _ => new BasicItem(item)
    };
}