
using _03Aug2026_Ass.Models;

namespace _03Aug2026_Ass.Repository
{
    public interface IBatchService
    {
        List<Batch> GetAll();

        Batch? GetBatch(int id);

        void AddBatch(Batch batch);

        void UpdateBatch(Batch batch);

        void DeleteBatch(int id);
    }
}