using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RCookBookDB;
//using RCookBookDB.okna;
using RevCookBook.Classes;
using RevCookBook.Handlers;


namespace RevCookBook.View_Models
{
    class AddCategoryViewModel
    {
        private int state;
        private string name;


        public int State { get => state; set => state = value; }
        public string Name { get => name; set => name = value; }

        private Category cat;
        private CategoryHandler ch;


        public AddCategoryViewModel()
        {
            state = 0;
            ch = new CategoryHandler();
        }

        public AddCategoryViewModel(Category cat)
        {
            state = 1;
            this.cat = cat;
            name = cat.Name;
            ch = new CategoryHandler();
        }

        public void AddCategory()
        {
            try
            {
                if (name != "" && name != null)
                {
                    ch.InsertData(name);
                    RCookBookDB.okna.AddCategory.CloseAddCategoryWindow();
                }
                else throw new Exception("Należy wpisać nazwę kategorii!"); //length 29
            }
            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd dodawania kategorii! Raport błędu został zapisany. Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message, "Błąd dodawania kategorii");
            }
        }

        public void UpdateCategory()
        {
            try
            {
                if (name != "") {
                    ch.UpdateData(new Category(name, cat.ID));
                    RCookBookDB.okna.AddCategory.CloseAddCategoryWindow();
                    FindDish.CloseFindDishWindow();
                }
                else throw new Exception("Należy wpisać nazwę kategorii!");
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    ErrorLogHandler.SaveErrorToLog(e);
                    MessageBox.Show("Błąd uaktualniania kategorii! Raport błędu został zapisany. Proszę wysłać go do developera, bardzo pomoże to w rozwoju programu (:");
                }
                else MessageBox.Show(e.Message, "Błąd uaktualniania kategorii");
            }
        }
    }
}
