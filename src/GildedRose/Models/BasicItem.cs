using GildedRoseKata;

namespace GildedRose.Models;

internal class BasicItem : Item
{
    protected virtual int QualityIncrement => -1;
    protected const int MinimumQuality = 0;
    private const int MaximumQuality = 50;
    
    public BasicItem(Item item)
    {
        Name = item.Name;
        Quality = item.Quality;
        SellIn = item.SellIn;
    }
    
    internal virtual void UpdateItemQuality()
    {
        ModifyQuality(QualityIncrement);
        
        SellIn -= 1;

        if (SellIn >= 0) 
            return;

        ModifyQuality(QualityIncrement);
    }
    
    protected void ModifyQuality(int value)
    {
        Quality += value;

        if (Quality > MaximumQuality) 
            Quality = MaximumQuality;

        if (Quality < MinimumQuality) 
            Quality = MinimumQuality;
    }
}