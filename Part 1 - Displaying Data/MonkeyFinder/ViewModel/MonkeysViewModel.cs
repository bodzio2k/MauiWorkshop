using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    readonly MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey finder".ToUpper();
        this.monkeyService = monkeyService;
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
}
