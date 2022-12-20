using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Entities.Entities
{
    public enum ModuleType { 
    IDGenerate,
    Customer,
    Rank,
    Score,
    }
    public class IdGenerateEntity
    {
        public long Id { get; set; }
        public ModuleType Module { get; set; }
        public long IDCode { get; set; } = 100000;

    }
}
