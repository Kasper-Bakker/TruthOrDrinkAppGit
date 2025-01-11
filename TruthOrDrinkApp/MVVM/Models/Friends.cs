using SQLite;

[Table("Friends")]
public class Friend
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	[Column("user_id"), NotNull]
	public int UserId { get; set; } 

	[Column("friend_id"), NotNull]
	public int FriendId { get; set; } 

	[Column("friend_name"), NotNull]
	public string FriendName { get; set; } = string.Empty;

	[Column("created_at")]
	public DateTime CreatedAt { get; set; }
}
