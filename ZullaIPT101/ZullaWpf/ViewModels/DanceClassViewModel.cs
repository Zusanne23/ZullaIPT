using ZullaWpfDomain.Models;

namespace ZullaWpf.ViewModels;

public class DanceClassViewModel : ViewModelBase
{
    private readonly DanceClass _model;

    public DanceClassViewModel(DanceClass model)
    {
        _model = model;
    }

    public int Id => _model.Id;

    public string Title
    {
        get => _model.Title;
        set
        {
            if (_model.Title != value)
            {
                _model.Title = value;
                OnPropertyChanged();
            }
        }
    }

    public string DanceStyle
    {
        get => _model.DanceStyle;
        set
        {
            if (_model.DanceStyle != value)
            {
                _model.DanceStyle = value;
                OnPropertyChanged();
            }
        }
    }

    public string Instructor
    {
        get => _model.Instructor;
        set
        {
            if (_model.Instructor != value)
            {
                _model.Instructor = value;
                OnPropertyChanged();
            }
        }
    }

    public string Schedule
    {
        get => _model.Schedule;
        set
        {
            if (_model.Schedule != value)
            {
                _model.Schedule = value;
                OnPropertyChanged();
            }
        }
    }

    public DanceClass GetModel() => _model;
}
