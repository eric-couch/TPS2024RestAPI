using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TPS2024RestAPI;

public class OmdbApiClient
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiKey = "86c39163";
    private const string baseUrl = "http://www.omdbapi.com/";

    public async Task<OMDBMovie?> GetMovieDataAsync(string title)
    {
        try
        {
            // Build the request URL
            var requestUrl = $"{baseUrl}?t={Uri.EscapeDataString(title)}&apikey={apiKey}";

            // Send single get and deserialize json into object
            //var movie = await client.GetFromJsonAsync<OMDBMovie>(requestUrl);

            // Send the GET request
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize the string into an OMDBMovie object
            OMDBMovie movie = JsonSerializer.Deserialize<OMDBMovie>(responseBody);
            return movie;
        }
        catch (HttpRequestException e)
        {
            // Handle any errors that occurred during the request
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }
}
