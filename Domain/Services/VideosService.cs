using Domain.DAL;
using Domain.Dtos;
using Domain.Entities;
using Domain.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class VideosService : IVideosService
    {
        #region Properties

        private VideoDbContext _dbContext;

        #endregion
        #region Constructors

        public VideosService(VideoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion
        #region Members

        public async Task<BusinessResult> AddCategoryToVideo(long videoId, VideoCategorySaveDto videoCategoriesSave)
        {
            var categoriesIds = videoCategoriesSave.Categories.Select(x => x.Id);
            var categoriesToSave = new List<VideoCategory>();
            var video = await _dbContext.Videos.FirstOrDefaultAsync(x => x.Id == videoId);
            var categories = await _dbContext.Categories.Where(x => categoriesIds.Contains(x.Id)).ToListAsync();

            if (video == null || (categories == null || categories.Count == 0)) {
                return new BusinessResult()
                {
                    IsSuccessful = false,
                    Message = "Missing video or categories"
                };
            }

            categories.ForEach(x => categoriesToSave.Add(new VideoCategory() { Video = video, Category = x }));
            _dbContext.VideoCategories.AddRange(categoriesToSave);
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                var videoCategories = await _dbContext.VideoCategories.Include(x => x.Category).Where(x => x.VideoId == videoId)
                    .Select(x => new VideoCategoryDto { Id = x.Id, VideoId = x.VideoId, Category = new CategoryDto() { Id = x.Category.Id, Name = x.Category.Name } }).ToListAsync();
                return new BusinessResult() { IsSuccessful = true, ObjectResult = videoCategories };
            }

            return new BusinessResult() { IsSuccessful = false };
        }

        public async Task<BusinessResult> AddImageToVideo(long videoId, VideoImageSaveDto video)
        {
            throw new System.NotImplementedException();
        }

        public Task<BusinessResult> AddVideo(VideoSaveDto video)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BusinessResult> DeleteCategoryVideo(long videoId, long videoImageId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BusinessResult> DeleteImageVideo(long videoId, long videoImageId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BusinessResult> DeleteVideo(long videoId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BusinessResult> FindVideos(VideoQueryOptions videoQueryOptions)
        {
            var result = new BusinessResult();
            var videos = await GetFilteredVideos(videoQueryOptions);

            if (videos != null)
            {
                result.IsSuccessful = true;
                result.Count = videos.Count;
                result.ObjectResult = videos;
            }

            return result;
        }

        public async Task<BusinessResult> GetVideo(long videoId)
        {
            var video = await _dbContext.Videos.FirstOrDefaultAsync(x => x.Id == videoId);

            if (video == null)
            {
                return new BusinessResult()
                {
                    IsSuccessful = false
                };
            }

            return new BusinessResult()
            {
                IsSuccessful = true,
                ObjectResult = video
            };
        }

        public async Task<BusinessResult> UpdateVideo(VideoSaveDto video)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Video>> GetFilteredVideos(VideoQueryOptions videoQueryOptions)
        {
            var videosQuery = _dbContext.Videos.AsQueryable();

            if (videoQueryOptions.AgeGroup.HasValue)
            {
                videosQuery = videosQuery.Where(x => x.AgeGroup == videoQueryOptions.AgeGroup.Value);
            }

            if (!string.IsNullOrEmpty(videoQueryOptions.VideoType))
            {
                videosQuery = videosQuery.Where(x => x.VideoType.Name == videoQueryOptions.VideoType);
            }

            if (!string.IsNullOrEmpty(videoQueryOptions.SearchValue))
            {
                videosQuery = videosQuery.Where(x => EF.Functions.Like(x.Title, $"%{videoQueryOptions.SearchValue}%") ||
                                                    (x.Description != null && EF.Functions.Like(x.Description, $"%{videoQueryOptions.SearchValue}%")));
            }

            if (videoQueryOptions.Categories != null && videoQueryOptions.Categories.Length > 0)
            {
                videosQuery = videosQuery.Where(x => x.VideoCategories.Any(y => videoQueryOptions.Categories.Contains(y.CategoryId)));
            }

            if (videoQueryOptions.AvailabilityFrom.HasValue)
            {
                videosQuery = videosQuery.Where(x => x.AvailabilityFrom == videoQueryOptions.AvailabilityFrom);
            }

            if (videoQueryOptions.AvailabilityTo.HasValue)
            {
                videosQuery = videosQuery.Where(x => x.AvailabilityFrom == videoQueryOptions.AvailabilityTo);
            }

            videosQuery = videosQuery.Include(x => x.VideoType);

            if (videoQueryOptions.Page.HasValue)
            {
                var skip = videoQueryOptions.Page.Value * videoQueryOptions.PageSize.Value;
                var resultVideos = await videosQuery.Skip(skip).Take(videoQueryOptions.PageSize.Value).ToListAsync();
            }

            return await videosQuery.Take(videoQueryOptions.PageSize.Value).ToListAsync();
        }

        #endregion


    }
}
