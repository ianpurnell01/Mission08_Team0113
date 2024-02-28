namespace Mission08_Team0113.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Table
{
    [Key]
    public int TaskId { get; set; }

    [ForeignKey("Category")]
    [Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required(ErrorMessage = "Please select a category")]

    public string Task { get; set; }
    [Required(ErrorMessage = "Please enter your task")]

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }
    


}

