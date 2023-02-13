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
                if (IsBrie(item) || IsConcertTicket(item))
                {
                    IncreaseQuality(item, 1);

                    if (IsConcertTicket(item))
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseQuality(item, 1);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQuality(item, 1);
                        }
                    }
                }
                else
                {
                    DecreaseQuality(item, 1);
                }

                DecreaseSellIn(item);

                if (item.SellIn < 0)
                {
                    if (IsBrie(item))
                    {
                        IncreaseQuality(item, 1);
                    }
                    else
                    {
                        if (IsConcertTicket(item))
                        {
                            DecreaseQuality(item, item.Quality);
                        }
                        else
                        {
                            DecreaseQuality(item, 1);
                        }
                    }
                }
            }
        }

        private bool IsBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsConcertTicket(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsNotMinimumQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool IsNotMaxQuality(Item item)
        {
            return item.Quality < 50;
        }

        private void DecreaseSellIn(Item item)
        {
            if (IsNotLegendary(item))
            {
                item.SellIn -= 1;
            }
        }

        private void DecreaseQuality(Item item, int itemQuality)
        {
            if (IsNotMinimumQuality(item))
            {
                if (IsNotLegendary(item))
                {
                    item.Quality -= itemQuality;
                }
            }
        }

        private void IncreaseQuality(Item item, int itemQuality)
        {
            if (IsNotMaxQuality(item))
            {
                item.Quality += itemQuality;
            }
        }

        private static bool IsNotLegendary(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
