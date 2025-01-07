using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("SessionPlayers")]
	public class SessionPlayer
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("session_id"), NotNull]
		public int SessionId { get; set; }

		[Column("user_id"), NotNull]
		public int UserId { get; set; }

		[Column("joined_at")]
		public DateTime JoinedAt { get; set; }
	}
}
