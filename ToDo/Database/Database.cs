using System.Data.Entity;
using System.IO;

namespace ToDo
{
    /// <summary>
    /// Helper class for retrieving/updating/inserting ... from/to database
    /// We gonna use SQLite for this application
    /// </summary>
    public class Database : DbContext
    {

        /// <summary>
        /// Data 
        /// </summary>
        public DbSet<TodoItem> Todos { set; get; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>().HasKey(a => a.ID);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Database() : base("Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "todos.db") + "; Database=TodoApp; Persist Security Info = True;Integrated Security=True;")
        {
        }
    }
}
