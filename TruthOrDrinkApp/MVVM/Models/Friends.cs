using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.MVVM.Models
{
	[Table("Friends")]
	public class Friend
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Column("user_id"), NotNull]
		public int UserId { get; set; }

		[Column("friend_id"), NotNull]
		public int FriendId { get; set; }

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}
