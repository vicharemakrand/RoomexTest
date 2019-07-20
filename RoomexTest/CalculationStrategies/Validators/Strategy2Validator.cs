using RoomexTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies.Validators
{
    public class Strategy2Validator : BaseValidator<Strategy2ViewModel>, IStrategy2Validator
    {
        public override ResponseResult Validate(Strategy2ViewModel viewModel)
        {
            var response = base.Validate(viewModel);
            var message = new StringBuilder(response.Message);


            if (viewModel.PointB != null)
            {

                if (viewModel.PointB.Latitude > 180 || viewModel.PointB.Latitude < -180)
                {
                    message.AppendLine("Invalid Latitude for point B");
                }


                if (viewModel.PointB.Longitute > 180 || viewModel.PointB.Longitute < -180)
                {
                    message.AppendLine("Invalid Longitute for point B");
                }

            }
            if (viewModel.PointA != null)
            {

                if (viewModel.PointA.Latitude > 180 || viewModel.PointA.Latitude < -180)
                {
                    message.AppendLine("Invalid Latitude for point A");
                }


                if (viewModel.PointA.Longitute > 180 || viewModel.PointA.Longitute < -180)
                {
                    message.AppendLine("Invalid Longitute for point A");
                }

            }

            if (viewModel.EarthRadius <= 0)
            {
                message.AppendLine("Invalid radius");
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
