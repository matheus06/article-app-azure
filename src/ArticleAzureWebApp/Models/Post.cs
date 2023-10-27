namespace ArticleWebApp.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
}