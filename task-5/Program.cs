using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class Program {
    static void Main() {
        string inputPath = "sample.txt";
        string outputPath = "output.txt";

        try {
            if (!File.Exists(inputPath)) {
                Console.WriteLine("File not found.");
                return;
            }

            string content = File.ReadAllText(inputPath);

            int lineCount = File.ReadAllLines(inputPath).Length;

            // Word count using regex
            int wordCount = Regex.Matches(content, @"\b\w+\b").Count;

            // Character count (excluding whitespace)
            int charCount = content.Count(c => !char.IsWhiteSpace(c));

            string result = $"Lines : {lineCount}\nWords : {wordCount}\nCharacters (no whitespace) : {charCount}";

            File.WriteAllText(outputPath, result);
            Console.WriteLine("Processing Complete. Results written to 'output.txt'");
        }
        catch (FileNotFoundException ex) {
            Console.WriteLine("File not found : " + ex.Message);
        }
        catch (IOException ex) {
            Console.WriteLine("IO Exception: " + ex.Message);
        }
        catch (Exception ex) {
            Console.WriteLine($"Unexpected error: " + ex.Message);
        }
    }
}
