namespace Mission08_Team0113.Models
{
    public class EFHabitsRepository : IHabitsRepository
    {
        private Mission8Context _context;
                
        public EFHabitsRepository(Mission8Context temp) 
        {
            _context = temp;
        }

        public List<Category> Categories => _context.Categories.ToList();
        public List<Table> Tables => _context.Tables.ToList();

        public void AddTable(Table task)
        {
           _context.Add(task);
           _context.SaveChanges();
        }

        public void DeleteTable(int taskId)
        {
            _context.Remove(taskId);
            _context.SaveChanges();
        }

        public void EditTable(int taskId)
        {
            _context.Entry(taskId).CurrentValues.SetValues(taskId);
            _context.SaveChanges();
        }



    }
}
