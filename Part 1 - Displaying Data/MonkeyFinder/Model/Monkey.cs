using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MonkeyFinder.Model;

public class Monkey
{
    [Key]
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public int Population { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    public override string ToString() => Name;
}
