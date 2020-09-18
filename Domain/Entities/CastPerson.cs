using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CastPerson
    {
        #region Properties

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public int CastPersonTypeId { get; set; }
        public CastPersonType CastPersonType { get; set; }
        public virtual ICollection<VideoCast> VideoCasts { get; set; }

        #endregion
    }
}
