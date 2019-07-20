using RoomexTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies.Validators
{
    public class Strategy1Validator : BaseValidator<Strategy1ViewModel>, IStrategy1Validator
    {
        public override ResponseResult Validate(Strategy1ViewModel viewModel)
        {
            var response = base.Validate(viewModel);
            var message = new StringBuilder(response.Message);
            if (viewModel.PointA != null)
            {
                if (viewModel.PointA.Latitude > 90 || viewModel.PointA.Latitude < -90)
                {
                    message.AppendLine("Invalid Latitude for point A");
                }

                if (viewModel.PointA.Longitute > 90 || viewModel.PointA.Longitute < -90)
                {
                    message.AppendLine("Invalid Longitute for point A");
                }
            }

            if (viewModel.PointB != null)
            {
                if (viewModel.PointB.Latitude > 90 || viewModel.PointB.Latitude < -90)
                {
                    message.AppendLine("Invalid Latitude for point B");
                }

                if (viewModel.PointB.Longitute > 90 || viewModel.PointB.Longitute < -90)
                {
                    message.AppendLine("Invalid Longitute for point B");
                }
            }

            if (message.Length > 0)
            {
                response.IsSucceed = false;
                response.Message = message.ToString();
            }

            return response;
        }
    }
}
