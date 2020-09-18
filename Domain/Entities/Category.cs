using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Predefined { get; set; }

        public virtual ICollection<VideoCategory> VideoCategories { get; set; }

        #endregion
    }
}
