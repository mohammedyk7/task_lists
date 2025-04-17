using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Top N Frequent Numbers");
            Console.WriteLine("2. Palindrome Filter");
            Console.WriteLine("3. Shift List Elements");
            Console.WriteLine("4. Unique Words Extractor");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TopNFrequentNumbers();
                    break;
                case "2":
                    FilterPalindromes();
                    break;
                case "3":
                    ShiftListElements();
                    break;
                case "4":
                    UniqueWordsExtractor();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void TopNFrequentNumbers()
    {
        // Input list of numbers
        List<int> numbers = new List<int> { 1, 2, 2, 3, 3, 3, 4, 5, 5 };

        // N = how many top frequent numbers you want
        int N = 3;

        List<int> topNFrequent = new List<int>();

        // Step 1: Process numbers to find top N frequent
        for (int i = 0; i < N; i++)
        {
            //i defined two variables:
            int maxFreq = 0;  // To store the maximum frequency + (since we haven't found any frequencies yet)
            int maxNum = 0;   // To store the number with the highest frequency + (since we haven't found any numbers yet)

            foreach (int num in numbers) 
            {
                // Count occurrences of the current number
                int count = numbers.Count(x => x== num); //counts how many times the number num appears in the list.

             
                // If the frequency of the current number is higher than the current maximum frequency
                if (count > maxFreq)
                {
                    // Update the maximum frequency and the number with the highest frequency
                    maxFreq = count;
                    maxNum = num;
                }
            }

            // Add the most frequent number to the result list
            topNFrequent.Add(maxNum);

            // Remove the most frequent number from the list
            numbers.RemoveAll(x => x == maxNum);  // Removes all occurrences of maxNum
        }

        // Step 2: Output the result
        Console.WriteLine("Top " + N + " Frequent Numbers:");
        Console.WriteLine(string.Join(", ", topNFrequent));
    }

    // Function to check if a string is a palindrome  
    static bool IsPalindrome(string str) //because we will return and we added parameter  
    {
        int left = 0;
        int right = str.Length - 1; // index starts with 0 for example level left 0 then right 4 because length is 5 so 4-1=3  

        while (left < right)//We want to compare characters in pairs: one from the start (left), one from the end (right)  
        {
            if (str[left] != str[right])
                return false; //because it will already exit.  
                              //no need for "else"   
            left++;
            right--;
        }

        return true;
    }

    static void FilterPalindromes()
    {
        // List of strings  
        List<string> strings = new List<string> { "ana", "madam", "hello", "world", "level", "aristotle" };

        // Filter palindromes using a simple loop  
        List<string> palindromes = new List<string>();

        foreach (string wrd in strings)
        {
            if (IsPalindrome(wrd))
                palindromes.Add(wrd);// added to the palindrome lists 
        }

        // Output the palindromes  
        Console.WriteLine("Palindromes:");
        palindromes.ForEach(Console.WriteLine);
    }

    static void ShiftListElements()
    {
        // Input list of integers
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Ask the user for the number of positions to shift
        Console.Write("Enter the number of positions to shift: ");
        if (!int.TryParse(Console.ReadLine(), out int shift)) // Validate user input
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return; // Exit the method if input is invalid
        }

        // Normalize the shift value to handle cases where shift > list size or negative shifts
        shift = shift % numbers.Count; // Ensure the shift value is within the bounds of the list size
        if (shift < 0) // Handle negative shifts by converting them to equivalent positive shifts
        {
            shift += numbers.Count;
        }

        // Perform the shift using list slicing
        // Take the last 'shift' elements and move them to the front
        List<int> shiftedList = numbers.Skip(numbers.Count - shift).ToList();
        // Add the remaining elements from the start of the list
        shiftedList.AddRange(numbers.Take(numbers.Count - shift));

        // Output the shifted list
        Console.WriteLine("Shifted List:");
        Console.WriteLine(string.Join(", ", shiftedList)); // Display the shifted list as a comma-separated string
    }

    static void UniqueWordsExtractor()
    {
        // Prompt the user to enter a block of text
        Console.WriteLine("Enter a block of text:");
        string? inputText = Console.ReadLine();

        // Check if the input text is null, empty, or consists only of whitespace
        if (string.IsNullOrWhiteSpace(inputText))
        {
            Console.WriteLine("No text provided. Please try again.");
            return; // Exit the method if no valid input is provided
        }

        // Split the input text into words using common delimiters and remove empty entries
        string[] words = inputText.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Use a HashSet to store unique words, ignoring case differences
        HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Iterate through the words and add each one to the HashSet
        foreach (string word in words)
        {
            uniqueWords.Add(word); // HashSet automatically handles duplicates
        }

        // Output the unique words to the console
        Console.WriteLine("Unique Words:");
        Console.WriteLine(string.Join(", ", uniqueWords)); // Join and display the unique words as a comma-separated string
    }
}



 