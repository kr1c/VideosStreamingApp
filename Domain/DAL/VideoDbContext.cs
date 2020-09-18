using Microsoft.EntityFrameworkCore;

namespace Domain.DAL
{
    public class VideoDbContext : DbContext
    {
        #region Properties

        #endregion
        #region Constructors

        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options) { }

        #endregion
        #region Overrides

        #endregion
    }
}
