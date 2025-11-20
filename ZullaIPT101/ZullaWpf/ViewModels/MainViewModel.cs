using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ZullaWpf.Commands;
using ZullaWpfDomain.Commands;
using ZullaWpfDomain.Models;
using ZullaWpfDomain.Queries;

namespace ZullaWpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ICommandHandler<CreateDanceClassCommand> _createHandler;
    private readonly ICommandHandler<UpdateDanceClassCommand> _updateHandler;
    private readonly ICommandHandler<DeleteDanceClassCommand> _deleteHandler;
    private readonly IQueryHandler<GetAllDanceClassesQuery, IEnumerable<DanceClass>> _queryHandler;

    private string _title = string.Empty;
    private string _danceStyle = string.Empty;
    private string _instructor = string.Empty;
    private string _schedule = string.Empty;
    private DanceClassViewModel? _selectedDanceClass;
    private bool _isEditMode;

    public MainViewModel(
        ICommandHandler<CreateDanceClassCommand> createHandler,
        ICommandHandler<UpdateDanceClassCommand> updateHandler,
        ICommandHandler<DeleteDanceClassCommand> deleteHandler,
        IQueryHandler<GetAllDanceClassesQuery, IEnumerable<DanceClass>> queryHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _queryHandler = queryHandler;

        DanceClasses = new ObservableCollection<DanceClassViewModel>();

        SaveCommand = new AsyncRelayCommand(async _ => await SaveAsync(), _ => CanSave());
        DeleteCommand = new AsyncRelayCommand(async _ => await DeleteAsync(), _ => CanDelete());
        ClearCommand = new RelayCommand(_ => Clear());
        LoadCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());
    }

    public ObservableCollection<DanceClassViewModel> DanceClasses { get; }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string DanceStyle
    {
        get => _danceStyle;
        set => SetProperty(ref _danceStyle, value);
    }

    public string Instructor
    {
        get => _instructor;
        set => SetProperty(ref _instructor, value);
    }

    public string Schedule
    {
        get => _schedule;
        set => SetProperty(ref _schedule, value);
    }

    public DanceClassViewModel? SelectedDanceClass
    {
        get => _selectedDanceClass;
        set
        {
            if (SetProperty(ref _selectedDanceClass, value))
            {
                LoadSelectedDanceClass();
            }
        }
    }

    public bool IsEditMode
    {
        get => _isEditMode;
        set => SetProperty(ref _isEditMode, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand LoadCommand { get; }

    private bool CanSave()
    {
        return !string.IsNullOrWhiteSpace(Title) &&
               !string.IsNullOrWhiteSpace(DanceStyle) &&
               !string.IsNullOrWhiteSpace(Instructor) &&
               !string.IsNullOrWhiteSpace(Schedule);
    }

    private bool CanDelete()
    {
        return IsEditMode && SelectedDanceClass != null;
    }

    private async Task SaveAsync()
    {
        try
        {
            if (IsEditMode && SelectedDanceClass != null)
            {
                var updateCommand = new UpdateDanceClassCommand
                {
                    Id = SelectedDanceClass.Id,
                    Title = Title,
                    DanceStyle = DanceStyle,
                    Instructor = Instructor,
                    Schedule = Schedule
                };

                await _updateHandler.ExecuteAsync(updateCommand);
                MessageBox.Show("Dance class updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var createCommand = new CreateDanceClassCommand
                {
                    Title = Title,
                    DanceStyle = DanceStyle,
                    Instructor = Instructor,
                    Schedule = Schedule
                };

                await _createHandler.ExecuteAsync(createCommand);
                MessageBox.Show("Dance class saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            await LoadDataAsync();
            Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving dance class: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task DeleteAsync()
    {
        if (SelectedDanceClass == null) return;

        var result = MessageBox.Show(
            $"Are you sure you want to delete '{SelectedDanceClass.Title}'?",
            "Confirm Delete",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            try
            {
                var deleteCommand = new DeleteDanceClassCommand
                {
                    Id = SelectedDanceClass.Id
                };

                await _deleteHandler.ExecuteAsync(deleteCommand);
                MessageBox.Show("Dance class deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                await LoadDataAsync();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting dance class: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void Clear()
    {
        Title = string.Empty;
        DanceStyle = string.Empty;
        Instructor = string.Empty;
        Schedule = string.Empty;
        SelectedDanceClass = null;
        IsEditMode = false;
    }

    private void LoadSelectedDanceClass()
    {
        if (SelectedDanceClass != null)
        {
            Title = SelectedDanceClass.Title;
            DanceStyle = SelectedDanceClass.DanceStyle;
            Instructor = SelectedDanceClass.Instructor;
            Schedule = SelectedDanceClass.Schedule;
            IsEditMode = true;
        }
    }

    public async Task LoadDataAsync()
    {
        try
        {
            var query = new GetAllDanceClassesQuery();
            var danceClasses = await _queryHandler.HandleAsync(query);

            DanceClasses.Clear();
            foreach (var danceClass in danceClasses)
            {
                DanceClasses.Add(new DanceClassViewModel(danceClass));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
