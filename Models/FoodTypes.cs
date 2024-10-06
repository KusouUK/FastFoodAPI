using System.Text.Json.Serialization;

namespace FastFoodAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FoodTypes
    {
        Burguer = 1,
        Pizza = 2,
        Salad = 3
    }
}