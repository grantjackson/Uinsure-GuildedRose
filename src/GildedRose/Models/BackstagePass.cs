using GildedRoseKata;

namespace GildedRose.Models;

internal sealed class BackstagePass(Item item) : BasicItem(item)
{
    protected override int QualityIncrement => 1;

    internal override void UpdateItemQuality()
    {
        var increment = SellIn switch
        {
            < 6 => QualityIncrement * 3,
            < 11 => QualityIncrement * 2,
            >= 11 => QualityIncrement * 1
        };
        
        ModifyQuality(increment);
        
        SellIn -= 1;

        if (SellIn < 0) 
            Quality = MinimumQuality;
    }
}