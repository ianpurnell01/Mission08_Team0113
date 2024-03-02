namespace Mission08_Team0113.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//set the properties for the form.
public class Table
{
    [Key]
    public int TaskId { get; set; }


    [Required(ErrorMessage = "Please enter your task")]
    public string Task { get; set; }
    //[Required(ErrorMessage = "Please enter your task")]

    public string? DueDate { get; set; }

    [Required(ErrorMessage = "Please enter a quadrant between 1-4")]
    public int Quadrant { get; set; }

    [ForeignKey("CategoryId")]
    //[Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    //[Required(ErrorMessage = "Please select a category")]
    public int Completed { get; set; }
    


}

