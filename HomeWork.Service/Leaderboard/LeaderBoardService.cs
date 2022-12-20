using HomeWork.Service.Customer.VO;
using HomeWork.Service.Leaderboard.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.Leaderboard
{
    public class LeaderBoardService : ILeaderBoardService
    {
        public List<RanksVO> GetRanksByRanks(long customerid, int? high, int? low)
        {
            var query = PersistenceData.Ranks.AsEnumerable();

            if (high.HasValue || low.HasValue)
            {
                var merank = PersistenceData.Ranks.FirstOrDefault(a => a.CustomerID == customerid);

                if (high.HasValue)
                {
                    query = query.Where(a => a.RankNum > merank.RankNum - high);
                }
                if (low.HasValue)
                {
                    query = query.Where(a => a.Score <= merank.RankNum + low);
                }

            }
            else {
                query = query.Where(a => a.CustomerID == customerid);
            }
           
            return query.Select(a => new RanksVO { CustomerId = a.CustomerID, Rank = a.RankNum, Score = a.Score }).ToList();
        }

        public List<RanksVO> GetRanksByScore(LeaderBoardVO search)
        {
            var query = PersistenceData.Ranks.AsEnumerable();
            if (search.start.HasValue || search.end.HasValue)
            {
              
                if (search.start.HasValue)
                {
                    query = query.Where(a => a.Score >= Convert.ToDecimal(search.start));
                }
                if (search.end.HasValue)
                {
                    query = query.Where(a => a.Score <= Convert.ToDecimal(search.end));
                }
            }
            else {
                query = query.Where(a => a.CustomerID == search.CustomerId);
            }
          
            return query.Select(a=>new RanksVO { CustomerId=a.CustomerID, Rank=a.RankNum, Score=a.Score }).ToList();
        }

        public void ReRank(long CustomerID, decimal Score)
        {
            var score = PersistenceData.Ranks.FirstOrDefault(a => a.CustomerID == CustomerID);
            ///1.
            if (score == null)
            {
                PersistenceData.Ranks.Add(new Entities.RankEntity { CustomerID = CustomerID, Score = Score });
            }
            else
            {
                score.Score = Score;
            }
            ///排序之前处理没有积分的客户
            var ZeroCustomer = PersistenceData.Customers.Where(a => !PersistenceData.Ranks.Any(b => b.CustomerID == a.CustomerID));
            foreach (var item in ZeroCustomer)
            {
                PersistenceData.Ranks.Add(new Entities.RankEntity { CustomerID = item.CustomerID, Score = 0 });
            }
            var sorted = PersistenceData.Ranks.OrderByDescending(x => x.Score).ThenByDescending(x=>x.CustomerID).ToList();
            PersistenceData.Ranks.ForEach(a => { 
                    a.RankNum = sorted.FindIndex(s => s.Score == a.Score&&a.CustomerID==s.CustomerID) + 1;
            });
            PersistenceData.Ranks.Sort((a, b) => {
                if (a.RankNum==b.RankNum)
                {
                  return  a.CustomerID > b.CustomerID?1:-1;
                }
                return a.RankNum > b.RankNum ? 1:-1 ;
                 }) ;

           
        }
    }
}
