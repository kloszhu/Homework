using HomeWork.Service.Channel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.Customer
{

    public class CustomerService : ICustomerService
    {
        private IChannelServie _channelServie;

        public CustomerService(IChannelServie channelServie)
        {
            _channelServie = channelServie;
        }

        public decimal UpdateScore(long customerid, int score)
        {
            var first = PersistenceData.Scores.FirstOrDefault(a => a.CustomerID == customerid);
            ///如果存在该客户，则修改
            ///
            if (first == null)
            {
                first = new Entities.ScoreEntity { CustomerID = customerid, ScoreNum = score };
                PersistenceData.Scores.Add(first);
                PersistenceData.Customers.Add(new Entities.CustomerEntity { CustomerID = customerid });
            }
            else
            {

                first.ScoreNum += score;
            }
            _channelServie.Publish(Entities.Entities.MessageType.ReRank,customerid,score);
            return first.ScoreNum;
        }
    }
}
