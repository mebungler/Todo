using Dna;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ToDo
{
    public class MainWindowViewModel : BaseViewModel
    {

        public static IClientDataStore Database => Framework.Service<IClientDataStore>();
        public static MainWindowViewModel Instance;

        #region Private members

        private Window mWindow;

        #endregion

        #region Public properties

        /// <summary>
        /// Selected tab 
        /// </summary>
        public int SelectedTab { set; get; }

        /// <summary>
        /// GridLength of TitleBar
        /// </summary>
        public GridLength TitleHeightGridLength { set; get; } = new GridLength(42);

        /// <summary>
        /// Title height of this app
        /// </summary>
        public int TitleHeight { set; get; } = 42;


        /// <summary>
        /// Currently selected TodoItems
        /// </summary>
        public ObservableCollection<TodoItem> CurrentItems { set; get; }

        ///// <summary>
        ///// Database for the application
        ///// NOTE: We need to get that with dependency injection?
        ///// </summary>
        //public Database Database { set; get; }

        #endregion

        #region Commands

        /// <summary>
        /// Command for minimizing the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command for Maximizing window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Commnad for exiting from the application
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand ActiveToDosCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand FinishedToDosCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand DeletedToDosCommand { get; set; }

        public ICommand AddCommand { set; get; }

        #endregion

        #region Default Constructor

        public MainWindowViewModel(Window window)
        {
            mWindow = window;
            Instance = this;
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());

            AddCommand = new RelayCommand(async () =>
            {
                var temp = new TodoItem
                {
                    State = TodoItemState.New,
                    IsEditing = true,
                    ID = await Database.RetrieveCountAsync()+1,
                };
                CurrentItems.Add(temp);
            });

            ActiveToDosCommand = new RelayCommand(() =>
            {
                //TODO:Get them from the database
                SelectedTab = 0;
                LoadTodos(TodoItemState.Active);
            });
            FinishedToDosCommand = new RelayCommand(() =>
            {
                //TODO:Get them from the database
                SelectedTab = 1;
                LoadTodos(TodoItemState.Finished);

            });
            DeletedToDosCommand = new RelayCommand(() =>
            {
                //TODO:Get them from the database
                SelectedTab = 2;
                LoadTodos(TodoItemState.Deleted);
            });

            Database.EnsureDataStoreAsync();
            LoadTodos(TodoItemState.Active);
            //Database.DeleteItemAsync(new TodoItem { ID = 1 });
        }
        public void Reload()
        {
            switch (SelectedTab)
            {
                case 0:
                    LoadTodos(TodoItemState.Active);
                    break;
                case 1:
                    LoadTodos(TodoItemState.Finished);
                    break;
                case 2:
                    LoadTodos(TodoItemState.Deleted);
                    break;
            }
        }
        private async void LoadTodos(TodoItemState state)
        {
            CurrentItems = await Database.RetrieveItemsAsync(state);
        }

        #endregion

    }
}
