using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose.GildedRose app = new(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }
    }
}
