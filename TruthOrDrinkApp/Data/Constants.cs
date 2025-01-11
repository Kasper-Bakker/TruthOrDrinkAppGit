using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
		}

		public async Task InitializeDatabaseAsync()
		{
			try
			{
				await _database.CreateTableAsync<User>();
				await _database.CreateTableAsync<Friend>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error creating tables: {ex.Message}");
				throw;
			}
		}

		public Task<int> AddAsync<T>(T item) where T : new() => _database.InsertAsync(item);

		public Task<List<T>> GetAllAsync<T>() where T : new() => _database.Table<T>().ToListAsync();

		public async Task<T?> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			try
			{
				return await _database.FindAsync(predicate);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error finding item: {ex.Message}");
				return default;
			}
		}
	}
}
