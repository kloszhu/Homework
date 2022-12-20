using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Entities.Entities
{
    public enum MessageType { 
       ReRank
    }
    /// <summary>
    /// 处理消息,简单内部RPC
    /// </summary>
    public class ChannelEntity
    {
        public long Id { get; set; }
        public MessageType Key { get; set; }
        public ParamsEntity Params { get; set; }

    }

    public class ParamsEntity
    {
        public long CustomerId { get; set; }
        public decimal Score { get; set; }
    }
}
