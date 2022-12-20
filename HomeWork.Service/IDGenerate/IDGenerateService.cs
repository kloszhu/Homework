using HomeWork.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.IDGenerate
{
    public class IDGenerateService
    {

        public long GetNext(ModuleType module) {

            var first = PersistenceData.Ids.First(a => a.Module == module);
            if (first == null)
            {
                var entity = new IdGenerateEntity { Module = module };
                PersistenceData.Ids.Add(entity);
                return entity.IDCode;
            }
            else {
                first.IDCode += 1;
                return first.IDCode;
            }
        }
    }
}
