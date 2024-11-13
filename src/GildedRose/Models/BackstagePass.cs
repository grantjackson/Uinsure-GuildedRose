using GildedRoseKata;

namespace GildedRose.Models;

public sealed class BackstagePass(Item item) : BasicItem(item)
{
    protected override int QualityIncrement => 1;
    
    public override void UpdateItemQuality()
    {
        if (Quality < MaximumQuality)
        {
            Quality += QualityIncrement;

            if (SellIn < 11)
            {
                if (Quality < MaximumQuality)
                {
                    Quality += QualityIncrement;
                }
            }

            if (SellIn < 6)
            {
                if (Quality < MaximumQuality)
                {
                    Quality += QualityIncrement;
                }
            }
        }

        SellIn -= 1;

        if (SellIn < 0) Quality = 0;
    }
}