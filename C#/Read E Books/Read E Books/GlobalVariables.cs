using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_E_Books
{
    public static class GlobalVariables
    {
        static string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\2291894\\Desktop\\Application-Development-Project\\Read E Books\\Read E Books\\EbookDatabase.mdf\";Integrated Security=True";

        
        public static string Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
        public static string CurrentUsername { get; set; }

        public static string CurrentPassword { get; set; }

        public static int CurrentId { get; set; }

        public static int CurrentBookId { get; set;}
    }

}
