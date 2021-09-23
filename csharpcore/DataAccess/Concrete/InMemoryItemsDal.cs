using DataAccess.Abstract;
using Entities.Concrete.GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryItemsDal : IItemsDal
    {
        List<Item> _items;

        public InMemoryItemsDal(List<Item> items)
        {
            _items = items;
            
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Delete(Item item)
        {
            

            Item itemToDelete = null;
            //LINQ
            itemToDelete = _items.SingleOrDefault(i => i.Name == item.Name);
            //foreach(var i in _items)
            //{
            //    if( item.Name== i.Name)
            //    {
            //        itemToDelete = i;
            //    }
            //}
            _items.Remove(itemToDelete);
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public List<Item> GetByName(string name)
        {
            return _items.Where(i => i.Name == name).ToList();
        }

        public void Update(Item item)
        {
            Item itemToUpdate = _items.SingleOrDefault(i => i.Name == item.Name);
            itemToUpdate.Name = item.Name;
            itemToUpdate.Quality = item.Quality;
            itemToUpdate.SellIn = item.SellIn;
        }

        public void UpdateQuality(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
