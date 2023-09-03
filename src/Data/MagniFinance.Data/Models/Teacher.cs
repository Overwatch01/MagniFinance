using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinance.Data.Models;

public class Teacher : BaseEntity
{
    public double AnnualSalary { get; set; }
    public virtual User User { get; set; }
    public virtual Course Course { get; set; }
}