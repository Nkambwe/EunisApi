namespace Eunis.Helpers {
    public interface IServiceLogger {
        string Channel { set; get; }
        string Id { set; get; }
        void LogToFile(string message, string type = "MESSAGE");
    }
}