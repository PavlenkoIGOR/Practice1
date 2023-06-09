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
            Clients clients = EnterData();
            SQLiteCommand command = new SQLiteCommand();
            using (var connection = new SQLiteConnection("Data Source = D:\\VS\\VS projects\\WorkWithFSQLite\\Practice1\\Practice1\\DAL\\DB\\DB_for_clients.db"))
            {
                connection.Open();               
                
                command.Connection = connection;

                command.CommandText = $"INSERT INTO clients (name, surname, age, passport) VALUES ('{clients.name}', '{clients.surname}', {clients.age}, '{clients.passport}');";
                int changes = command.ExecuteNonQuery();
                Console.WriteLine($"New client are added! {changes} changes were manufactured.");
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
