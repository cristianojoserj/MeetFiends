using System;

namespace MeetFriends.Domain.Entities
{
    public class Friend : EntityBase<int>
    {
        #region Builder

        public Friend()
        {
            FriendAddress = new FriendAddress();
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public FriendAddress FriendAddress { get; set; }
        public double Distance { get; set; }
        public DateTime MetDate { get; set; } = DateTime.Now;

        public bool OldFriend(Friend friend)
        {
            return friend.Active && DateTime.Now.Year - MetDate.Year >= 5;
        }

        #endregion

        #region Methods

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (FriendAddress == null)
                return false;

            return true;
        }

        #endregion
    }
}
