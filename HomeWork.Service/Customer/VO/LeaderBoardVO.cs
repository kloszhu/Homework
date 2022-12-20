using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.Customer.VO
{
    public class LeaderBoardVO
    {

        public int? start { get; set; }
        public int? end { get; set; }
        public long CustomerId { get;  set; }
    }
}
