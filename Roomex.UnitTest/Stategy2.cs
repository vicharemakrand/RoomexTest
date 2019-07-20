using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoomexTest.CalculationStrategies;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.ViewModel;

namespace Roomex.UnitTest
{
    [TestClass]
    public class Stategy2Test
    {
        private IStrategy2 strategy1;

        private Mock<IStrategy2Validator> validator;

        private Strategy2ViewModel viewModel;

        private ResponseResult validResponse;
        private ResponseResult inValidResponse;

        [TestInitialize]
        public void Initialize()
        {
            validator = new Mock<IStrategy2Validator>();
            strategy1 = new Strategy2(validator.Object);

            viewModel = new Strategy2ViewModel
            {
                PointA = new CoordinateViewModel { Latitude =32.3,Longitute=43.34},
                PointB = new CoordinateViewModel { Latitude = 82.3332443, Longitute = -43.3886 },
                Unit = "km",
            };

            validResponse = new ResponseResult { IsSucceed = true, Message = "Succeed" };
            inValidResponse = new ResponseResult { IsSucceed = false, Message = "Failed" };
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void CalculateDistanceInKM_ValidInput_returnsSucceedIsTrue()
        {
            //Arrange 

            validator.Setup(a => a.Validate(It.IsAny<Strategy2ViewModel>())).Returns(validResponse);

            var response = strategy1.CalculateDistanceInKM(viewModel);
            Assert.IsTrue(response.IsSucceed);
        }

        [TestMethod]
        public void CalculateDistanceInKM_InValidPointA_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.PointA = null;

            validator.Setup(a => a.Validate(It.IsAny<Strategy2ViewModel>())).Returns(inValidResponse);

            var response = strategy1.CalculateDistanceInKM(viewModel);

            validator.Verify(o => o.Validate(viewModel), Times.Once());

            Assert.IsFalse(response.IsSucceed);
        }


        [TestMethod]
        public void CalculateDistanceInMile_InValidEarthRadiuLessThan0_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.EarthRadius = 0;

            validator.Setup(a => a.Validate(It.IsAny<Strategy2ViewModel>())).Returns(inValidResponse);

            var response = strategy1.CalculateDistanceInMile(viewModel);

            validator.Verify(o => o.Validate(viewModel), Times.Once());

            Assert.IsFalse(response.IsSucceed);
        }
    }
}
