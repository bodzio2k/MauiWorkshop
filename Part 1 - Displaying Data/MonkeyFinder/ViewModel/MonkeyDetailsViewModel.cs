namespace MonkeyFinder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    private readonly IMap map;

    [ObservableProperty]
    public Monkey monkey;

    public MonkeyDetailsViewModel(IMap map)
    {
        this.map = map;
    }


    [RelayCommand]
    public async Task OpenMapAsync()
    {
        try
        {
            MapLaunchOptions launchOptions = new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            };

            await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, launchOptions);
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
