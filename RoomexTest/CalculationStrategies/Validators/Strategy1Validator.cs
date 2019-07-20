using RoomexTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies.Validators
{
    public class Strategy1Validator : BaseValidator<Strategy1ViewModel>, IStrategy1Validator
    {
        public override ResponseResult Validate(Strategy1ViewModel viewModel)
        {
            return base.Validate(viewModel);
        }
    }
}
