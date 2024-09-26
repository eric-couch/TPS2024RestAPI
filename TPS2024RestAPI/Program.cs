using TPS2024RestAPI;

var omdbClient = new OmdbApiClient();
Console.Write("Enter Movie Name: ");
string movieTitle = Console.ReadLine()!;


OMDBMovie movieData = await omdbClient.GetMovieDataAsync(movieTitle);

if (movieData != null)
{
    // write a series of statements that will console write the omdbmovie data
    Console.WriteLine($"Movie title: {movieData.Title}");
    Console.WriteLine($"Movie Year Released: {movieData.Released}");
    Console.WriteLine($"Movie Director: {movieData.Director}");
    Console.WriteLine($"Movie Plot: {movieData.Plot}");
    foreach (Rating rating in movieData.Ratings)
    {
        Console.WriteLine($"\tRating Source: {rating.Source}\tValue: {rating.Value}");
    }
    Console.Write("Actors:\t|");
    foreach (var actor in movieData.Actors.Split(", "))
    {
        Console.Write($" {actor} |");
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine("Failed to fetch movie data.");
}
