using System;
using System.Net;
using System.Reflection;

class Program
{
    static string versionUrl = "https://yourwebsite.com/version.txt";
    static string updateUrl = "https://yourwebsite.com/updatedprogram.exe";

    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Control Panel";
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("Welcome to the Cybersecurity Control Panel");
        Console.WriteLine("------------------------------------------\n");

        // Check for updates
        CheckForUpdates();

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Scan network for active devices");
        Console.WriteLine("2. Generate Strong Password");
        Console.WriteLine("3. Check for Open Ports\n");

        Console.Write("Enter your choice (1-3): ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    // Functionality for scanning network
                    break;
                case 2:
                    // Functionality for generating strong password
                    break;
                case 3:
                    // Functionality for checking open ports
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Exiting.");
        }

        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void CheckForUpdates()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                string remoteVersion = client.DownloadString(versionUrl);
                Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
                Version latestVersion = new Version(remoteVersion);

                if (latestVersion > currentVersion)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("A new version is available. Would you like to update? (Y/N)");

                    if (Console.ReadLine().Trim().ToUpper() == "Y")
                    {
                        // Update the program
                        Console.WriteLine("Updating program...");
                        client.DownloadFile(updateUrl, "updatedprogram.exe");
                        Console.WriteLine("Program updated successfully. Please restart.");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("You have the latest version.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking for updates: {ex.Message}");
        }
    }
}
