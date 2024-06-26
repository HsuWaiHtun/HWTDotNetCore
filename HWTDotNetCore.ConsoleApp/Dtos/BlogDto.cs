﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleApp.Dtos;

[Table("Tbl_Blog")] //mapping C# code "BlogDto" and Table in Sql server
public class BlogDto
{
    [Key]
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
//public record BlogEntity(int BlogId,string BlogTitle,string BlogAuthor,string BlogContent);
