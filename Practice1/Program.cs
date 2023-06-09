using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;
using System.Data.Sql;

namespace Practice1
{
    class Clients
    {
        public string name;
        public string surname;
        public int age;
        public string passport;
        public Clients(string name, string surname, int age, string passport) 
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.passport = passport;
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            /*
            Clients clients = EnterData();
                       
            /// <summary>
            /// заполнение таблицы
            /// </summary>
            using (var connection = new SQLiteConnection("Data Source = D:\\VS\\VS projects\\WorkWithFSQLite\\Practice1\\Practice1\\DAL\\DB\\DB_for_clients.db"))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;

                command.CommandText = $"INSERT INTO clients (name, surname, age, passport) VALUES ('{clients.name}', '{clients.surname}', {clients.age}, '{clients.passport}');";
                int changes = command.ExecuteNonQuery();
                Console.WriteLine($"New client are added! {changes} changes were manufactured.");
            }
            */
            /// <summary>
            /// запрос из базы данных
            /// </summary>
            string sqlExpression = "SELECT * FROM clients";
            using (var connection2 = new SQLiteConnection("Data Source = D:\\VS\\VS projects\\WorkWithFSQLite\\Practice1\\Practice1\\DAL\\DB\\DB_for_clients.db"))
            {
                connection2.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection2);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(0);
                            var name = reader.GetValue(1);
                            var surname = reader.GetValue(2);
                            var age = reader.GetValue(3);
                            var passport = reader.GetValue(4);

                            Console.WriteLine($"{id} \t {name} \t {surname} \t {age} \t {passport}");
                        }
                    }
                }
            }


            Console.ReadKey();
        }
        static Clients EnterData()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Enter your passport number: ");
            string passport = Console.ReadLine();
            return new Clients(name, surname, age, passport);    
        } //метод для заполнения полей Clients
    }
}
