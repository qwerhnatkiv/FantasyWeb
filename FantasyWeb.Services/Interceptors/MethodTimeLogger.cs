using System.Reflection;

namespace FantasyWeb.Services.Interceptors
{
    public static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, long milliseconds, string message)
        {
            const string fileName = "timer.log";
            using (StreamWriter streamWriter = File.AppendText(fileName))
            {
                streamWriter.WriteLine(methodBase.Name + " " + milliseconds + "ms");
            }
        }
    }
}
