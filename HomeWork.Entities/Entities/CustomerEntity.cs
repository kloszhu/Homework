using System.ComponentModel.DataAnnotations;

namespace HomeWork.Entities;
public class CustomerEntity{

    [Key]
    public long CustomerID { get; set; }
}