﻿using System.Collections.Generic;

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
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        UpdateBrieQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateTicketQuality(item);
                        break;
                    default:
                        UpdateNormalItemQuality(item);
                        break;
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
    }
}
