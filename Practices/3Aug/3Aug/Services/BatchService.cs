using _3Aug.Repository;
using _3Aug.Models;

namespace _3Aug.Services
{
    public class BatchService: IBatchService
    {
        private static List<Batch> batches = new List<Batch>()
        {
            new Batch() {Id=101, Name="A Batch", NoOfStudents=30 },
            new Batch() {Id=102, Name="B Batch", NoOfStudents=30 },
            new Batch() {Id=103, Name="C Batch", NoOfStudents=30 },
        };

        public void AddBatch(Batch batch)
        {
            batches.Add(batch);
        }

        public void DeleteBatch(int id)
        {
            var existing = GetBatch(id);
            if (existing == null)
                throw new Exception("Batch not found");
            batches.Remove(existing);
        }

        public List<Batch> GetBatches()
        {
            return batches;
        }
        public Batch? GetBatch(int id)
        {
            return batches.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateBatch(int id,Batch batch)
        {
            var existing = GetBatch(batch.Id);
            if (existing == null)
                throw new Exception("Batch not found");
            existing.NoOfStudents = batch.NoOfStudents;

        }

    }
}
