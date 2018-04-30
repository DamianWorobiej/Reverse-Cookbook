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
    public class DBHandler
    {
        private static string DbConnectionString = @"Data Source=" + Paths.Database + ";Version=3;";
        protected static SQLiteConnection conn = new SQLiteConnection(DbConnectionString);

        protected void Connect()
        {
            try
            {
                conn = new SQLiteConnection(DbConnectionString);
                conn.Open();              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, new Exception("Save DBH"));
                //ErrorLogHandler.SaveErrorToLog(ex);
            }
        }

        public static SQLiteDataReader GetReader(string query)
        {
            try
            {
                var command = new SQLiteCommand(query, conn);
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save DBH"));
            }
        }

        

        protected void CloseConnection()
        {
            try {conn.Close(); }
            catch (Exception e) { throw new Exception(e.Message, new Exception("Save DBH")); }
        }

        

        protected void ExecuteNonSelectQuery(string query)
        {
            try
            {
                Connect();
                var command = new SQLiteCommand(query, conn);
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception("Save DBH"));
            }

        }


        //Chyba lepiej pomyśleć o jakiejś klasie wirtualnej po drodze
        #region Virtuals

        public virtual void UpdateData(object input)
        {

        }

        public virtual void DeleteData(int id)
        {

        }

        protected virtual void RefreshCollection()
        {

        }

        public virtual void InsertData(object input)
        {

        }

        protected virtual List<string[]> GetTableData(string query)
        {
            return null;
        }

        public virtual string GetName(int id)
        {
            return null;
        }

        public virtual object GetItem(int id)
        {
            return null;
        }

        #endregion 
    }
}
