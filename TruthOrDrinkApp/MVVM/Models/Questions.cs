using SQLite;
using System;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("Questions")]
	public class Question
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("question_text"), NotNull]
		public string QuestionText { get; set; }

		[Column("category")]
		public string Category { get; set; }

		[Column("difficulty")]
		public int Difficulty { get; set; }  

		[Column("is_personalized")]
		public bool IsPersonalized { get; set; }

		[Column("added_by_user_id")]
		public int? AddedByUserId { get; set; }

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}
