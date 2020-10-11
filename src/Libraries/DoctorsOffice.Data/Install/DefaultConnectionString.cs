namespace DoctorsOffice.Data.Install
{
    public class DefaultConnectionString
    {
        public DefaultConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }
    }
}
