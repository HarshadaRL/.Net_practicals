using _4AugAssignment.Repository;
using _4AugAssignment.Data;
using _4AugAssignment.Models;

namespace _4AugAssignment.Service
{
    public class BatchService: IBatchService
    {
        private readonly AppDbContext context;
        public BatchService(AppDbContext context)
        {
            this.context = context;
        }
        public void AddBatch(Batch batch)
        {
            context.Batches.Add(batch);
            context.SaveChanges();
        }
        public void DeleteBatch(int id)
        {
            var batch = context.Batches.Find(id);
            if (batch != null)
            {
                context.Batches.Remove(batch);
                context.SaveChanges();
            }
        }
        public List<Batch> GetBatches()
        {
            return context.Batches.ToList();
        }
        public Batch? GetBatch(int id)
        {
            return context.Batches.Find(id);
        }
        public void UpdateBatch(Batch batch)
        {
            context.Batches.Update(batch);
            context.SaveChanges();
        }
    }
}
