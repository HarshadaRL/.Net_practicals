using _03Aug2026_Ass.Models;

namespace _03Aug2026_Ass.Repository
{
    public class BatchService : IBatchService
    {
        private static List<Batch> batches = new List<Batch>()
        {
            new Batch
            {
                Id = 1,
                BatchName = "C# Batch",
                StudentName = "Divyansh",
                StartDate = new DateTime(2026, 8, 1),
                EndDate = new DateTime(2026, 10, 1),
                Fees = 25000
            },

            new Batch
            {
                Id = 2,
                BatchName = "Java Batch",
                StudentName = "Mayur",
                StartDate = new DateTime(2026, 8, 5),
                EndDate = new DateTime(2026, 11, 5),
                Fees = 30000
            }
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

        public List<Batch> GetAll()
        {
            return batches;
        }

        public Batch? GetBatch(int id)
        {
            return batches.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBatch(Batch batch)
        {
            var existing = GetBatch(batch.Id);

            if (existing == null)
                throw new Exception("Batch not found");

            existing.BatchName = batch.BatchName;
            existing.StudentName = batch.StudentName;
            existing.StartDate = batch.StartDate;
            existing.EndDate = batch.EndDate;
            existing.Fees = batch.Fees;
        }
    }
}