using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose(IList<Item> items)
    {
        const string AgedBrie = "Aged Brie";
        const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        const string BackstagePassesToATafkal80etcConcert = "Backstage passes to a TAFKAL80ETC concert";

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != AgedBrie && items[i].Name != BackstagePassesToATafkal80etcConcert)
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != Sulfuras)
                        {
                            items[i].Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality += 1;

                        if (items[i].Name == BackstagePassesToATafkal80etcConcert)
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality += 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != Sulfuras)
                {
                    items[i].SellIn -= 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != AgedBrie)
                    {
                        if (items[i].Name != BackstagePassesToATafkal80etcConcert)
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != Sulfuras)
                                {
                                    items[i].Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality -= items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality += 1;
                        }
                    }
                }
            }
        }
    }
}