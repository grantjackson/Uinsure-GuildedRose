using Xunit;
using System.Collections.Generic;
using GildedRose;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory]
    [InlineData(Constants.AgedBrie)]
    [InlineData(Constants.Conjured)]
    [InlineData("other")]
    public void QualityIsNeverNegative(string itemName)
    {
        IList<Item> items = [new() { Name = itemName, SellIn = 5, Quality = 0 }];
        GildedRose.GildedRose app = new(items);
        app.UpdateQuality();
        app.UpdateQuality();
        Assert.InRange(items[0].Quality, 0, 50);
    }
        
    [Theory]
    [InlineData(Constants.BackstagePass)]
    public void QualityIsNeverOver50(string itemName)
    {
        IList<Item> items = [new() { Name = itemName, SellIn = 5, Quality = 50 }];
        GildedRose.GildedRose app = new(items);
        app.UpdateQuality();
        app.UpdateQuality();
        Assert.InRange(items[0].Quality, 0, 50);
    }
        
    [Fact]
    public void SulfurasNeverChangesQualityOrSellIn()
    {
        IList<Item> items = [new() { Name = Constants.Sulfuras, SellIn = 5, Quality = 10 }];
        GildedRose.GildedRose app = new(items);

        Assert.Equal(10, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);
		
        app.UpdateQuality();
        Assert.Equal(10, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(10, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);
    }
    
    [Fact]
    public void AgedBrie_IncreasesInValue()
    {
        IList<Item> items = [new() { Name = Constants.AgedBrie, SellIn = 5, Quality = 10 }];
        GildedRose.GildedRose app = new(items);

        Assert.Equal(10, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(11, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(12, items[0].Quality);
        Assert.Equal(3, items[0].SellIn);
    }
    
    [Fact]
    public void AgedBrie_IncreasesBy2InValueWhenSellInDateHasPassed()
    {
        IList<Item> items = [new() { Name = Constants.AgedBrie, SellIn = 1, Quality = 10 }];
        GildedRose.GildedRose app = new(items);

        Assert.Equal(10, items[0].Quality);
        Assert.Equal(1, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(11, items[0].Quality);
        Assert.Equal(0, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(13, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);

        app.UpdateQuality();
        Assert.Equal(15, items[0].Quality);
        Assert.Equal(-2, items[0].SellIn);
    }
    
    [Fact]
    public void OnceSellByHasPassed_QualityDropsTwiceAsFast()
    {
        IList<Item> items = [new() { Name = "itemName", SellIn = 2, Quality = 5 }];
        GildedRose.GildedRose app = new(items);
		
        app.UpdateQuality();

        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(4, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(3, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(1, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(-2, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
    
    [Fact]
    public void Conjured_QualityDropsTwiceAsFastAsBasicItems()
    {
        IList<Item> items = [new() { Name = Constants.Conjured, SellIn = 2, Quality = 10 }];
        GildedRose.GildedRose app = new(items);

        app.UpdateQuality();

        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(2, items[0].Quality);
    }
    
    [Fact]
    public void BackStagePasses_ValueIncreasesBy2AtBetween5And10Days()
    {
        IList<Item> items = [new() { Name = Constants.BackstagePass, SellIn = 11, Quality = 5 }];
        GildedRose.GildedRose app = new(items);

        app.UpdateQuality();

        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(8, items[0].SellIn);
        Assert.Equal(10, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(7, items[0].SellIn);
        Assert.Equal(12, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(6, items[0].SellIn);
        Assert.Equal(14, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(5, items[0].SellIn);
        Assert.Equal(16, items[0].Quality);
    }

    [Fact]
    public void BackStagePasses_ValueIncreasesBy3At5DaysOrLessRemaining()
    {
        IList<Item> items = [new() { Name = Constants.BackstagePass, SellIn = 5, Quality = 3 }];
        GildedRose.GildedRose app = new(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(3, items[0].SellIn);
        Assert.Equal(9, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(2, items[0].SellIn);
        Assert.Equal(12, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(15, items[0].Quality);

        app.UpdateQuality();

        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }

    [Fact]
    public void BackStagePasses_QualityDropsTo0WhenNegativeSellIn()
    {
        IList<Item> items = [new() { Name = Constants.BackstagePass, SellIn = 0, Quality = 10 }];

        GildedRose.GildedRose app = new(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
}