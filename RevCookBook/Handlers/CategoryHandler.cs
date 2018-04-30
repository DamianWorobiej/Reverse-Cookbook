using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RevCookBook.Classes;

namespace RevCookBook.Handlers
{
    class CategoryHandler : DBHandler
    {
        public List<Category> CatList;

       

        public CategoryHandler()
        {
            RefreshCollection();
        }

        protected override void RefreshCollection()
        {
            try
            {
                CatList = new List<Category>();

                var query = "select * from Categories";


                var Hh = GetTableData(query);
                foreach (var item in Hh)
                {
                    CatList.Add(new Category(item[1], Convert.ToInt32(item[0])));
                }
                CatList.Sort((x, y) => string.Compare(x.Name, y.Name));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Metoda błędu: CategoryHandler.RefreshCollection()"));
                //ErrorLogHandler.SaveErrorToLog(e);
                //MessageBox.Show("Błąd odświeżania kolekcji!");
            }
        }


        #region Database Manipulation
        public override void InsertData(object input)
        {
            try
            {
                //throw new Exception("Działa");
                if (verifyExistance(new Category((string)input,0)))
                {
                    string data = (string)input;

                    var query = "insert into Categories (Name) values (\"" + data + "\");";
                    ExecuteNonSelectQuery(query);
                    if (CatList != null) RefreshCollection();
                }
            }
            catch (Exception e)
            {
                //throw new Exception("Błąd dodawania kategorii: " + e.Message);
                throw new Exception(e.Message, new Exception("Metoda błędu: CategoryHandler.InsertData()"));
            }
        }

        public override void UpdateData(object input)
        {
            try
            {
                Category data = (Category)input;

                if (verifyExistance(data))
                {
                    var query = "update Categories set Name = \"" + data.Name + "\" where ID = " + data.ID + ";";
                    ExecuteNonSelectQuery(query);
                    if (CatList != null) RefreshCollection();
                }
            }
            catch (Exception e)
            {
                //throw new Exception("Błąd aktualizacji kategorii: " + e.Message);
                throw new Exception(e.Message, new Exception("Metoda błędu: CategoryHandler.UpdateData()"));
            }
        }

        public override void DeleteData(int id)
        {
            var query = "delete from Categories where ID = " + id + ";";
            ExecuteNonSelectQuery(query);
            if (CatList != null) RefreshCollection();
        }   // na chwilę obecną nie wykorzystywane

        private bool verifyExistance(Category data)
        {
            if (data.ID != 0)
            {
                foreach (var category in CatList)
                {
                    if (category.ID != data.ID && category.Name == data.Name) throw new Exception("W bazie znajduje się już kategoria o podanej nazwie!");
                }
                return true;
            }
            else
            {
                foreach (var category in CatList)
                {
                    if (category.Name == data.Name) throw new Exception("W bazie znajduje się już kategoria o podanej nazwie!");
                }
                return true;
            }
            throw new Exception("Błąd weryfikacji kategorii! Kategoria została źle skontruowana");
        }
        #endregion

        #region Getting Data

        protected override List<string[]> GetTableData(string query)
        {
            try
            {
                Connect();
                List<string[]> output = new List<string[]>();
                var command = new SQLiteCommand(query, conn);
                var reader = command.ExecuteReader();
                while (reader.Read()) output.Add(new string[] { reader["ID"].ToString(), reader["Name"].ToString() });

                CloseConnection();
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save"));
            }
        }

        public ObservableCollection<Category> GetObservable()
        {
            try
            {
                RefreshCollection();
                var output = new ObservableCollection<Category>();

                foreach (var item in CatList)
                {
                    output.Add(item);
                }

                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save"));
            }
        }

        public ObservableCollection<Category> GetCategoriesWithSetNames(string input)
        {
            try
            {
                RefreshCollection();
                var output = new ObservableCollection<Category>();

                foreach (var cat in CatList)
                {
                    if (cat.Name.Contains(input)) output.Add(cat);

                }

                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save"));
            }
        }

        public ObservableCollection<Category> GetObservableOfCategoriesWithSetName(string input)
        {
            try
            {
                RefreshCollection();
                var output = new ObservableCollection<Category>();

                foreach (var cat in CatList)
                {
                    if (cat.Name.Contains(input)) output.Add(cat);
                }

                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save"));
            }
        }

        #endregion
    }
}
