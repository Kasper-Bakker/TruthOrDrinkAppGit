using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("Sessions")]
	public class Session
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("session_name"), NotNull]
		public string? SessionName { get; set; }

		[Column("host_user_id"), NotNull]
		public int HostUserId { get; set; }

		[Column("category")]
		public string? Category { get; set; }

		[Column("difficulty_level")]
		public string? DifficultyLevel { get; set; }

		[Column("qr_code")]
		public string? QrCode { get; set; }

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}
