using GildedRoseKata;

namespace GildedRose.Models;

internal sealed class AgedBrie(Item item) : BasicItem(item)
{
    protected override int QualityIncrement => 1;
}