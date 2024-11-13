﻿using System.Collections.Generic;
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
                var isAgedBrie = items[i].Name == AgedBrie;
                var isBackstagePass = items[i].Name == BackstagePassesToATafkal80etcConcert;
                var isSulfuras = items[i].Name == Sulfuras;

                if (isAgedBrie || isBackstagePass)
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality += 1;

                        if (isBackstagePass)
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
                else
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != Sulfuras)
                        {
                            items[i].Quality -= 1;
                        }
                    }
                }

                if (isSulfuras)
                {
                }
                else
                {
                    items[i].SellIn -= 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (isAgedBrie)
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality += 1;
                        }
                    }
                    else
                    {
                        if (isBackstagePass)
                        {
                            items[i].Quality -= items[i].Quality;
                        }
                        else
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != Sulfuras)
                                {
                                    items[i].Quality -= 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}