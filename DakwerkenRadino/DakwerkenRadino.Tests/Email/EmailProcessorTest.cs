using DakwerkenRadino.Business.AppSetting;
using DakwerkenRadino.Business.Email;
using DakwerkenRadino.Core.Keys;
using Moq;
using NUnit.Framework;

namespace DakwerkenRadino.Tests.Email
{
    [TestFixture]
    public class EmailProcessorTest
    {
        private IEmailProcessor emailProcessor;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IConfigurationReader>();
            mock.Setup(m => m.GetValue(AppSettings.Username)).Returns("info@dakwerken-radino.be");
            mock.Setup(m => m.GetValue(AppSettings.Password)).Returns("Kenzo.456");
            mock.Setup(m => m.GetValue(AppSettings.Host)).Returns("smtp.mijnhostingpartner.nl");

            emailProcessor = new EmailProcessor(mock.Object);
        }

        [Test]
        public async void Send_CorrectCredentials_Test()
        {
            bool result = await emailProcessor.Send(TestData.ContactFormModel);
            Assert.IsTrue(result);
        }
    }
}
