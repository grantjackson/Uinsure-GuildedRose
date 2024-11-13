using GildedRoseKata;

namespace GildedRose.Models;

public sealed class Sulfuras(Item item): BasicItem(item)
{
    public override void UpdateItemQuality(){}
}