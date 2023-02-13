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
                if (IsLegendary(item))
                {
                    continue;
                }

                if (IsBrie(item))
                {
                    UpdateBrieQuality(item);
                }
                else if (IsConcertTicket(item))
                {
                    UpdateTicketQuality(item);
                }
                else
                {
                    UpdateNormalItemQuality(item);
                }
                
                DecreaseSellIn(item);

            }
        }

        private void UpdateNormalItemQuality(Item item)
        {
            DecreaseQuality(item, 1);

            if (IsExpired(item, 1))
            {
                DecreaseQuality(item, 1);
            }
        }

        private void UpdateTicketQuality(Item item)
        {
            if (IsExpired(item, 1))
            {
                DecreaseQuality(item, item.Quality);
            }
            else
            {
                IncreaseQuality(item, 1);

                if (IsExpired(item, 11))
                {
                    IncreaseQuality(item, 1);
                }

                if (IsExpired(item, 6))
                {
                    IncreaseQuality(item, 1);
                }
            }
        }

        private void UpdateBrieQuality(Item item)
        {
            IncreaseQuality(item, 1);
            if (IsExpired(item, 1))
            {
                IncreaseQuality(item, 1);
            }
        }

        private static bool IsExpired(Item item, int daysLeft)
        {
            return item.SellIn < daysLeft;
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
            item.SellIn -= 1;
        }

        private void DecreaseQuality(Item item, int itemQuality)
        {
            if (IsNotMinimumQuality(item))
            {
                item.Quality -= itemQuality;
            }
        }

        private void IncreaseQuality(Item item, int itemQuality)
        {
            if (IsNotMaxQuality(item))
            {
                item.Quality += itemQuality;
            }
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
