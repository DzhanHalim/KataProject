using Entities.Abstract;
using System;
namespace Entities.Concrete.GildedRoseKata
{
    public class Item :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellIn { get; set; } 
        public int Quality { get; set; }
    }
}
