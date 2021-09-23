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

            for(int i = 0; i < items.Count; i++)
            {

             

           
            IResult result = BusinessRule.Run(CheckItemsNameAgedBrie(items[i]), CheckItemsNameBackstage(items[i]),
               CheckItemsName(items[i]), CheckItemsNameConjured(items[i]));
                 
            
            _itemDal.UpdateQuality(items[i]);
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
                    item.Quality++;
                    item.SellIn--;
                     
                }
                else if(item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
            }
            return new SuccessResult();

             
        }
        private IResult CheckItemsNameConjured(Item item)
        {
            if (item.Name == "Conjured Mana Cake" && item.Quality>0 && item.SellIn>0)
            {
                 
                    item.Quality = item.Quality- 2;
                item.SellIn--;


            }
            return new SuccessResult();

        }
        private IResult CheckItemsName(Item item)
        {
            
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" 
                && item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Conjured Mana Cake" && item.Quality > 0 && item.Quality < 50)
            {
                item.SellIn--;
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
            return new SuccessResult();


        }

        private IResult CheckItemsNameBackstage(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50)
            {
                if (item.SellIn > 0)
                {
                    item.SellIn--;
                }
              
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
            return new SuccessResult();
           

        }
         
        
        
         



    }
}
