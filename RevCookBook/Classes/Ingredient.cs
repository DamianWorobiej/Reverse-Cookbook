using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.Classes
{
    public class Ingredient
    {
        private int id;
        private string name;
        private int categoryID;
        private bool vegan;
        private bool lactosis;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public bool Vegan { get => vegan; set => vegan = value; }
        public bool Lactosis { get => lactosis; set => lactosis = value; }

        public Ingredient(int id, string name, int categoryID, string vegan, string lactosis)
        {
            this.id = id;
            this.name = name;
            this.categoryID = categoryID;
            this.vegan = (vegan == "False") ? false : true;
            this.lactosis = (lactosis == "False") ? false : true;
        }

        
    }
}
