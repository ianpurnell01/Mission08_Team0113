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

        public void DeleteTable(Table task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }

        //public void EditTable(Table task)
        //{
        //    _context.Entry(task).CurrentValues.SetValues(task);
        //    _context.SaveChanges();
        //}

        public void EditTable(Table task)
        {
            var existingTask = _context.Tables.FirstOrDefault(t => t.TaskId == task.TaskId);
            if (existingTask != null)
            {
                existingTask.Task = task.Task; 
                _context.SaveChanges();
            }
        }





    }
}
