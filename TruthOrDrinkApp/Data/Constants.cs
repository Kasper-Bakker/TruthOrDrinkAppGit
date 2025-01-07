using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp.Data
{
	public class Constants
	{
		private readonly SQLiteAsyncConnection _database;

		public Constants(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);

			try
			{

				_database.CreateTableAsync<User>().Wait();
				_database.CreateTableAsync<Session>().Wait();
				_database.CreateTableAsync<SessionPlayer>().Wait();
				_database.CreateTableAsync<Question>().Wait();
				_database.CreateTableAsync<Friend>().Wait();

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error creating tables: {ex.Message}");
				throw;
			}
		}

		public Task<List<T>> GetAllAsync<T>() where T : new()
		{
			return _database.Table<T>().ToListAsync();
		}

		public Task<int> AddAsync<T>(T item) where T : new()
		{
			return _database.InsertAsync(item);
		}

		public Task<int> UpdateAsync<T>(T item) where T : new()
		{
			return _database.UpdateAsync(item);
		}

		public Task<int> DeleteAsync<T>(T item) where T : new()
		{
			return _database.DeleteAsync(item);
		}

		public Task<int> AddAllAsync<T>(IEnumerable<T> items) where T : new()
		{
			return _database.InsertAllAsync(items);
		}
	}
}
