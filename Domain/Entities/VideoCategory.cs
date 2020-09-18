namespace Domain.Entities
{
    public class VideoCategory
    {
        #region Properties

        public long Id { get; set; }
        public long VideoId { get; set; }
        public long CategoryId { get; set; }
        public virtual Video Video { get; set; }
        public Category Category { get; set; }

        #endregion
    }
}
