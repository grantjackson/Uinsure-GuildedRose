using GildedRoseKata;

namespace GildedRose.Models;

public class BasicItem : Item
{
    private const int MinimumQuality = 0;

    public BasicItem(Item item)
    {
        Name = item.Name;
        Quality = item.Quality;
        SellIn = item.SellIn;
    }
    
    public virtual void UpdateItemQuality()
    {
        if (Quality > MinimumQuality)
        {
            Quality -= 1;
        }

        SellIn -= 1;

        if (SellIn >= 0) 
            return;

        if (Quality <= MinimumQuality) 
            return;

        Quality -= 1;
    }
}