using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiazkaWPF
{
    public static class Functions
    {
        static SQLiteConnection con = new SQLiteConnection("Data Source=users.db");
        public static int max_users = 12;
        public static Action refresh;
        public static string Table_name = "persons";

        public static void Open()
        {
            con.Open();
        }

        public static void AddTable(string tableName)
        {
            SQLiteCommand com = con.CreateCommand();
            com.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} (id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Name STRING, Surname STRING, Number TEXT, Email STRING)";
            com.ExecuteReader();
            Table_name = tableName;

            if (refresh != null)
            {
                refresh();
            }
        }

        public static int MaxPage(string query = "")
        {
            string where = "";

            if (query != "")
            {
                where = $" WHERE Name || ' ' || Surname LIKE '%{query}%'";
            }

            SQLiteCommand com = con.CreateCommand();
            com.CommandText = "SELECT ((COUNT(*)-1) / " + max_users + ") as pageSize FROM " + Table_name + where;

            SQLiteDataReader dataReader = com.ExecuteReader();

            dataReader.Read();
            return dataReader.GetInt32(0);
        }

        public static void AddPerson(Person person)
        {
            SQLiteCommand com = con.CreateCommand();
            com.CommandText = $"INSERT INTO {Table_name} (Name, Surname, Number, Email) VALUES ('{person.Name}','{person.Surname}','{person.Number}','{person.Email}')";
            com.ExecuteNonQuery();

            if (refresh != null)
            {
                refresh();
            }
        }

        public static void EditPerson(Person person, Person oldPerson)
        {
            SQLiteCommand com = con.CreateCommand();
            com.CommandText = $"UPDATE {Table_name} SET Name='{person.Name}',Surname='{person.Surname}',Number='{person.Number}',Email='{person.Email}' WHERE Name='{oldPerson.Name}' AND Surname='{oldPerson.Surname}' AND Number='{oldPerson.Number}' AND Email='{oldPerson.Email}'";
            com.ExecuteNonQuery();

            if (refresh != null)
            {
                refresh();
            }
        }

        public static void DeletePerson(Person person) 
        {
            SQLiteCommand com = con.CreateCommand();
            com.CommandText = $"DELETE FROM {Table_name} WHERE Name='{person.Name}' AND Surname='{person.Surname}' AND Number='{person.Number}' AND Email='{person.Email}'";
            com.ExecuteNonQuery();

            if (refresh != null)
            {
                refresh();
            }
        }

        public static List<Person> GetPersons(int page = 0, string query = "")
        {
            List<Person> list = new List<Person>();

            string where = "";

            if(query != "")
            {
                where = $"WHERE Name || ' ' || Surname LIKE '%{query}%'";
            }

            SQLiteCommand com = con.CreateCommand();
            com.CommandText = $"SELECT * FROM {Table_name} {where} LIMIT $pos, {max_users}";
            com.Parameters.AddWithValue("$pos", page * max_users);

            SQLiteDataReader dataReader = com.ExecuteReader();

            while (dataReader.Read()) 
            {
                string name = dataReader.GetString(1);
                string surname = dataReader.GetString(2);
                string number = dataReader.GetString(3);
                string email = dataReader.GetString(4);

                list.Add(new Person(name, surname, number, email));
            }

            return list;
        }
    }
}
