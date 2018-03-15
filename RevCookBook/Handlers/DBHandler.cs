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
        private static string DbConnectionString = @"Data Source=Data/RCBookDB.s3db;Version=3;";
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
                MessageBox.Show(ex.ToString());
            }
        }

        public static SQLiteDataReader GetReader(string query)
        {
            var command = new SQLiteCommand(query, conn);
            return command.ExecuteReader();
        }

        

        protected void CloseConnection()
        {
            conn.Close();
        }

        

        protected void ExecuteNonSelectQuery(string query)
        {
            Connect();
            var command = new SQLiteCommand(query, conn);
            command.ExecuteNonQuery();
            CloseConnection();

        }


        #region Virtuals // lepiej by było skorzystać z interfejsu

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
