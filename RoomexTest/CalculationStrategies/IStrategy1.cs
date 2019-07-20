using RoomexTest.ViewModel;
using RoomexTest.ViewModel.Base;

namespace RoomexTest.CalculationStrategies
{
    public interface IStrategy1
    {
        ResponseResult CalculateDistanceInKM<T>(T viewModel) where T : BaseStrategyViewModel;
        ResponseResult CalculateDistanceInMile<T>(T viewModel) where T : BaseStrategyViewModel;
    }
}