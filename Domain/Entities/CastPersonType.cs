using System.Collections.Generic;

namespace Domain.Entities
{
    public class CastPersonType
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CastPerson> CastPersons { get; set; }

        #endregion
    }
}
