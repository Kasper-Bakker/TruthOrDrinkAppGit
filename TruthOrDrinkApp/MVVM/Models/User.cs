using SQLite;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("Users")]
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("name"), Unique, NotNull]
		public string Name { get; set; } = string.Empty;

		[Column("email"), Unique, NotNull]
		public string Email { get; set; } = string.Empty;

		[NotNull]
		public string PasswordHash { get; set; } = string.Empty;

		public int? Age { get; set; }

		[Ignore]
		public bool OldEnoughToDrink => Age >= 18;
	}
}
