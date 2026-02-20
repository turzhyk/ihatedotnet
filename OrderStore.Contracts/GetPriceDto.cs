using System.Text.Json;
using OrderStore.Core.Models;

namespace OrderStore.Contracts;

public class GetPriceDto
{
    public OrderItemType Type { get; set; }
    public JsonElement Configuration { get; set; }
}