namespace BlogDatabase.Entity;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    public Address Address { get; set; }

    public List<Post> Posts { get; set; } = new List<Post>();

    public List<Comment> Comments { get; set; } = new List<Comment>();
}
