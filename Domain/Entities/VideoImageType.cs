using System.Collections.Generic;

namespace Domain.Entities
{
    public class VideoImageType
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VideoImage> VideoImages { get; set; }

        #endregion
    }
}
