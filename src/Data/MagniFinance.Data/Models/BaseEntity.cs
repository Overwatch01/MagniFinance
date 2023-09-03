using System.ComponentModel.DataAnnotations;

namespace MagniFinance.Data.Models;

public class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}