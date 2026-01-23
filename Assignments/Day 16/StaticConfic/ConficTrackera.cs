namespace StaticConfic
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount = 0;
            Console.WriteLine("Static Constructor Executed\n");
        }

        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static void GetConfigurationSummary()
        {
            AccessCount++;
            Console.WriteLine($"Application Name      - {ApplicationName,-10}");
            Console.WriteLine($"Environment           - {Environment,-10}");
            Console.WriteLine($"Access Count          - {AccessCount,-10}");
            Console.WriteLine($"Initialization Status - {IsInitialized,-10}");
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }
    internal class ConficTrackera
    {
        static void Main(string[] args)
        {
            ApplicationConfig.Initialize("FaceBook", "Dev");
            ApplicationConfig.GetConfigurationSummary();
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine();
            ApplicationConfig.GetConfigurationSummary();
        }
    }
}
