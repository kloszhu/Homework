namespace HomeWork.Entities;
public class RankEntity: IComparable<RankEntity>
{
    public long Id { get; set; }
    public long CustomerID { get; set; }
    public decimal Score { get; set; }
    public int RankNum { get; set; }

    public int CompareTo(RankEntity? other)
    {
        if (this.Score == other.Score)
        {
            return this.CustomerID > other.CustomerID ? 1 : -1;
        }
        return this.Score < other.Score ? 1 : -1;

    }
}