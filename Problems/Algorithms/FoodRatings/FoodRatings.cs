namespace Problems.Algorithms.FoodRatings;

public static class FoodRatings
{
    public static void Run()
    {
        // Copyright © 2018 CourtAlert.com Inc.
        // Load data.
        var csvData = LoadCsvResource();
        var foodRatings = LoadFoodRatingDataFromCsv(csvData);


        // Calculate the average rating for each city
        var (City, AverageRating) =
            foodRatings.GetCitiesByHighestAverageFoodRating()
                .FirstOrDefault();

        // Display the name of the city with the highest average. 
        Console.WriteLine($"City: {City ?? "N/A"}, Highest Average Rating: { string.Format("{0:N2}", AverageRating) }");
    }

    // Put the data in the current working directory.
    private static string[] LoadCsvResource() => Properties.Resources.restaurant_ratings.Split('\n');

    private static IEnumerable<FoodRating> LoadFoodRatingDataFromCsv(string[] csvData)
    {
        return csvData.Skip(1).Select(x =>
        {
            var columns = x.Split(',');

            return new FoodRating
            {
                Id = ParseId(columns[0]),
                City = columns[1],
                Cuisine = columns[2],
                Rating = ParseId(columns[3])
            };
        });
    }

    private static int ParseId(string? id) =>
        string.IsNullOrEmpty(id) ? 0 : int.Parse(id);
}

//[Index(nameof(City), nameof(Rating))]
public class FoodRating
{
    //[Key]
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Cuisine { get; set; }

    public float Rating { get; set; }
}

public static class FoodRatingsExtensions
{
    // Calculates the average rating for each city and orders by the rating in descending order.
    public static IEnumerable<(string City, float AverageRating)> GetCitiesByHighestAverageFoodRating(this IEnumerable<FoodRating> foodRatings) =>
        foodRatings
        .GroupBy(r => r.City)
        .Select(g =>
        (
            City: g.Key ?? string.Empty,
            AverageRating: g.Average(r => r.Rating)
        ))
        .Where(g => g.City != string.Empty)
        .OrderByDescending(o => o.AverageRating);
}
