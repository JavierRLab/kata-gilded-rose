using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (!IsLegendary(item))
                        {
                            DecreaseQuality(item, 1);
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        IncreaseQuality(item);

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    IncreaseQuality(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    IncreaseQuality(item);
                                }
                            }
                        }
                    }
                }

                if (!IsLegendary(item))
                {
                    DecreaseSellIn(item);
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsLegendary(item))
                                {
                                    DecreaseQuality(item, 1);
                                }
                            }
                        }
                        else
                        {
                            DecreaseQuality(item, item.Quality);
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQuality(item);
                        }
                    }
                }
            }
        }

        private bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

        private void DecreaseQuality(Item item, int itemQuality)
        {
            item.Quality -= itemQuality;
        }
    }
}
