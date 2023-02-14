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
                    continue;

                if (IsBrie(item))
                {
                    UpdateBrieQuality(item);
                }
                else if (IsConcertTicket(item))
                {
                    UpdateConcertTicketQuality(item);
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

            if (IsExpired(item))
                DecreaseQuality(item, 1);
        }

        private void UpdateConcertTicketQuality(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11)
                IncreaseQuality(item);

            if (item.SellIn < 6)
                IncreaseQuality(item);

            if (IsExpired(item))
                DecreaseQuality(item, item.Quality);
        }

        private void UpdateBrieQuality(Item item)
        {
            IncreaseQuality(item);

            if (IsExpired(item))
                IncreaseQuality(item);
        }

        private bool IsExpired(Item item)
        {
            return item.SellIn < 1;
        }

        private bool IsConcertTicket(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsBrie(Item item)
        {
            return item.Name == "Aged Brie";
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
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private void DecreaseQuality(Item item, int itemQuality)
        {
            if (item.Quality > 0)
            {
                item.Quality -= itemQuality;
            }
        }
    }
}
