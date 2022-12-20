using HomeWork.Service.Channel;
using HomeWork.Service.Customer;
using HomeWork.Service.Leaderboard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Service
{
    public static class DepencyExtention
    {
        public static IServiceCollection AddCustomerScoreAndRankBusiness(this IServiceCollection services) {
            services.AddSingleton<IChannelServie, ChannelServie>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ILeaderBoardService, LeaderBoardService>();
            return services;
        }
    }
}
