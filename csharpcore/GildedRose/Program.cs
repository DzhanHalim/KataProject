using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.GildedRoseKata;
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
             
            Console.WriteLine("OMGHAI!");

            List<Item> Items = new List<Item>{
                new Item {Id=1, Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Id=2,Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Id=3,Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Id=4,Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Id=5,Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Id=6,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Id=7,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Id=8,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Id=9,Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            ItemManager itemManager = new ItemManager(new InMemoryItemsDal(Items));
            //var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                //app.UpdateQuality();
                itemManager.UpdateQuality();
            }
        }
    }
}
