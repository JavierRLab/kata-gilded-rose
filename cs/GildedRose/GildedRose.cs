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
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        UpdateBrieQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateConcertTicketQuality(item);
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
