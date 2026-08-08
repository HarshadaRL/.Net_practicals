using _3Aug.Models;

namespace _3Aug.Repository
{
    public interface IBatchService
    {
        List<Batch> GetBatches();
        void AddBatch(Batch batch);
        Batch GetBatch(int id);
        void DeleteBatch(int id);
        void UpdateBatch(int id,Batch batch);
    }
}
