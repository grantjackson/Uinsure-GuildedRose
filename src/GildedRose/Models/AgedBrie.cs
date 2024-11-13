using GildedRoseKata;

namespace GildedRose.Models;

public sealed class AgedBrie(Item item) : BasicItem(item)
{
    public override void UpdateItemQuality()
    {
        if (Quality < 50)
        {
            Quality += 1;
        }

        SellIn -= 1;

        if (SellIn >= 0) return;

        if (Quality < 50)
        {
            Quality += 1;
        }
    }
}