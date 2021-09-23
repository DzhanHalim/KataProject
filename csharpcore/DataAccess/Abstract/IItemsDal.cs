using Entities.Concrete.GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.Abstract
{
  public  interface IItemsDal
    {
        List<Item> GetAll();
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
        List<Item> GetByName(string name);
    }
}
