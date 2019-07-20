using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.ViewModel;

namespace Roomex.UnitTest
{
    [TestClass]
    public class Stategy2ValidatorTest
    {
        private IStrategy2Validator validator;

        private Strategy2ViewModel viewModel;
        [TestInitialize]
        public void Initialize()
        {
            validator = new Strategy2Validator();

            viewModel = new Strategy2ViewModel
            {
                PointA = new CoordinateViewModel { Latitude =32.3,Longitute=43.34},
                PointB = new CoordinateViewModel { Latitude = 122.3332443, Longitute = -43.3886 },
                Unit = "km",
                EarthRadius = 4544
            };
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void Validate_ValidInput_returnsSucceedIsTrue()
        {
            //Arrange 

            var response = validator.Validate(viewModel);
            Assert.IsTrue(response.IsSucceed);
        }

        [TestMethod]
        public void Validate_InValidPointA_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.PointA = null;

            var response = validator.Validate(viewModel);
            Assert.IsFalse(response.IsSucceed);
        }

        [TestMethod]
        public void Validate_InValidPointB_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.PointB = null;

            var response = validator.Validate(viewModel);
            Assert.IsFalse(response.IsSucceed);
        }

        [TestMethod]
        public void Validate_InValidPointALonituteMoreThanMax_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.PointA.Longitute = 200;

            var response = validator.Validate(viewModel);
            Assert.IsFalse(response.IsSucceed);
        }

        [TestMethod]
        public void Validate_InValidPointALonituteLessThanMin_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.PointA.Longitute = -200;

            var response = validator.Validate(viewModel);
            Assert.IsFalse(response.IsSucceed);
        }

        [TestMethod]
        public void Validate_InValidEarthRadiuLessThan0_returnsSucceedIsFalse()
        {
            //Arrange 

            viewModel.EarthRadius = -60;

            var response = validator.Validate(viewModel);
            Assert.IsFalse(response.IsSucceed);
        }
    }
}
