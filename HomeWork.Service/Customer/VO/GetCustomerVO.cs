using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.Customer.VO
{
    public class GetCustomerVO
    {
        [Required,FromRoute]
        public long customerid { get; set; }
        [FromQuery]
        public int low { get; set; }
        [FromQuery]
        public int high { get; set; }
    }
}
