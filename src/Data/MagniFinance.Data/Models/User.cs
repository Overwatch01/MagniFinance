using MagniFinance.Data.Constants;

namespace MagniFinance.Data.Models;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OtherName { get; set; }
    public string? Email { get; set; }
    public UserType UserType { get; set; }
}   