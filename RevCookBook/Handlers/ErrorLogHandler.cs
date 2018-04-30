using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace RevCookBook.Handlers
{
    class ErrorLogHandler : FileHandler
    {
        private ErrorLogHandler()
        {

        }

        public static void SaveErrorToLog(Exception e)
        {
            try
            {
                if (!CheckIfDirectoryExists(Paths.ErrorLogs)) CreateDIrectory(Paths.ErrorLogs);
                string filename = Paths.ErrorLogs + "Error Log " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

                if (!CheckIfFileExist(filename)) SaveDataToFile(e.ToString()/*.Message + "; " + e.InnerException.Message*/, filename);
                else AppendFile(filename, e.ToString()/*.Message + "; " + e.InnerException.Message*/);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas tworzenia raportu błędu. O ironio. Treść błędu: " + ex.Message);
            }
        }


    }
}
