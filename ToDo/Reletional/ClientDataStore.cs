using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ToDo
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    /// such as login credentials, messages, settings and so on
    /// in an SQLite database
    /// </summary>
    public class ClientDataStore : IClientDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext mDbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set local member
            mDbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        public async Task<int> RetrieveCountAsync()
        {
            return mDbContext.ToDos.Count();
        }

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<TodoItem> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exist
            return Task.FromResult(mDbContext.ToDos.FirstOrDefault());
        }

        /// <summary>
        /// Stores the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(TodoItem loginCredentials)
        {

            // Add new one
            mDbContext.ToDos.Add(loginCredentials);

            // Save changes
            await mDbContext.SaveChangesAsync();
        }

        public async Task<ObservableCollection<TodoItem>> RetrieveItemsAsync(TodoItemState state)
        {
            var items = new ObservableCollection<TodoItem>();
            var temp = mDbContext.ToDos.Where(a => a.State == state);
            foreach (var item in temp)
            {
                items.Add(item);
            }
            return items;
        }

        public async Task DeleteItemAsync(TodoItem item)
        {
            mDbContext.ToDos.Remove(item);
            await mDbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(TodoItem item)
        {
            var temp = mDbContext.ToDos.SingleOrDefault(i => i.ID == item.ID);
            if (temp != null)
            {
                mDbContext.Entry(item).Entity.State = item.State;
                mDbContext.Entry(item).Entity.Title = item.Title;
            }
            await mDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
