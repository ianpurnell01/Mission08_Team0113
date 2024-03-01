namespace Mission08_Team0113.Models
{
    public interface IHabitsRepository
    {
        List<Category> Categories { get; }
        List<Table> Tables { get; }

        public void AddTable(Table task);
        public void DeleteTable(Table task);
        public void EditTable(Table task);
    }
}