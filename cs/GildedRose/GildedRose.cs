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


                if (IsBrie(item) || IsConcertTicket(item))
                {
                    if (item.Quality < 50)
                    {
                        IncreaseQuality(item);

                        if (IsConcertTicket(item))
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
                else
                {
                    if (item.Quality > 0)
                    {
                        DecreaseQuality(item, 1);
                    }
                }

                DecreaseSellIn(item);

                if (item.SellIn < 0)
                {
                    if (IsBrie(item))
                    {
                        if (item.Quality < 50)
                        {
                            IncreaseQuality(item);
                        }
                    }
                    else
                    {
                        if (IsConcertTicket(item))
                        {
                            DecreaseQuality(item, item.Quality);
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                DecreaseQuality(item, 1);
                            }
                        }
                    }
                }
            }
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
            item.Quality += 1;
        }

        private void DecreaseQuality(Item item, int itemQuality)
        {
            item.Quality -= itemQuality;
        }
    }
}
