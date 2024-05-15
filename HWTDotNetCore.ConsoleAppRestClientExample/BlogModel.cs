public class BlogModel
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }//string? - Allow null value
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
