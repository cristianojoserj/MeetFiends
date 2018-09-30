using System.Linq;
using System.Collections.Generic;
using MeetFriends.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetFriends.Test
{
    [TestClass]
    public class UnitTestGeoDistance
    {
        [TestMethod]
        public void TestGeoDistanceValid()
        {
            var distance = new GeoDistance();

            #region Situation

            var la1 = -22.880743;
            var lo1 = -43.5886937;
            var la2 = -23.0107316;
            var lo2 = -43.3080803;

            #endregion

            #region Action

            var result = distance.GetDistanceKm(la1, lo1, la2, lo2);

            #endregion

            #region Validation

            double valorEsperado = 32.140232020407659;

            Assert.AreEqual(valorEsperado, result);

            #endregion
        }

        [TestMethod]
        public void TestGeoDistanceInvalid()
        {
            var distance = new GeoDistance();

            #region Situation

            var la1 = -22.880743;
            var lo1 = -43.5886937;
            var la2 = -23.0107316;
            var lo2 = -43.3080803;

            #endregion

            #region Action

            var result = distance.GetDistanceKm(la1, lo1, la2, lo2);

            #endregion

            #region Validation

            double valorEsperado = 0;

            Assert.AreNotEqual(valorEsperado, result);

            #endregion
        }

        [TestMethod]
        public void TestGeoDistanceOrderedMaxThree()
        {
            var distance = new GeoDistance();
            var listFriend = new List<Friend>();

            #region Situation

            listFriend.Add(new Friend()
            {
                Id = 1,
                Name = "Ricardo",
                FriendAddress = new FriendAddress()
                {
                    Id = 0,
                    Address = "Campo Grande RJ",
                    NumberLatitude = -22.9035842,
                    NumberLongitude = -43.5662438
                }
            });

            listFriend.Add(new Friend()
            {
                Id = 2,
                Name = "Júlio Cesar",
                FriendAddress = new FriendAddress()
                {
                    Id = 0,
                    Address = "Mangaratiba RJ",
                    NumberLatitude = -22.9161789,
                    NumberLongitude = -44.0389554
                }
            });

            listFriend.Add(new Friend()
            {
                Id = 3,
                Name = "Cesar",
                FriendAddress = new FriendAddress()
                {
                    Id = 0,
                    Address = "Rio das Ostras RJ",
                    NumberLatitude = -22.4650817,
                    NumberLongitude = -41.9394892
                }
            });

            listFriend.Add(new Friend()
            {
                Id = 4,
                Name = "Ronaldo",
                FriendAddress = new FriendAddress()
                {
                    Id = 0,
                    Address = "São José dos Campos SP",
                    NumberLatitude = -23.223701,
                    NumberLongitude = -45.9009074
                }
            });

            #endregion

            #region Action

            List<Friend> resultListFriend = distance.ListFriendsNext(listFriend.Where(p => p.Id != 1).ToList(), listFriend.Where(p => p.Id == 1).FirstOrDefault());

            #endregion

            #region Validation

            Assert.AreEqual(resultListFriend.Count, 3);
            Assert.AreEqual(2, resultListFriend[0].Id);
            Assert.AreEqual(3, resultListFriend[1].Id);
            Assert.AreEqual(4, resultListFriend[2].Id);

            #endregion
        }
    }
}
