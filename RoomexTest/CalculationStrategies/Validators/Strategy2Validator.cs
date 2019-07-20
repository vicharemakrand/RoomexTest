using RoomexTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies.Validators
{
    public class Strategy2Validator : BaseValidator<Strategy2ViewModel>, IStrategy2Validator
    {
        public override ResponseResult Validate(Strategy2ViewModel viewModel)
        {
            var response = base.Validate(viewModel);
            if (viewModel.EarthRadius <= 0)
            {
                response.IsSucceed = false;
                response.Message += "Invalid radius";
            }
            return response;
        }
    }
}
