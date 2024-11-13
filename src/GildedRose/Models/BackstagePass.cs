using GildedRoseKata;

namespace GildedRose.Models;

public sealed class BackstagePass(Item item) : BasicItem(item)
{
    protected override int QualityIncrement => 1;

    public override void UpdateItemQuality()
    {
        ModifyQuality(QualityIncrement);

        if (SellIn < 11)
        {
            ModifyQuality(QualityIncrement);
        }

        if (SellIn < 6)
        {
            ModifyQuality(QualityIncrement);
        }

        SellIn -= 1;

        if (SellIn < 0) Quality = MinimumQuality;
    }
}