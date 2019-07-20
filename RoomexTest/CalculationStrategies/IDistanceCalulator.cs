using RoomexTest.CalculationStrategies.Base;
using RoomexTest.ViewModel;
using RoomexTest.ViewModel.Base;

namespace RoomexTest.CalculationStrategies
{
    public interface IDistanceCalulator
    {
        ResponseResult CalculateDistance(BaseStrategyViewModel viewModel);
        void SetStrategy(BaseStrategy strategy);
    }
}