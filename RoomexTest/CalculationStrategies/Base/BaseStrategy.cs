using RoomexTest.ViewModel;
using RoomexTest.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomexTest.CalculationStrategies.Base
{
    public abstract class BaseStrategy

    {
        public abstract ResponseResult CalculateDistanceInKM<T>(T viewModel) where T : BaseStrategyViewModel;
        public abstract ResponseResult CalculateDistanceInMile<T>(T viewModel) where T : BaseStrategyViewModel;
    }
}
