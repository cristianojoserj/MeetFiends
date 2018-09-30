
namespace MeetFriends.Domain.Entities
{
    public class FriendAddress : EntityBase<int>
    {
        #region Properties

        public string Address { get; set; }    
        public double NumberLatitude { get; set; }
        public double NumberLongitude { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Address))
                return false;

            if (NumberLatitude == 0)
                return false;

            if (NumberLongitude == 0)
                return false;

            return true;
        }

        #endregion
    }
}
