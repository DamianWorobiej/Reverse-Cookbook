using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.Classes
{
    public class Category
    {
        private string name;
        private int id;

        
        public int ID { get => id; }
        public string Name { get => name; set => name = value; }

        public Category(string name, int ID)
        {
            this.name = name;
            id = ID;
        }
    }
}
