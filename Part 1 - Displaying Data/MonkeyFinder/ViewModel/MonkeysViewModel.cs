using Microsoft.Maui.Devices.Sensors;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    readonly MonkeyService monkeyService;
    readonly IConnectivity connectivity;
    readonly IGeolocation geolocation;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey finder".ToUpper();
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }

    [RelayCommand]
    public async Task GotoDetailsAsync(Monkey monkey)
    {
        if (monkey == null)
            return;

        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"Monkey", monkey},
        };

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, parameters);
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new Exception("No Internet access.");
            }

            var monkeys = await monkeyService.GetMonkeysAsync();

            if (monkeys.Count != 0)
            {
                Monkeys.Clear();
            }

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GetClosestMonkeyAsync()
    {
        if (IsBusy || Monkeys.Count() == 0)
            return;

        try
        {
            var req = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(30));

            var location = await geolocation.GetLocationAsync(req);

            if (location is null)
                return;

            var closest = Monkeys.OrderBy(m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers));

            if (closest is null)
                return;

            await Shell.Current.DisplayAlert("Closest Monkey", closest.FirstOrDefault().Name, "OK");
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            ;
        }
    }
}
