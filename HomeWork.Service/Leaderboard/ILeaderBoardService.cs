using HomeWork.Service.Customer.VO;
using HomeWork.Service.Leaderboard.VO;

namespace HomeWork.Service.Leaderboard
{
    public interface ILeaderBoardService
    {
        List<RanksVO> GetRanksByScore(LeaderBoardVO search);
        void ReRank(long CustomerID, decimal Score);
        List<RanksVO> GetRanksByRanks(long customerid, int? high, int? low);
    }
}