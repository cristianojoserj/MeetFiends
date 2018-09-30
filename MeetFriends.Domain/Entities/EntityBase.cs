using System;

namespace MeetFriends.Domain.Entities
{
    public abstract class EntityBase<T> where T : struct
    {
        #region Properties 

        public T Id { get; set; }
        public DateTime DateCreate = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
        public bool Active { get; set; } = true;

        #endregion
    }
}
