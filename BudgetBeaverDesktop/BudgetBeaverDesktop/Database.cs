using BudgetBeaverDesktop.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBeaverDesktop
{
	class Database
	{
		public static void SetupDatabase()
		{
			// create and then connect to the new sqlite db
			SQLiteConnection.CreateFile("Database.sqlite");
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
			m_dbConnection.Open();

			// create the tables
			string userSql = @"CREATE TABLE User(
								ID INTEGER PRIMARY KEY AUTOINCREMENT,
								Username VARCHAR, MonthlyBudget INTEGER,
								DateCreated DATETIME)";

			SQLiteCommand userTableComman = new SQLiteCommand(userSql, m_dbConnection);
			userTableComman.ExecuteNonQuery();

			string budgetCatSql = @"CREATE TABLE BudgetCategory(
										ID INTEGER PRIMARY KEY AUTOINCREMENT,
										Name VARCHAR,
										DollarLimit INTEGER)";

			SQLiteCommand budgetCategoryCommand = new SQLiteCommand(budgetCatSql, m_dbConnection);
			budgetCategoryCommand.ExecuteNonQuery();

			string budgetEntrySql = @"CREATE TABLE BudgetEntry(
										ID INTEGER PRIMARY KEY AUTOINCREMENT,
										DateEntered DATETIME,
										DollarAmount INTEGER,
										FOREIGN KEY(BudgetCategory) REFERENCES BudgetCategory(ID))";
			SQLiteCommand budgetEntryCommand = new SQLiteCommand(budgetEntrySql, m_dbConnection);
			budgetEntryCommand.ExecuteNonQuery();

			m_dbConnection.Close();
		}

		public static SQLiteConnection ConnectToDatabase()
		{
			// connect to our sqlite db and then return the connection object
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
			m_dbConnection.Open();

			return m_dbConnection;
		}

		public User LoadUser()
		{
			// query our user and return it
			SQLiteConnection database = ConnectToDatabase();
			User user = database.QueryFirst<User>("SELECT * FROM User");
			return user; 
		}

		public List<BudgetCategory> GetBudgetCategories()
		{
			// query our BudgetCategories and return them
			SQLiteConnection database = ConnectToDatabase();
			List<BudgetCategory> user = database.Query<BudgetCategory>("SELECT * FROM BudgetCategory").ToList();
			return user;
		}

		public List<BudgetEntry> GetMonthsBudgetEntries()
		{
			// query our BudgetEntrie for the month so far and return them
			SQLiteConnection database = ConnectToDatabase();
			DateTime now = DateTime.Now;
			DateTime firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
			List<BudgetEntry> user = database.Query<BudgetEntry>("SELECT * FROM BudgetCategory").ToList();
			return user;
		}
	}
}
