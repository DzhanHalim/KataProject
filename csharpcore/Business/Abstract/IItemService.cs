using Business.Results;
using Entities.Concrete.GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IItemService
    {
        List<Item> GetAll();
        IResult UpdateQuality();
    }
}
