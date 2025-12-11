using System.ComponentModel.DataAnnotations;

namespace FinalAppYuval.Models;

public class StudentGrade
{
    [Key] public int Id { get; set; }

    // [Required(ErrorMessage = "BookId is required")]
    // [ForeignKey("Books")]
    public string Name { get; set; } = string.Empty;

    // [Required(ErrorMessage = "Reviewer name is required")]
    // [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public int Assignment1 { get; set; } 

    // [Required(ErrorMessage = "Rating is required")]
    // [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Assignment2 { get; set; }

    // [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
    public int Midterm { get; set; }
    public int Final { get; set; }

    /// <summary>
    /// Calculated total score: Assignment1 + Assignment2 + Midterm + Final
    /// </summary>
    public int CalculatedTotal => Assignment1 + Assignment2 + Midterm + Final;

    /// <summary>
    /// Student pass/fail status based on calculated total
    /// </summary>
    public string Status => CalculatedTotal >= 50 ? "Pass" : "Fail";

    // Optional: Store total in database if needed for queries
    public decimal Total { get; set; }

    // public Books? Books { get; set; }
}