using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.ViewModel.Base
{
    public abstract class BaseStrategyViewModel
    {
        public CoordinateViewModel PointA { get; set; }
        public CoordinateViewModel PointB { get; set; }

        public string Unit { get; set; }
    }
}
