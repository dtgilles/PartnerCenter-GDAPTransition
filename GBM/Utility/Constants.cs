using System.Reflection;

namespace PartnerLed.Utility
{
    internal class Constants
    {
        public static readonly string InputFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/GDAPBulkMigration/operations";

        public static readonly string OutputFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/GDAPBulkMigration/downloads";
        
        public static readonly string LogFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Logs";

        public const string BasepathVariable = "BasepathForOperations";

    }
}
