namespace contosopizza.Models;
/// <summary>
/// Pizza model
/// </summary>
public class Pizza
{
    /// <summary>
    /// Id: int
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name : String
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Sauce: Sauce Model
    /// </summary>
    public Sauce? Sauce { get; set; }
    /// <summary>
    /// Toppings : ICollection
    /// </summary>
    public ICollection<Topping>? Toppings { get; set; }
}