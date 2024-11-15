using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace GameForge.Models;

public class Cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CartID { get; set; } // Unique identifier for the cart
    public List<Game> CartItems { get; set; } = new List<Game>(); // List of items in the cart
    public decimal TotalPrice 
    { 
        get 
        {
            return CartItems.Sum(item => item.Price); // Calculate the total price of the cart
        }
    }
    public DateTime CreationDate { get; set; } = DateTime.Now; // Cart creation time
    public bool IsCheckedOut { get; set; } = false; // Flag for checkout status
    public required User User { get; set; }
}