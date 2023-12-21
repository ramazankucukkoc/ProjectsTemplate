namespace Core.Application.Pipelines.Caching
{
    public interface ICacheRemoverRequest
    {
        //Burada cacheden verileri silme işlemi için kullanılıyor.
        bool BypassCache { get; }
        string CacheKey { get; }
        //CacheKey key-value ikilisiyle çalıştıgı için key'e göre verileri Memory'de silecektir.

    }
}
