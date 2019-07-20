using RoomexTest.ViewModel;
using RoomexTest.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomexTest.CalculationStrategies.Validators
{
    public abstract class BaseValidator<T> where T: BaseStrategyViewModel
    {
        public virtual ResponseResult Validate(T viewModel)
        {

            var response = new ResponseResult();
            var message = new StringBuilder("");

            if (string.IsNullOrEmpty(viewModel.Unit))
            {
                message.AppendLine("Invalid unit");
            }

            if(viewModel.PointA == null)
            {
                message.AppendLine("Invalid point A");
            }
            else
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

            if (viewModel.PointB == null)
            {
                message.AppendLine("Invalid point B");
            }
            else
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

            if (message.Length > 0)
            {
                response.IsSucceed = false;
                response.Message = message.ToString();
            }
            return response;
        }
    }
}
