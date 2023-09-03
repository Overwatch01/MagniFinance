using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinance.Data.Models;

public class Student : BaseEntity
{
    public string RegistrationNumber { get; set; }
    public virtual Course Course { get; set; }
    public virtual User User { get; set; }
}