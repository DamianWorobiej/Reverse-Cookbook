using RevCookBook.Classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Collections.ObjectModel;


namespace RevCookBook.Handlers
{
    public class DishHandler : DBHandler
    {
        public List<Dish> DList;
        private IngredientHandler ih;
        public bool Close;

        public DishHandler()
        {
            ih = new IngredientHandler();
            RefreshCollection();
        }

       
        protected override void RefreshCollection()
        {
            DList = new List<Dish>();

            var query = "select * from Dishes;";
            var Hh = GetTableData(query);

            foreach (var dish in Hh)
            {
                var separator1 = new char[] { ',' };
                var ingList = dish[2].Split(separator1, StringSplitOptions.RemoveEmptyEntries);
                var separator2 = new char[] { '|' };
                var amountDict = new Dictionary<Ingredient, string>();
                foreach (var ing in ingList)
                {
                    var Hh2 = ing.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                    if (Hh2.Count()==2) amountDict.Add((Ingredient)ih.GetItem(Convert.ToInt32(Hh2[0])), Hh2[1]);
                    else amountDict.Add((Ingredient)ih.GetItem(Convert.ToInt32(Hh2[0])), "");

                }
                DList.Add(new Dish(Convert.ToInt32(dish[0]), dish[1], amountDict, dish[3]));
            }
        }

        #region Database Manipulation

        public override void UpdateData(object input)
        {
            try
            {
                Dish data = (Dish)input;
                if (verifyExistance(data))
                {
                    string amount = null;
                    foreach (var ingredient in data.Amount)
                    {
                        amount += ingredient.Key.ID + "|" + ingredient.Value + ",";
                    }
                    var query = "update Dishes set Name = '" + data.Name + "', Amount = '" + amount + "', Time = '" + data.Time + "', Vegan = '" + data.Vegan.ToString() + "' where ID = " + data.ID + ";";
                    ExecuteNonSelectQuery(query);
                    RefreshCollection();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Problem z aktualizacją dania: " + e.Message);
            }
        }

        public override void InsertData(object input)
        {
            try
            {
                Dish data = (Dish)input;
                if (verifyExistance(data))
                {
                    string amount = null;
                    foreach (var ingredient in data.Amount)
                    {
                        amount += ingredient.Key.ID + "|" + ingredient.Value + ",";
                    }
                    var query = "insert into Dishes (Name, Amount, Time, Vegan) values ('" + data.Name + "', '" + amount + "', '" + data.Time + "', '" + data.Vegan.ToString() + "');";
                    ExecuteNonSelectQuery(query);
                    RefreshCollection();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Problem z dodawaniem dania: " + e.Message);
            }
        }

        public override void DeleteData(int id)
        {
            try
            {
                var query = "delete from Dishes where ID = " + id + ";";
                ExecuteNonSelectQuery(query);
                RefreshCollection();
                Close = true;
            }
            catch (Exception e)
            {
                throw new Exception("Problem z usuwaniem dania: " + e.Message);
            }
        }

        private bool verifyExistance(Dish data)
        {
            if (data.ID != 0)
            {
                foreach (var dish in DList)
                {
                    if (dish.ID != data.ID && dish.Name == data.Name) throw new Exception("W bazie znajduje się już danie o podanej nazwie");
                }
                return true;
            }
            else
            {
                foreach (var dish in DList)
                {
                    if (dish.Name == data.Name) throw new Exception("W bazie znajduje się już danie o podanej nazwie");
                }
                return true;
            }
            throw new Exception("Błąd weryfikacji dania! Danie zostało źle skonstuowane!");
        }
        #endregion

        #region Getting Data

        protected override List<string[]> GetTableData(string query)
        {
            var output = new List<string[]>();
            Connect();

            var command = new SQLiteCommand(query, conn);
            var reader = command.ExecuteReader();
            while (reader.Read()) output.Add(new string[] {
                reader["ID"].ToString(),
                reader["Name"].ToString(),
                reader["Amount"].ToString(),
                reader["Time"].ToString(),
                reader["Vegan"].ToString() });

            CloseConnection();
            return output;
        }

        public ObservableCollection<Dish> GetObservable()
        {
            var output = new ObservableCollection<Dish>();

            var query = "select * from Dishes;";
            var Hh = GetTableData(query);

            var separator1 = new char[] { ',' };
            var separator2 = new char[] { '|' };
            foreach (var dish in Hh)
            {
                var amountDict = new Dictionary<Ingredient, string>();

                var ingList = dish[2].Split(separator1, StringSplitOptions.RemoveEmptyEntries);
                foreach (var ing in ingList)
                {
                    var Hh2 = ing.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                    if (Hh2.Count() == 2) amountDict.Add((Ingredient)ih.GetItem(Convert.ToInt32(Hh2[0])), Hh2[1]);
                    else amountDict.Add((Ingredient)ih.GetItem(Convert.ToInt32(Hh2[0])), "");
                }

                output.Add(new Dish(Convert.ToInt32(dish[0]), dish[1], amountDict, dish[3]));
            }

            return output;
        } //można przerobić na pobieranie danych z kolekcji zamiast z bazy

        public ObservableCollection<Dish> GetVeganObservable()
        {
            ObservableCollection<Dish> output = new ObservableCollection<Dish>();

            foreach (var dish in DList)
            {
                bool Meat = false;
                foreach (var ing in dish.Amount)
                {
                    if (ing.Key.Vegan) Meat = true;
                }
                if (!Meat) output.Add(dish);
            }
            return output;
        }

        public List<Dish> GetListOfDishesWithSetNames(string input)
        {
            var output = new List<Dish>();

            foreach (var dish in DList)
            {
                if (dish.Name.Contains(input)) output.Add(dish);
            }

            return output;
        }

        public ObservableCollection<Dish> GetObservableOfDishesWithSetNames(string input)
        {
            var output = new ObservableCollection<Dish>();

            foreach (var dish in DList)
            {
                if (dish.Name.Contains(input)) output.Add(dish);
            }

            return output;
        }

        public ObservableCollection<Dish> GetObservableOfVeganDishesWithSetNames(string input)
        {

            ObservableCollection<Dish> output = new ObservableCollection<Dish>();

            foreach (var dish in DList)
            {
                bool Meat = false;
                foreach (var ing in dish.Amount)
                {
                    if (ing.Key.Vegan) Meat = true;
                }
                if (!Meat && dish.Name.Contains(input)) output.Add(dish);
            }
            return output;
        }

        public ObservableCollection<Dish> GetDishesWithAllSelectedIngredients(List<Ingredient> ListOfIngredients)
        {
            var output = new ObservableCollection<Dish>();

            if (ListOfIngredients.Count == 0) return output;

            foreach (var dish in DList)
            {
                var counter = 0;
                foreach (var ingredient in ListOfIngredients)
                {
                    bool ContainsIngredient = false;
                    foreach (var dishIngredient in dish.Amount)
                    {

                        if (dishIngredient.Key.ID == ingredient.ID)
                        {
                            ContainsIngredient = true;
                        }
                    }
                    if (ContainsIngredient == true) { counter++; }
                }
                if (counter == ListOfIngredients.Count) { output.Add(dish); }
            }

            return output;
        }

        public ObservableCollection<Dish> GetVeganDishesWithAllSelectedIngredients(List<Ingredient> input)
        {
            var output = new ObservableCollection<Dish>();

            if (input.Count == 0) return output;

            foreach (var dish in DList)
            {
                if (dish.Vegan)
                {
                    var counter = 0;
                    foreach (var ingredient in input)
                    {

                        bool ContainsIngredient = false;
                        foreach (var dishIngredient in dish.Amount)
                        {

                            if (dishIngredient.Key.ID == ingredient.ID && dishIngredient.Key.Vegan == false)
                            {
                                ContainsIngredient = true;
                            }
                        }
                        if (ContainsIngredient == true) counter++;

                    }
                    if (counter == input.Count) { output.Add(dish); }
                }
            }

            return output;
        }

        public ObservableCollection<Dish> GetDishesWithSelectedIngredients(List<Ingredient> ListOfIngredients)
        {
            var output = new ObservableCollection<Dish>();

            foreach (var ingredient in ListOfIngredients)
            {
                foreach (var dish in DList)
                {
                    foreach (var ing in dish.Amount)
                    {
                        if (ing.Key.ID == ingredient.ID && !output.Contains(dish))
                        {
                            output.Add(dish);
                        }
                    }
                }
            }

            return output;
        }

        public ObservableCollection<Dish> GetVeganDishesWithSelectedIngredients(List<Ingredient> input)
        {
            var output = new ObservableCollection<Dish>();

            foreach (var ingredient in input)
            {
                foreach (var dish in DList)
                {
                    if (dish.Vegan)
                    {
                        foreach (var ing in dish.Amount)
                        {

                            if (ing.Key.ID == ingredient.ID && !output.Contains(dish) && ing.Key.Vegan == false)
                            {
                                output.Add(dish);
                            }

                        }
                    }
                }
            }

            return output;
        }

        #endregion

        public List<int> CheckDeleteIngredientConflicts(Ingredient input)
        {
            var problematicDishes = new List<int>();

            foreach (var dish in DList)
            {
                foreach (var amount in dish.Amount)
                {
                    if (amount.Key.ID == input.ID)
                    {
                        if (!problematicDishes.Contains(dish.ID)) problematicDishes.Add(dish.ID);
                    }                   
                }
                
            }

            return problematicDishes;
        }

        public void DeleteIngredient(List<int> dishes, Ingredient ing)
        {
            foreach (var dish in dishes)
            {
                var Hh = DList.Single(x => x.ID == dish);
                var update = new Dictionary<Ingredient, string>();
                foreach (var amount in Hh.Amount)
                {
                    if (amount.Key.ID != ing.ID) update.Add(amount.Key, amount.Value);
                }
                UpdateData(new Dish(Hh.ID, Hh.Name, update, Hh.Time));
            }
        }
    }
}
