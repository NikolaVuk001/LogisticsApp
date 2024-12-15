using System.Net.Http.Json;
using LogisticsApp.Blazor.Configurations;
using LogisticsApp.Blazor.Models;
using Microsoft.Extensions.Options;
using System.Net;
using LogisticsApp.Blazor.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using LogisticsApp.Blazor.Utils;

namespace LogisticsApp.Blazor.Services;

public class ApiService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
{
    // TOOD: EXCEPTIONSSS
    public string BaseApiUrl { get; } = apiSettings.Value.BaseUrl;
    public async Task<IEnumerable<ShipmentDto>> GetShipmentsAsync()
    {
        var response = await httpClient.GetAsync($"{BaseApiUrl}/shipments");

        response.EnsureSuccessStatusCode();

        var shipments = await response.Content.ReadFromJsonAsync<IEnumerable<ShipmentDto>>();

        return shipments ?? [];
    }
    public async Task<ShipmentDto?> GetShipmentById(Guid id)
    {
        var response = await httpClient.GetAsync($"{BaseApiUrl}/shipments/{id}");

        response.EnsureSuccessStatusCode();

        var shipment = await response.Content.ReadFromJsonAsync<ShipmentDto>();

        return shipment ?? null;
        // TODO: Handle Ako Shipment ne postoji
    }
    public async Task<ShipmentDto> CreateShipment(CreateShipmentDto createShipmentDto)
    {
        var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/shipments", createShipmentDto);

        await CheckForBadRequestAsync(response);

        response.EnsureSuccessStatusCode();

        var createdShipment = await response.Content.ReadFromJsonAsync<ShipmentDto>() ??
            throw new Exception(); // Zameni Ovo NEKIM KAO API NIJE DOSUPAN EXCEPTIon

        return createdShipment;

    }

    public async Task<ShipmentDto> UpdateShipment(UpdateShipmentDto updateShipmentDto)
    {
        var response = await httpClient.PutAsJsonAsync($"{BaseApiUrl}/shipments", updateShipmentDto);

        await CheckForBadRequestAsync(response);

        response.EnsureSuccessStatusCode();

        var updatedShipment = await response.Content.ReadFromJsonAsync<ShipmentDto>() ??
            throw new Exception(); // Zameni Ovo

        return updatedShipment;


    }

    public async Task DeleteShipment(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{BaseApiUrl}/shipments/{id}");
        response.EnsureSuccessStatusCode();
    }

    private async Task CheckForBadRequestAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();

                // Util Function That Parses errors JSON object from the resposne and returns Dict of errors
                var errorList = ApiErrorParser.ParseErrors(errorResponse);


                throw new ApiValidationException(errorList.ToDictionary(
                    kvp => kvp.Key,
                    kvp => string.Join(", ", kvp.Value)
                ));
            }
            else
            {
                var errorMessage = $"Trenutno imamo nemožemo dostaviti željene podatka. Pokušajte kasnije.";
                throw new ApiException(errorMessage);
            }
        }
    }

}