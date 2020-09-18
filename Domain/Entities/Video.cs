using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Video
    {
        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short AgeGroup { get; set; }
        public DateTime AvailabilityFrom { get; set; }
        public DateTime? AvailabilityTo { get; set; }
        public string Url { get; set; }
        public long? ParentVideoId { get; set; }
        public int VideoTypeId { get; set; }

        public virtual Video ParentVideo { get; set; }
        public VideoType VideoType  { get; set; }

        public virtual ICollection<Video> SubVideos { get; set; }
        public virtual ICollection<VideoCategory> VideoCategories { get; set; }
        public virtual ICollection<VideoImage> VideoImages { get; set; }
        public virtual ICollection<VideoCast> VideoCasts { get; set; }

        #endregion
    }
}
