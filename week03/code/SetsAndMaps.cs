using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            var reversed = $"{word[1]}{word[0]}";

            if (wordSet.Contains(reversed) && string.Compare(word, reversed) < 0)
            {
                pairs.Add($"{word} & {reversed}");
            }
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (var ch in word1)
        {
            if (counts.ContainsKey(ch))
                counts[ch]++;
            else
                counts[ch] = 1;
        }

        foreach (var ch in word2)
        {
            if (!counts.ContainsKey(ch))
                return false;

            counts[ch]--;

            if (counts[ch] == 0)
                counts.Remove(ch);
        }

        return counts.Count == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.features == null)
            return [];

        var results = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            if (feature?.properties?.place != null && feature.properties.mag.HasValue)
            {
                results.Add($"{feature.properties.place} - Mag {feature.properties.mag.Value}");
            }
        }

        return results.ToArray();
    }
}