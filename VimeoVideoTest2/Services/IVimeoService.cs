namespace VimeoVideoTest2.Services
{
    public interface IVimeoService
    {
        Task<List<VideoData>> GetPrivateChannelVideosAsync(long channelId, string query);
    }
}
