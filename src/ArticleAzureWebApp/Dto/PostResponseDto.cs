namespace ArticleWebApp.Dto;

public class PostResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
}