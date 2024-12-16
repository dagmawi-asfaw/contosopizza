using System.ComponentModel.DataAnnotations;

namespace contosopizza.Models;
/// <summary>
/// Sauce Model
/// </summary>
public class Sauce
{
    /// <summary>
    /// Id : int
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name : String?
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

/// <summary>
/// Is Vegan : bool
/// </summary>
    public bool IsVegan { get; set; }
}