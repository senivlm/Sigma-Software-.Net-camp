using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    internal static class MenuService
    {
        static public bool TryGetMenuTotalSum(Menu menu, PriceKurant priceKurant, out double menuTotalSum)
        {
            menuTotalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceKurant, out double sumPrice))
                {
                    return false;
                }
                menuTotalSum+=sumPrice;
            }
            return true;
        }
        static public bool TryGetDishPrice(Dish dish, PriceKurant priceKurant, out double sumPrice)
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!priceKurant.TryGetProductPrice(key, out double productPrice))
                {
                    return false;
                }
                sumPrice += productPrice * dish[key];
            }
            return true;          
           
        }
    }
}
