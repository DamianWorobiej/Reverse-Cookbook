using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook.Classes
{
    public class Amount
    {
        private Ingredient ingredient;
        private string quantity;

        public Ingredient Ingredient { get => ingredient; set => ingredient = value; }
        public string Quantity { get => quantity; set => quantity = value; }

        public Amount(Ingredient ingredient, string quantity)
        {
            this.quantity = quantity;
            this.ingredient = ingredient;
        }

        
    }
}
