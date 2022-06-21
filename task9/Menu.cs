using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    internal class Menu
    {

        private List<Dish> _dishes;
        public Dish this[int index]
        {
            get => _dishes[index];  
        }
        public int Length => _dishes.Count;  
        public Menu()
        {
            _dishes = new List<Dish>();
        }
        public Menu(List<Dish> dishes) :this()
        {
            _dishes = dishes;
        }
        public void Add(Dish dish) 
        {
            _dishes.Add(dish);
        }
    }
}
