namespace Core.Application.Pipelines.Caching
{
    public interface ICachableRequest
    {
        bool BypassCache { get; }
        //ByPassCache işlemi cache ile yapıp yapmıyacagımızı soruyor örneğin database verileri çekebiliriz.

        string CacheKey { get; }
        //CacheKey key-value ikilisiyle çalıştıgı için key'e göre verileri Memory'de getirecektir.

        TimeSpan? SlidingExpiration { get; }
    }
}
