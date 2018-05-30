using System.Threading;

namespace DotNetPOC.Utils
{
    public class Utils
    {
        public static void SetCurrentConnectionStringKey(string connectionString)
        {
            Thread.SetData(Thread.GetNamedDataSlot("ConnectionString"), connectionString);
        }

        public static string GetCurrentConnectionStringKey()
        {
            return (string)Thread.GetData(Thread.GetNamedDataSlot("ConnectionString"));
        }
    }
}