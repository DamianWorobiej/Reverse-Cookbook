using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.Classes
{
    public class Dish
    {
        private int id;
        private string name;
        private Dictionary<Ingredient, string> amount;
        private string time;
        private bool vegan;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }
        public Dictionary<Ingredient, string> Amount { get => amount; set => amount = value; }
        public string Time { get => time; set => time = value; }
        public bool Vegan { get => vegan; set => vegan = value; }


        public Dish(int id, string name, Dictionary<Ingredient, string> amount, string time)
        {
            this.id = id;
            this.name = name;
            this.amount = new Dictionary<Ingredient, string>();
            foreach (var item in amount)
            {
                this.amount.Add(item.Key, item.Value);
            }
            this.time = time;
            vegan = CheckVegan();
        }

        
        private bool CheckVegan()
        {
            foreach (var item in amount)
            {
                if (item.Key.Vegan) return true;
            }
            return false;
        }
    }
}
