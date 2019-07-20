using RoomexTest.CalculationStrategies.Base;
using RoomexTest.ViewModel;
using RoomexTest.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomexTest.CalculationStrategies
{
    public class DistanceCalulator : IDistanceCalulator

    {

        private BaseStrategy _strategy;

        // Constructor

        public void SetStrategy(BaseStrategy strategy)
        {
            this._strategy = strategy;
        }


        public ResponseResult CalculateDistance(BaseStrategyViewModel viewModel)
        {
            ResponseResult result = new ResponseResult();
            switch (viewModel.Unit)
            {
                case "km":
                    {
                        result = CalculateDistanceInKM(viewModel);
                        break;
                    }
                case "mile":
                    {
                        result = CalculateDistanceInMile(viewModel);
                        break;
                    }
            }

            return result;
        }

        private ResponseResult CalculateDistanceInKM(BaseStrategyViewModel viewModel)
        {
            return _strategy.CalculateDistanceInKM(viewModel);
        }

        private ResponseResult CalculateDistanceInMile(BaseStrategyViewModel viewModel)
        {
            return _strategy.CalculateDistanceInMile(viewModel);
        }

    }
}
