using MeetFriends.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetFriends.Test
{
    [TestClass]
    public class UnitTestFriend
    {
        [TestMethod]
        public void TestFriendValid()
        {
            #region Situation

            var friend = new Friend()
            {
                Id = 0,
                Name = "Júlio Cesar",
                FriendAddress = new FriendAddress()
                {
                    Id = 0,
                    Address = "Rua A",
                    NumberLatitude = -22880743,
                    NumberLongitude = -435886937
                }
            };

            #endregion

            #region Action

            bool isValid = friend.IsValid();

            #endregion

            #region Validation

            Assert.AreEqual(true, isValid);

            #endregion
        }

        [TestMethod]
        public void TestFriendInvalid()
        {
            #region Situation

            var friend = new Friend()
            {
                Id = 0,
                Name = null,
                FriendAddress = null
            };

            #endregion

            #region Action

            bool isValid = friend.IsValid();

            #endregion

            #region Validation

            Assert.AreEqual(false, isValid);

            #endregion
        }   
    }
}
