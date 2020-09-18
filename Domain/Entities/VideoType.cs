using System.Collections.Generic;

namespace Domain.Entities
{
    public class VideoType
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        #endregion
    }
}
