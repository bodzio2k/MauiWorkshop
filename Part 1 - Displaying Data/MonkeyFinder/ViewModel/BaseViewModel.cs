namespace MonkeyFinder.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy = false;
    
    [ObservableProperty]
    bool isRefreshing = false;
    
    [ObservableProperty]
    string title = string.Empty;

    public bool IsNotBusy => !IsBusy;
}
