using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace RevCookBook.Handlers
{
    class FileHandler
    {
        protected FileHandler()
        {

        }

        protected static void CreateFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    //File.Create(filepath);
                    
                }
            }
            catch  (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected static void AppendFile(string filepath, string input)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(input);
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected static void SaveDataToFile(string data, string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    //File.Create(filepath);
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(data);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected static bool CheckIfFileExist(string filename)
        {
            if (File.Exists(filename)) return true;
            else return false;
        }

        protected static bool CheckIfDirectoryExists(string path)
        {
            if (Directory.Exists(path)) return true;
            else return false;
        }

        protected static void CreateDIrectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd podczas tworzenia folderu do zapisu plików!");
            }
        }
    }
}
