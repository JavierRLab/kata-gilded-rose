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
                if (item.Name != "Aged Brie" && !IsConcertTicket(item))
                {
                    if (IsNotMinimumQuality(item))
                    {
                        if (IsNotLegendary(item))
                        {
                            DecreaseQuality(item, 1);
                        }
                    }
                }
                else
                {
                    if (IsNotMaxQuality(item))
                    {
                        IncreaseQuality(item);

                        if (IsConcertTicket(item))
                        {
                            
                            if (item.SellIn < 11)
                            {
                                if (IsNotMaxQuality(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (IsNotMaxQuality(item))
                                {
                                    IncreaseQuality(item);
                                }
                            }
                        }
                    }
                }

                DecreaseSellIn(item);

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (!IsConcertTicket(item))
                        {
                            if (IsNotMinimumQuality(item))
                            {
                                if (IsNotLegendary(item))
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
                        if (IsNotMaxQuality(item))
                        {
                            IncreaseQuality(item);
                        }
                    }
                }
            }
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
            item.Quality -= itemQuality;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

        private static bool IsNotLegendary(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
