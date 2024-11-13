using GildedRoseKata;

namespace GildedRose.Models;

public sealed class AgedBrie(Item item) : BasicItem(item)
{
    protected override int QualityIncrement => 1;
}