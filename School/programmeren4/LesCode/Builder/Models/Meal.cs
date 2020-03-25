using System;
using System.Collections.Generic;
using System.Text;
using Builder.Interfaces;
using System.Linq;

namespace Builder.Models
{
    class Meal
    {
        private List<IItem> Items = new List<IItem>();
        public void AddItem(IItem itemToAdd)
        {
            Items.Add(itemToAdd); 
        }

        public float GetCosts()
        {
            return Items.Sum(i => i.Price);
        }
        public void ShowItems() 
        {
            foreach (var item in Items)
            {
                Console.WriteLine("Item: {0}, Packing: {1}, Price {2}", item.Name, item.Packing.Pack, item.Price.ToString("C"));
            }
        }
    }
}
