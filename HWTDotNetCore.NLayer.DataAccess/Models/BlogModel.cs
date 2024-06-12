using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWTDotNetCore.NLayer.DataAccess.Models;

[Table("Tbl_Blog")] //mapping C# code "BlogDto" and Table in Sql server
public class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }//string? - Allow null value
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
//public record BlogEntity(int BlogId,string BlogTitle,string BlogAuthor,string BlogContent);
