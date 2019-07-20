using GeoCoordinatePortable;
using RoomexTest.CalculationStrategies.Base;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.Helpers;
using RoomexTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies
{
    public class Strategy2 : BaseStrategy, IStrategy2
    {
        IStrategy2Validator validator;
        public Strategy2(IStrategy2Validator _validator)
        {
            validator = _validator;
        }
        public override ResponseResult CalculateDistanceInKM<T>(T viewModel)
        {
            return CalculateDistance(viewModel as Strategy2ViewModel);
        }

        public override ResponseResult CalculateDistanceInMile<T>(T viewModel)
        {
            var response = CalculateDistance(viewModel as Strategy2ViewModel);
            if (response.IsSucceed)
            {
                response.Result = AppMethods.ConvertKMToMile(response.Result);
            }
            return response;
        }

        private ResponseResult CalculateDistance(Strategy2ViewModel viewModel)
        {

            var response = validator.Validate(viewModel);

            if (!response.IsSucceed)
            {
                return response;
            }

            var a = AppConstants.Degree90 - viewModel.PointB.Latitude;
            var b = AppConstants.Degree90 - viewModel.PointA.Latitude;
            var c = viewModel.PointA.Longitute - viewModel.PointB.Longitute;

            response.Result = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(c) * viewModel.EarthRadius;

            return response;

        }
    }
}
