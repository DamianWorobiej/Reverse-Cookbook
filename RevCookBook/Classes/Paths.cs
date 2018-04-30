using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevCookBook
{
    public static class Paths
    {
        public static string ErrorLogs = Directory.GetCurrentDirectory() + SubPathErrorLogs;
        public static string SubPathErrorLogs = @"\logs\error logs\";
        public static string Database = @"Data/RCBookDB.s3db";
    }
}
