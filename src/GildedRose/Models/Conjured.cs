using GildedRoseKata;

namespace GildedRose.Models;

public class Conjured(Item item) :  BasicItem(item)
{
    protected override int QualityIncrement => -2;
}