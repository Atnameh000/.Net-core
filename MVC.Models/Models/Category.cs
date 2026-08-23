using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace First_MVC.Models;

public class Category
{
    [Key] //This is Data Annotations, they are use to specify what is , can or should do;
    public int Id { get; set; }

    [MaxLength(30)]
    [Required]
    public string? Name { get; set; }

    [Range(1, 100)]
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
}