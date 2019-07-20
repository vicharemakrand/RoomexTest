using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoomexTest.CalculationStrategies.Validators;
using RoomexTest.ViewModel;

namespace Roomex.UnitTest
{
    [TestClass]
    public class Stategy1ValidatorTest
    {
        private IStrategy1Validator validator;

        private Strategy1ViewModel viewModel;
        [TestInitialize]
        public void Initialize()
        {
            validator = new Strategy1Validator();

            viewModel = new Strategy1ViewModel
            {
                PointA = new CoordinateViewModel { Latitude =32.3,Longitute=43.34},
                PointB = new CoordinateViewModel { Latitude = 122.3332443, Longitute = -43.3886 },
                Unit = "km"
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
    }
}
