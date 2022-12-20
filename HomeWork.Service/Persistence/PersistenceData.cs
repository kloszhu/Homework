using HomeWork.Entities;
using HomeWork.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service;

public static class PersistenceData
{
    #region PersistenceData
    public static List<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
    public static List<ScoreEntity> Scores { get; set; } = new List<ScoreEntity>();
    public static List<RankEntity> Ranks { get; set; } = new List<RankEntity>();
    public static List<IdGenerateEntity> Ids { get; set; } = new List<IdGenerateEntity>();
    public static List<ChannelEntity> Channels { get;  set; } = new List<ChannelEntity>();
    #endregion
}
