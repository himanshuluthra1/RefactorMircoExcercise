using System.IO;
using System.Text;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IFileHandler
    {
        string[] ReadAllLines(string path);
    }

    public class FileHandler : IFileHandler
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }

    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string _fullFilenameWithPath;
        private readonly IFileHandler _fileHandler;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath, IFileHandler fileHandler)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _fileHandler = fileHandler;
        }

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _fileHandler = new FileHandler();
        }

        public string ConvertToHtml()
        {
            var lines = _fileHandler.ReadAllLines(_fullFilenameWithPath);
            var html = new StringBuilder();

            foreach (var line in lines)
            {
                html.Append(HttpUtility.HtmlEncode(line));
                html.Append("<br />");
            }

            return html.ToString();
        }
    }



}
