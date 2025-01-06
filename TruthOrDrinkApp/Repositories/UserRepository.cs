using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp.Repositories
{
	public class UserRepository
	{
		SQLiteConnection connection;
		public string? statusMessage { get; set; }
		public UserRepository()
		{
			connection = new SQLiteConnection(
				Constants.DatabasePath,
				Constants.flags);
			connection.CreateTable<User>();
		}

		public void AddOrUpdate(User user)
		{
			int result = 0;
			try
			{
				if (user.Id != 0)
				{
					result = connection.Insert(user);
					statusMessage = $"{result} row(s) updated";
				}
				else
				{
					result = connection.Insert(user);
					statusMessage = $"{result} row(s) added";
				}
			}
			catch (Exception ex)
			{
				statusMessage = $"Error: {ex.Message}";
			}
		}

		public List<User> GetAll()
		{
			try
			{
				return connection.Table<User>().ToList();
			}
			catch (Exception ex)
			{
				statusMessage = $"Error: {ex.Message}";
			}
			return null;
		}

		public User? Get(int id)
		{
			try
			{
				return connection.Table<User>().FirstOrDefault(x => x.Id == id);
			}
			catch (Exception ex)
			{
				statusMessage = $"Error: {ex.Message}";
			}
			return null;
		}

		public void Delete(int userId)
		{
			try
			{
				User user = Get(userId);
				connection.Delete(user);
			}
			catch (Exception ex)
			{
				statusMessage = $"Error: {ex.Message}";
			}
		}

	}
}
