using ArticleWebApp.Models;

namespace ArticleWebApp.Dto;

public class Mapper
{
    public static PostResponseDto MapToPostResponseDto(Post post)
    {
        return new PostResponseDto
        {
            Id = post.Id,
            Author = post.Author,
            Title = post.Title,
            Body = post.Body
        };
    }
}