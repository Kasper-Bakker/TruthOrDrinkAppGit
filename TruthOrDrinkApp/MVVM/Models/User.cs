using SQLite;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("Users")]
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("name"), Indexed, NotNull]
		public string? Name { get; set; }

		[MaxLength(100)]
		public string? Email { get; set; }

		public int? Age { get; set; }

		[Ignore]
		public bool? OldEnoughToDrink => Age > 17 ? true : false;
	}
}
