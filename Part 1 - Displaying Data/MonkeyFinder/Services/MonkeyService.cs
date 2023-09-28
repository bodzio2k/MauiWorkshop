using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    readonly HttpClient httpClient = new();
    List<Monkey> monkeyList;
    public MonkeyService()
    {
        ;
    }
    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var url = "https://www.montemagno.com/monkeys.json";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;
    }

}
