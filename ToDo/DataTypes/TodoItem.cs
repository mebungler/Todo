using System.Windows.Input;

namespace ToDo
{
    public class TodoItem : BaseViewModel
    {
        /// <summary>
        /// Id of the todo
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// Title of the TodoItem
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// Flag that indicates whether the item is being edited or not
        /// </summary>
        public bool IsEditing { set; get; } = false;

        /// <summary>
        /// Current State of <see cref="TodoItem"/>
        /// </summary>
        public TodoItemState State { set; get; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand FinishCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Turining to Active ToDos
        /// </summary>
        public ICommand CancelCommand { get; set; }
        private string TempTitle;
        public TodoItem()
        {
            EditCommand = new RelayCommand(() =>
            {
                this.IsEditing = true;
                TempTitle = Title;
            });
            CancelCommand = new RelayCommand(() =>
            {
                if (this.State == TodoItemState.New)
                {
                    MainWindowViewModel.Instance.CurrentItems.Remove(this);
                }
                else
                {
                    this.IsEditing = false;
                    Title = TempTitle;
                }
            });

            DeleteCommand = new RelayCommand(() =>
            {
                IsEditing = false;
                if (this.State == TodoItemState.New)
                {
                    MainWindowViewModel.Instance.CurrentItems.Remove(this);
                }
                else
                {
                    this.State = TodoItemState.Deleted;
                    MainWindowViewModel.Database.UpdateItemAsync(this);
                    MainWindowViewModel.Instance.Reload();
                }
            });

            FinishCommand = new RelayCommand(() =>
            {
                this.State = TodoItemState.Finished;
                MainWindowViewModel.Database.UpdateItemAsync(this);
                MainWindowViewModel.Instance.Reload();
            });

            SaveCommand = new RelayCommand(async () =>
            {
                IsEditing = false;
                if (this.State == TodoItemState.New)
                {
                    this.State = TodoItemState.Active;
                    await MainWindowViewModel.Database.SaveLoginCredentialsAsync(this);
                    MainWindowViewModel.Instance.Reload();
                }
                else
                {
                    MainWindowViewModel.Database.UpdateItemAsync(this);
                    MainWindowViewModel.Instance.Reload();
                }
            });
        }

    }

    public enum TodoItemState
    {
        /// <summary>
        /// Demonstrated in the Active panel
        /// </summary>
        Active,

        /// <summary>
        /// Demonstrated in the Done panel
        /// </summary>
        Finished,

        /// <summary>
        /// Demonstrated in the Deleted panel
        /// </summary>
        Deleted,

        /// <summary>
        /// Newly added todo
        /// </summary>
        New,
    }

}
