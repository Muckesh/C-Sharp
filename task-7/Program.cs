using System;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program {
    static async Task Main() {
        Console.WriteLine("Fetching data from sources...\n");

        var tasks = new List<Task> {
            FetchDataAsync("Source A", 2000),
            FetchDataAsync("Source B", 3000),
            FetchDataAsync("Source C", 1500)
        };

        await Task.WhenAll(tasks);

        Console.WriteLine("\n--- All tasks finished ---");
    }

    static async Task FetchDataAsync(string source, int delay) {
        try {
            Console.WriteLine($"Fetching from {source}...");
            await Task.Delay(delay);

            if (source == "Source B") {
                throw new Exception("Failed to fetch from Source B");
            }

            Console.WriteLine($"{source}: Data received after {delay} ms");
        } catch (Exception ex) {
            Console.WriteLine($"{source}: Error - {ex.Message}");
        }
    }
}

