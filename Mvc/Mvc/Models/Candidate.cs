using System.ComponentModel.DataAnnotations;

namespace Mvc.Models;

public class Candidate
{
    [Required(ErrorMessage = "Email is required")]
    public string? email { get; set; } = String.Empty;
    [Required(ErrorMessage = "First Name is required")]
    public string? FirstName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Last Name is required")]
    public string? LastName { get; set; } = String.Empty;
    // boş gelebilir ona göre diyor ondan ? at sona
    public string? FullName => $"{FirstName} {LastName?.ToUpper()}";
    
    public string? SelectedCourse { get; set; } = String.Empty;
    public int? age { get; set; }
    public DateTime ApplyAt { get; set; }

    public Candidate()
    {
        ApplyAt = DateTime.Now;
    }
}