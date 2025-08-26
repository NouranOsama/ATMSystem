namespace ATMSystem.Data
{
    public sealed class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance =
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());

        private static IConfiguration? _configuration;

        public string ConnectionString { get; private set; }

        private DatabaseConnection()
        {
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static DatabaseConnection Instance => _instance.Value;
    }
}
