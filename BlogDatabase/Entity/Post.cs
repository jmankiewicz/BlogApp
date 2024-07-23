namespace BlogDatabase.Entity;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public User Author { get; set; }
    public Guid AuthorId { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();
}
