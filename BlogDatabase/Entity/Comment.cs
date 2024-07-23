namespace BlogDatabase.Entity;

public class Comment
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }

    public Post Post { get; set; }
    public int PostId { get; set; }

    public User Author { get; set; }
    public Guid AuthorId { get; set; }
}
