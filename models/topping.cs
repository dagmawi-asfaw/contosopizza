using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace contosopizza.Models;
/// <summary>
/// Topping Model
/// </summary>
public class Topping
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
    /// pizzas that have this topping
    /// pizzas: Pizza
    /// </summary>
    [JsonIgnore]
    public ICollection<Pizza>? Pizzas { get; set; }
}