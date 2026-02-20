using System.Text.Json;
using OrderStore.Application.PricingConfigurations;
using OrderStore.Contracts;
using OrderStore.Core.Models;

namespace OrderStore.Application.Services;

public interface IPriceCalcService
{
     Task<PriceResultDto> CalculatePrice(GetPriceDto request);

}