using Azure;
using System;
using Azure.AI.TextAnalytics;

namespace Sentiment_Analysis
{
    class Program
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("INSERT_KEY_HERE");
        private static readonly Uri endpoint = new Uri("INSERT_ENDPOINT_HERE");

        // Example method for performing sentiment analysis on text 
        static void AnalyzeSentiment(TextAnalyticsClient client)
        {
            // Get sentiment
            List<string> input = new List<string>
            {
                "I had a wonderful trip to Seattle last week.",
                "I'm not sure how I feel about this product.",
                "The restaurant had really good food.",
                "The hotel was not very clean."
            };

            foreach (string text in input)
            {
                var result = client.AnalyzeSentiment(text);
                Console.WriteLine($"Sentiment: {result.Value.Sentiment}");
                Console.WriteLine($"\t\tPositive Score: {result.Value.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\t\tNegative Score: {result.Value.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\t\tNeutral Score: {result.Value.ConfidenceScores.Neutral:0.00}");
            }
            
        }

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            AnalyzeSentiment(client);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

    }
}