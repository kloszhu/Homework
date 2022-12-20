using HomeWork.Service.Customer.VO;
using HomeWork.Service.Leaderboard;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.API.Controllers
{
    [ApiController]
    public class LeaderboardController : Controller
    {
        private ILeaderBoardService _leaderBoardService;

        public LeaderboardController(ILeaderBoardService leaderBoardService)
        {
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet("/leaderboard")]
        public IActionResult leaderboard([FromQuery,Required] long CustomerId, [FromQuery] int? start, [FromQuery] int? end)
        {

            return Ok(_leaderBoardService.GetRanksByScore(new LeaderBoardVO { CustomerId=CustomerId, start=start, end=end }));
        }

        [HttpGet("/leaderboard/{customerid}")]
        public IActionResult GetcustomersBycustomerid([FromRoute]long customerid,[FromQuery]int? high, [FromQuery] int? low) {
            return Ok(_leaderBoardService.GetRanksByRanks(customerid, high, low));
        }
    }
}
