using HomeWork.Service.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service.Channel
{
    public class ChannelServie : IChannelServie
    {
        private ILeaderBoardService leaderBoardService;

        public ChannelServie(ILeaderBoardService leaderBoardService)
        {
            this.leaderBoardService = leaderBoardService;
        }

        public void Publish(Entities.Entities.MessageType message) {
            PersistenceData.Channels.Add(new Entities.Entities.ChannelEntity { Key = message });
        }
        public void Publish(Entities.Entities.MessageType message, long customerId, int Score)
        {
            PersistenceData.Channels.Add(new Entities.Entities.ChannelEntity
            {
                Key = message,
                Params = new Entities.Entities.ParamsEntity
                {
                    CustomerId = customerId,
                    Score = Score
                }
            }); ;
        }


        //private object lockobj = new object();
        public void Subscribe()
        {
            Task.Factory.StartNew(() => {
                
                    while (true)
                    {
                    lock (PersistenceData.Channels)
                    {
                        if (PersistenceData.Channels!=null&&PersistenceData.Channels.Count>0)
                        {
                            for (int i = 0; i < PersistenceData.Channels.Count; i++)
                            {
                                switch (PersistenceData.Channels[i].Key)
                                {
                                    case Entities.Entities.MessageType.ReRank:
                                        leaderBoardService.ReRank(PersistenceData.Channels[i].Params.CustomerId, PersistenceData.Channels[i].Params.Score);
                                        break;
                                    default:
                                        break;
                                }
                                PersistenceData.Channels.Remove(PersistenceData.Channels[i]);

                            }
                            
                        }

                    }

                }
               
            });
            
        }

       
    }
}
