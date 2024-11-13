using System.Collections.Generic;
using GildedRose.Models;
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

                if (isSulfuras)
                    continue;

                if (isBackstagePass)
                {
                    var pass = new BackstagePass(items[i]);
                    pass.UpdateItemQuality();
                    items[i] = pass;
                    continue; 
                }

                if (isAgedBrie)
                {
                    var brie = new AgedBrie(items[i]);
                    brie.UpdateItemQuality();
                    items[i] = brie;
                    continue;
                }

                var item = new BasicItem(items[i]);
                item.UpdateItemQuality();
                items[i] = item;
            }
        }
    }
}