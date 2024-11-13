using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose(IList<Item> items)
    {
        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                var item = ItemFactory.GetItem(items[i]);
                item.UpdateItemQuality();
                items[i] = item;
            }
        }
    }
}