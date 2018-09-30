using MeetFriends.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetFriends.Test
{
    [TestClass]
    public class UnitTestFriendAddress
    {
        [TestMethod]
        public void TestFriendAddressValid()
        {
            #region Situation

            var friendAddress = new FriendAddress()
            {
                Id = 0,
                Address = "Rua A",
                NumberLatitude = -22880743,
                NumberLongitude = -435886937
            };            

            #endregion

            #region Action

            bool isValid = friendAddress.IsValid();

            #endregion

            #region Validation

            Assert.AreEqual(true, isValid);

            #endregion
        }

        [TestMethod]
        public void TestFriendAddressInvalid()
        {
            #region Situation

            var friendAddress = new FriendAddress()
            {
                Id = 0,
                NumberLatitude = 0,
                NumberLongitude = 0
            };

            #endregion

            #region Action

            bool isValid = friendAddress.IsValid();

            #endregion

            #region Validation

            Assert.AreEqual(false, isValid);

            #endregion
        }
    }
}
