using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;


namespace UnitTests
{

    [TestClass]
    public class UnicodeFileToHtmlTextConverterTests
    {
        [TestMethod]
        public void ConvertToHtml_ShouldEncodeLinesAndAddLineBreaks()
        {
            
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(fh => fh.ReadAllLines(It.IsAny<string>())).Returns(new[]
            {
            "Line 1",
            "Line 2",
            "Line 3"
        });

            var converter = new UnicodeFileToHtmlTextConverter("testfile.txt", fileHandlerMock.Object);

            
            string result = converter.ConvertToHtml();

            
            Assert.AreEqual("Line 1<br />Line 2<br />Line 3<br />", result);
        }
    }
}