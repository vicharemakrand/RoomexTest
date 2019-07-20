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
    public class Strategy1 : BaseStrategy, IStrategy1
    {
        IStrategy1Validator validator;
        public Strategy1(IStrategy1Validator _validator)
        {
            validator = _validator;
        }
        public override ResponseResult CalculateDistanceInKM<T>(T viewModel)
        {
            var response = CalculateDistance(viewModel as Strategy1ViewModel);
            if (response.IsSucceed)
            {
                response.Result = AppMethods.ConvertMeterToKm(response.Result);
            }
            return response;
        }

        public override ResponseResult CalculateDistanceInMile<T>(T viewModel)
        {
            var response = CalculateDistance(viewModel as Strategy1ViewModel);
            if (response.IsSucceed)
            {
                response.Result = AppMethods.ConvertMeterToMile(response.Result);
            }
            return response;
        }

        private ResponseResult CalculateDistance(Strategy1ViewModel viewModel)
        {
            var response = validator.Validate(viewModel);

            if (!response.IsSucceed)
            {
                return response;
            }

            GeoCoordinate pin1 = new GeoCoordinate(viewModel.PointA.Latitude, viewModel.PointA.Longitute);
            GeoCoordinate pin2 = new GeoCoordinate(viewModel.PointB.Latitude, viewModel.PointB.Longitute);

            response.Result = pin1.GetDistanceTo(pin2);

            return response;

        }
    }
}
