public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int AuthorUserId { get; set; }
    public User Author { get; set; }
    public int ContributorUserId { get; set; }
    public User Contributor { get; set; }
}
public class User
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [InverseProperty("Author")]
    public List<Post> AuthoredPosts { get; set; }
    [InverseProperty("Contributor")]
    public List<Post> ContributedToPosts { get; set; }
}
