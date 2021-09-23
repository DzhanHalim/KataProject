using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Results;
using DataAccess.Abstract;
using Entities.Concrete.GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace Business.Concrete
{
    public class ItemManager : IItemService
    {
        IItemsDal _itemDal;
        List<Item> _items;
        public ItemManager(IItemsDal itemDal)
        {
            _itemDal = itemDal;
             
        }

        public List<Item> GetAll()
        {
            return _itemDal.GetAll();
        }

        public IResult UpdateQuality()
        {
             
            List<Item> items = _itemDal.GetAll();

            foreach (var item in items)
            {

           
            IResult result = BusinessRule.Run(CheckItemQualityMin(item), 
                CheckItemQualityMax(item));
            
            _itemDal.UpdateQuality(item);
            }
            return new SuccessResult("");
        }


        // BusinessRules 

        private IResult CheckItemsName(Item item)
        {
            List<Item> Items = _itemDal.GetAll();
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
            }
                
        }
        private IResult CheckItemQualityMin(Item item)
        {
            if (item.Quality < 0)
            {
                return new ErrorResult(Messages.ItemQualityNegative);
            }
            return null;

        }
        private IResult CheckItemQualityMax(Item item)
        {
            if (item.Quality > 50)
            {
                return new ErrorResult(Messages.ItemQualityMax);
            }
            return null;

        }
        private IResult CheckSellingDate(Item item)
        {
            if (item.Quality < 0)
            {
                return new ErrorResult(Messages.ItemQualityNegative);
            }
            return null;

        }



    }
}
