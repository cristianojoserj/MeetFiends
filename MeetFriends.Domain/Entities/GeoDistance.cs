using System;
using System.Linq;
using System.Collections.Generic;

namespace MeetFriends.Domain.Entities
{
    public class GeoDistance
    {
        #region Methods

        public double GetDistanceKm(double latitude, double longitude, double otherLatitude, double otherLongitude)
        {
            double circumference = 40000.0;

            double latitude1Rad = (Math.PI / 180) * latitude;
            double latititude2Rad = (Math.PI / 180) * otherLatitude;
            double longitude1Rad = (Math.PI / 180) * longitude;
            double longitude2Rad = (Math.PI / 180) * otherLongitude;
            double logitudeDiff = Math.Abs(longitude1Rad - longitude2Rad);

            if (logitudeDiff > Math.PI)
                logitudeDiff = 2.0 * Math.PI - logitudeDiff;

            double angleCalculation =
                Math.Acos(Math.Sin(latititude2Rad) * Math.Sin(latitude1Rad) +
                Math.Cos(latititude2Rad) * Math.Cos(latitude1Rad) * Math.Cos(logitudeDiff));

            return circumference * angleCalculation / (2.0 * Math.PI);
        }

        public List<Friend> ListFriendsNext(List<Friend> friends, Friend friendVisit)
        {
            var friendsDistance = new List<Friend>();
            foreach (var item in friends)
            {
                var distance = new GeoDistance();
                item.Distance = distance.GetDistanceKm(friendVisit.FriendAddress.NumberLatitude,
                                                     friendVisit.FriendAddress.NumberLongitude,
                                                     item.FriendAddress.NumberLatitude,
                                                     item.FriendAddress.NumberLongitude);
                friendsDistance.Add(item);
            }

            return friendsDistance
                .OrderBy(p => p.Distance)
                .Take(3)
                .ToList();
        }

        #endregion
    }
}
