using System.ComponentModel.DataAnnotations;

namespace Cart.API.Requests;

public record class AddProductRequest([Range(0, int.MaxValue)] int ProductId, 
                                      [Range(0, int.MaxValue, ErrorMessage = "Invalid quantity")] int Quantity,
                                      [Required(ErrorMessage = "User name is required", AllowEmptyStrings = false)] string Username);
