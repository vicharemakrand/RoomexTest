using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using RoomexTest.CalculationStrategies;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.Helpers;
using RoomexTest.ViewModel;

namespace RoomexTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SphereController : ControllerBase
    {

      
        [HttpGet("Strategy1/GetDistance")]
        public ActionResult<ResponseResult> GetDistanceByStrategy1(string unit, double latA, double lonA, double latB, double lonB)
        {
            var viewModel = new Strategy1ViewModel
            {
                PointA = new CoordinateViewModel {  Latitude = latA, Longitute= lonA },
                PointB = new CoordinateViewModel { Latitude = latB, Longitute = lonB },
                Unit = unit
            };

            var calculator = new DistanceCalulator();
            calculator.SetStrategy(new Strategy1(new Strategy1Validator()));

            return calculator.CalculateDistance(viewModel);
        }

        [HttpGet("Strategy2/GetDistance")]
        public ActionResult<ResponseResult> GetDistanceByStrategy2(string unit, double latA, double lonA, double latB, double lonB)
        {
            var viewModel = new Strategy2ViewModel
            {
                PointA = new CoordinateViewModel { Latitude = latA, Longitute = lonA },
                PointB = new CoordinateViewModel { Latitude = latB, Longitute = lonB },
                Unit = unit,
                EarthRadius = AppConstants.EarthRadius
            };

            var calculator = new DistanceCalulator();
            calculator.SetStrategy(new Strategy2(new Strategy2Validator()));

            return calculator.CalculateDistance(viewModel);

        }

    }
}
