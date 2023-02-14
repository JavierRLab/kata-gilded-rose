using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace XUnit.Coverlet;

public class CharacterizationGildedRose_Tests
{
    
    
    [Fact (DisplayName = "At the end of each day our system lowers both values for every item")]
    public void DefaultItem()
    {
        Item defaultItem = new Item { Name = "default", SellIn = 20, Quality = 10 };
        IList<Item> Items = new List<Item> { defaultItem };
        GildedRose shop = new GildedRose(Items);

        shop.UpdateQuality();
        
        AssertItem(defaultItem, 19, 9);
    }

    [Fact(DisplayName = "Once the sell by date has passed, Quality degrades twice as fast")]
    public void QualityDegradesTwice()
    {
        Item itemWithPassedSellDate = new Item {Name = "default", SellIn = -1, Quality = 10 };
        IList<Item> Items = new List<Item> { itemWithPassedSellDate };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();
        
        AssertItem(itemWithPassedSellDate, -2, 8);
    }
    
    
    [Fact(DisplayName = "The Quality of an item is never negative")]
    public void QualityIsNeverNegative()
    {
        Item itemWith0Quality = new Item {Name = "default", SellIn = 5, Quality = 0 };
        IList<Item> Items = new List<Item> { itemWith0Quality };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();
        
        AssertItem(itemWith0Quality, 4, 0);
    }

    [Fact(DisplayName = "Aged Brie actually increases in Quality the older it gets")]
    public void AgedBrieIncreaseQuality()
    {
        Item itemAgedBrie = new Item {Name = "Aged Brie", SellIn = 5, Quality = 4 };
        IList<Item> Items = new List<Item> { itemAgedBrie };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();
        
        AssertItem(itemAgedBrie, 4, 5);
    }
    
    [Fact(DisplayName = "Aged Brie with passed sellIn actually increases in Quality the older it gets")]
    public void AgedBrieWithPassedSellInIncreaseQuality()
    {
        Item itemAgedBrie = new Item {Name = "Aged Brie", SellIn = -4, Quality = 4 };
        IList<Item> Items = new List<Item> { itemAgedBrie };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();
        
        AssertItem(itemAgedBrie, -5, 6);
    }
    
    [Fact(DisplayName = "The Quality of an item is never more than 50")]
    public void QualityOfItemIsNeverMoreThen50()
    {
        Item itemAgedBrieWith50Quality = new Item {Name = "Aged Brie", SellIn = 5, Quality = 50 };
        IList<Item> Items = new List<Item> { itemAgedBrieWith50Quality };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();

        AssertItem(itemAgedBrieWith50Quality, 4, 50);
    }
    
    
    [Fact(DisplayName = "Sulfuras, being a legendary item, never has to be sold or decreases in Quality")]
    public void LegendaryItemHasNeverBeingSoldOrDecreasesQuality()
    {
        Item legendaryItem = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        IList<Item> Items = new List<Item> { legendaryItem };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();
        
        AssertItem(legendaryItem, 0, 80);
    }
    
    [Fact(DisplayName = "Backstage passes, like aged brie, increases in Quality as its SellIn value approaches;\n" +
                        "Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but\n" +
                        "Quality drops to 0 after the concert")]
    public void BackstagesPasesDays()
    {
        Item backstagePassWithSellIn15Days = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 15, 
            Quality = 20
        };
        Item backstagePassWithSellIn10Days = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 10, 
            Quality = 20
        };
        Item backstagePassWithSellIn5Days = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 5, 
            Quality = 20
        };
        Item backstagePassWithSellIn0Days = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 0, 
            Quality = 20
        };

        IList<Item> Items = new List<Item>
        {
            backstagePassWithSellIn15Days, 
            backstagePassWithSellIn10Days, 
            backstagePassWithSellIn5Days, 
            backstagePassWithSellIn0Days
        };
        GildedRose shop = new GildedRose(Items);
        
        shop.UpdateQuality();

        AssertItem(backstagePassWithSellIn15Days, 14, 21);
        AssertItem(backstagePassWithSellIn10Days, 9, 22);
        AssertItem(backstagePassWithSellIn5Days, 4, 23);
        AssertItem(backstagePassWithSellIn0Days, -1, 0);
    }
    
    private static void AssertItem(Item item, int expectedSellIn, int expectedQuality)
    {
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}