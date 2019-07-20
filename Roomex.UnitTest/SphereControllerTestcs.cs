using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoomexTest.CalculationStrategies;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.Controllers;
using RoomexTest.ViewModel;

namespace Roomex.UnitTest
{
    [TestClass]
    public class SphereControllerTestcs
    {

        private Mock<IStrategy1> strategy1;

        private SphereController controller;

        private Strategy1ViewModel viewModel;

        private ResponseResult validResponse;
        private ResponseResult inValidResponse;

        [TestInitialize]
        public void Initialize()
        {
            strategy1 = new Mock<IStrategy1>();
            controller = new SphereController();
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetDistanceByStrategy1_ValidInput_returnsSucceedIsTrue()
        {
            //Arrange 
            string unit = "km";
            double latA = 32.3;
            double lonA = 54.565;
            double latB = 78.6;
            double lonB = 12.33;

            ActionResult<ResponseResult> response = controller.GetDistanceByStrategy1(unit, latA, lonA, latB, lonB) ;

            Assert.IsTrue(response.Value.IsSucceed );
            Assert.AreEqual(5525.1390015947527, response.Value.Result);
        }

        [TestMethod]
        public void GetDistanceByStrategy2_ValidInput_returnsSucceedIsTrue()
        {
            //Arrange 
            string unit = "km";
            double latA = 32.3;
            double lonA = 54.565;
            double latB = 78.6;
            double lonB = 12.33;

            ActionResult<ResponseResult> response = controller.GetDistanceByStrategy2(unit, latA, lonA, latB, lonB);

            Assert.IsTrue(response.Value.IsSucceed);
            Assert.AreEqual(939.417988949354, response.Value.Result);
        }

    }
}
