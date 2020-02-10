using ClassLibrary.BL.Reporting;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class ReportGeneratorsTests
    {
        [Test]
        public void GenerateReport_NullArgument_ThrowsNullArgumentException()
        {
            var txtReportGenerator = new TxtReportGenerator();
            var xmlReportGenerator = new XmlReportGenerator();

            Assert.Multiple(() =>
            {
                Assert.That(() => txtReportGenerator.GenerateReport(null),
                    Throws.ArgumentNullException);
                Assert.That(() => xmlReportGenerator.GenerateReport(null),
                    Throws.ArgumentNullException);
            });
        }
    }
}
