
using Domain.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Abstract
{
    public interface IVideosService
    {
        Task<BusinessResult> AddVideo(VideoSaveDto video);
        Task<BusinessResult> UpdateVideo(VideoSaveDto video);
        Task<BusinessResult> FindVideos(VideoQueryOptions videoQueryOptions);
        Task<BusinessResult> GetVideo(long videoId);
        Task<BusinessResult> DeleteVideo(long videoId);
        Task<BusinessResult> AddCategoryToVideo(long videoId, VideoCategorySaveDto video);
        Task<BusinessResult> DeleteCategoryVideo(long videoId, long categoryId);
        Task<BusinessResult> AddImageToVideo(long videoId, VideoImageSaveDto video);
        Task<BusinessResult> DeleteImageVideo(long videoId, long videoImageId);
        Task<IList<Video>> GetFilteredVideos(VideoQueryOptions videoQueryOptions);
    }
}
