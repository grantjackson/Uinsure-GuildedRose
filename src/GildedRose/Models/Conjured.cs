using GildedRoseKata;

namespace GildedRose.Models;

internal sealed class Conjured(Item item) :  BasicItem(item)
{
    protected override int QualityIncrement => -2;
}