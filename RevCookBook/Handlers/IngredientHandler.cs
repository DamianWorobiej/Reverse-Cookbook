using RevCookBook.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RevCookBook.Handlers
{
    class IngredientHandler : DBHandler
    {
        public List<Ingredient> IngList;
        public bool Close;

        public IngredientHandler()
        {
            RefreshCollection();
        }

        protected override void RefreshCollection()
        {
            IngList = new List<Ingredient>();

            var query = "select * from Ingredients;";
            var Hh = GetTableData(query);

            foreach (var ing in Hh)
            {
                IngList.Add(new Ingredient(Convert.ToInt32(ing[0]), ing[1], Convert.ToInt32(ing[2]), ing[3], ing[4]));
                //MessageBox.Show(ing[0] + " " + ing[1] + " " + ing[2] + " " + ing[3] + " " + ing[4] + "\n");

            }
            IngList.Sort((x,y) => string.Compare(x.Name, y.Name));
        }

        

        #region Database Manipulation
        public override void InsertData(object input)
        {
            try
            {
                Ingredient data = (Ingredient)input;
                if (verifyExistance(data))
                {
                    var query = "insert into Ingredients (Name, CategoryID, Vegan, Lactosis) values ('" + data.Name + "', '" + data.CategoryID + "', '" + data.Vegan + "', '" + data.Lactosis + "');";
                    ExecuteNonSelectQuery(query);
                    if (IngList != null) RefreshCollection();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Wystąpił problem podczas dodawania składnika, komunikat błędu:" + Environment.NewLine + e.Message);
                throw new Exception("Błąd dodawania składnika: " + e.Message);
            }
        }

        public override void UpdateData(object input)
        {
            try
            {
                Ingredient data = (Ingredient)input;

                //var query = "update Categories set Name = \"" + data.Name + "\" where ID = " + data.ID + ";";

                if (verifyExistance(data))
                {
                    var query = "update Ingredients set Name = '" + data.Name + "', CategoryID = " + data.CategoryID + ", Vegan = '" + data.Vegan.ToString() + "', Lactosis = '" + data.Lactosis.ToString() + "' where ID = " + data.ID + ";";

                    ExecuteNonSelectQuery(query);
                    if (IngList != null) RefreshCollection();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Wystąpił problem podczas aktualizowania składnika, komunikat błędu:" + Environment.NewLine + e.Message);
                throw new Exception("Błąd aktualizacji składnika: " + e.Message);
            }

        }

        public override void DeleteData(int id)
        {
            try
            {
                var query = "delete from Ingredients where ID = " + id + ";";
                ExecuteNonSelectQuery(query);
                if (IngList != null) RefreshCollection();
                Close = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Wystąpił problem podczas usuwania składnika, komunikat błędu:" + Environment.NewLine + e.Message);
                throw new Exception("Błąd usuwania składnika: " + e.Message);
            }
        }

        private bool verifyExistance(Ingredient data)
        {
            if (data.ID != 0)
            {
                foreach (var ingredient in IngList)
                {
                    if (ingredient.ID != data.ID && ingredient.Name == data.Name) throw new Exception("Składnik o podanej nazwie znajduje się już w bazie!");
                }
                return true;
            }
            else
            {
                foreach (var ingredient in IngList)
                {
                    if (ingredient.Name == data.Name) throw new Exception("Składnik o podanej nazwie znajduje się już w bazie!");
                }
                return true;
            }
            throw new Exception("Błąd weryfikacji składnika! Składnik został źle skonstruowany!");
        }

        public override string GetName(int id)
        {
            var query = "select Name from Ingredients where ID = " + id.ToString() + ";";
            string output = null;
            Connect();

            var command = new SQLiteCommand(query, conn);
            var reader = command.ExecuteReader();
            while (reader.Read()) output = reader["Name"].ToString();
            
            return output;
        }

        public override object GetItem(int id)
        {
            Ingredient output;
            var query = "select * from Ingredients where ID = " + id.ToString() + ";";
            var Hh = GetTableData(query);
            output = new Ingredient(Convert.ToInt32(Hh[0][0]), Hh[0][1], Convert.ToInt32(Hh[0][2]), Hh[0][3], Hh[0][4]);
            return output;
        }
        #endregion

        #region Getting Data
        public ObservableCollection<Ingredient> GetObservable()
        {
            RefreshCollection();
            var output = new ObservableCollection<Ingredient>();
            foreach (var ing in IngList)
            {
                output.Add(ing);
            }
            return output;
        }

        public ObservableCollection<Ingredient> GetObservableOfIngredientsWithSetName(string input)
        {
            RefreshCollection();
            var output = new ObservableCollection<Ingredient>();

            foreach (var ing in IngList)
            {
                if (ing.Name.Contains(input)) output.Add(ing);
            }

            return output;
        }

        protected override List<string[]> GetTableData(string query)
        {
            var output = new List<string[]>();
            Connect();

            var command = new SQLiteCommand(query, conn);
            var reader = command.ExecuteReader();
            while (reader.Read()) output.Add(new string[] {
                reader["ID"].ToString(),
                reader["Name"].ToString(),
                reader["CategoryID"].ToString(),
                reader["Vegan"].ToString(),
                reader["Lactosis"].ToString() });

            CloseConnection();
            return output;
        }

        #endregion
    }
}
