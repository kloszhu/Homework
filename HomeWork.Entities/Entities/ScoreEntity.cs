using System.ComponentModel.DataAnnotations;

namespace HomeWork.Entities;
public class ScoreEntity{
    
    [Key]
    public long ScoreId { get; set; }
    public long CustomerID { get; set; }
    public decimal ScoreNum { get; set; }=0;

}