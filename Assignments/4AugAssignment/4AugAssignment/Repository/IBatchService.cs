

using _4AugAssignment.Models;

namespace _4AugAssignment.Repository
    
{
    public interface IBatchService
    {
        List<Batch> GetBatches();
        Batch GetBatch(int id);
        void AddBatch(Batch batch);
        void UpdateBatch(Batch batch);
        void DeleteBatch(int id);

    }
}
