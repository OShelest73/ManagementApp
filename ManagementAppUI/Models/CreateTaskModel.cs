using System.ComponentModel.DataAnnotations;

namespace ManagementAppUI.Models;

public class CreateTaskModel
{
    [Required]
    [MaxLength(75)]
    public string Task { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [MaxLength(500)]
    public string Notes { get; set; }
}
