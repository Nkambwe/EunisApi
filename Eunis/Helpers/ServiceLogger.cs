namespace Eunis.Helpers {
    public class ServiceLogger : IServiceLogger {

        private readonly string _fileName;
        private readonly bool _isFolder = false;
        public string Channel { get; set; }
        public string Id { get; set; }

        public ServiceLogger() {
            _fileName = string.IsNullOrEmpty(_fileName) ? "EuniService" : _fileName;
        }

        public ServiceLogger(string name, bool isFolder = false) {
            _fileName = name;
            _isFolder = isFolder;
        }

        public void LogToFile(string message, string type = "MSG") {
            string filepath;
            EventWaitHandle waitHandle = null;
            try {
                waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "API_LOGGER_EUNIS_12784990");
                waitHandle.WaitOne();

                // ... processing time
                var date = DateTime.Now;
                var shortDate2 = date.ToString("yyyy-MM-dd");
                char[] delim = { ' ' };

                var tZone = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
                var words = tZone.StandardName.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                string abbrev = string.Empty;
                foreach (string chaStr in words) {
                    abbrev += chaStr[0];
                }
                string filename = $"Activity_Log_{(_fileName != null ? (_isFolder ? "" : _fileName) : " ")}_{shortDate2}.log";
                filepath = @$"C:\Logs\Eunis\{(_isFolder ? _fileName : "Activity_Eunis_Log")}";

                //..create directory if not found
                if (!Directory.Exists(filepath)) {
                    Directory.CreateDirectory(filepath);
                }

                //..file path
                filepath = @$"{filepath}\{filename}";
                if (!File.Exists(filepath)) {
                    File.Create(filepath).Close();
                }

                var timeIn = $"{date:yyyy.MM.dd HH:mm:ss} {abbrev}";
                string messageToLog = $"[{timeIn}]: [{type}]\t\t {(Channel != null ? $"CHANNEL: {Channel}\t" : "")} {(Id != null ? Id + "\t" : "")} {message}";
                using StreamWriter file = new(filepath, true);
                file.WriteLine(messageToLog);

            } catch (Exception ex) {
                try {

                    filepath = @$"C:\Logs\Eunis\{(_isFolder ? _fileName : "Activity_Eunis_Log")}";
                    if (!Directory.Exists(filepath)) {
                        Directory.CreateDirectory(filepath);
                    }

                    using StreamWriter file = new(filepath, true);
                    file.WriteLine($"LOG ERROR :: An error occurred while creating log file.");
                    file.WriteLine($"{ex.Message}");
                } catch (Exception ex1) {
                    try {
                        filepath = @$"C:\Logs\Eunis\{(_isFolder ? _fileName : "Activity_Eunis_Log")}";
                        if (!Directory.Exists(filepath)) {
                            Directory.CreateDirectory(filepath);
                        }
                        using StreamWriter file = new(filepath, true);
                        file.WriteLine($"LOG ERROR :: An error occurred while creating log file.");
                        file.WriteLine($"{ex1.Message}");
                    } catch (Exception) {
                        return;
                    }

                }
            } finally {
                waitHandle?.Set();
            }
        }
    }
}

