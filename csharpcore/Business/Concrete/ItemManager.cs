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

           
            IResult result = BusinessRule.Run(CheckItemsNameAgedBrie(item), CheckItemsNameBackstage(item),
               CheckItemsName(item));
                 
            
            _itemDal.UpdateQuality(item);
            }
            return new SuccessResult("");
        }


        // BusinessRules 

        
        private IResult CheckItemsNameAgedBrie(Item item)
        {
           if(item.Name == "Aged Brie")
            {
                if (item.Quality < 50 && item.SellIn >0)
                {
                    item.Quality = item.Quality + 1;
                     
                }
                else if(item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
            }
            return null;

        }
        private IResult CheckItemsName(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" 
                && item.Name != "Sulfuras, Hand of Ragnaros" && item.Quality > 0 && item.Quality < 50)
            {
                if (item.SellIn < 0 & item.Quality>0)
                {
                    if (item.Quality - 2 > 0)
                    {
                        item.Quality -= 2;

                    }
                    item.Quality = 0;
 
                }
                else
                {
                    item.Quality++;
                }
                
                    
                
            }
            return null;

        }
         
            private IResult CheckItemsNameBackstage(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn <= 10 && item.SellIn <= 5 && item.SellIn > 0) 
                {
                    
                        item.Quality +=2;
                     
                }

              else  if (item.SellIn <=10 && item.SellIn > 0)
                {
                     
                        item.Quality += 1;
                     
                }
                 if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
            }
            return null;
           

        }
         
        
        
         



    }
}
