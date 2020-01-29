namespace UbsTestProject
{
    /// <summary>
    /// The expected results and some other data, that has been passed as a config file, making the tests configurable
    /// </summary>
    public class Configuration
    {
        public string Language { get; set; }
        public string Browser { get; set; }
        public string Title { get; set; }
        public string MortgagePositiveResult { get; set; }

        public string MortgageNegativeResult { get; set; }
    }
}
