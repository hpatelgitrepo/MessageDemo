using MessageHandler.Contracts;
using MessageLogic;
using MessageLogic.Contracts;
using MessageModel.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MessageLogic.Tests
{
    public class MessageLogicTests
    {
        private Mock<IHandlerFactory> mockHandlerFactory = new Mock<IHandlerFactory>();
        private Mock<IMessageHandler> mockMessageHandler = new Mock<IMessageHandler>();
        private Mock<IAppSettingsLogic> mockAppSettings = new Mock<IAppSettingsLogic>();
        private IMessageLogic sutMessageLogic { get; set; }

        private MessageModel.MessageHandlerResponse response = new MessageModel.MessageHandlerResponse() { Persisted = true, Message = "Saved" };

    [TestInitialize]
        public virtual void Init()
        {
            mockHandlerFactory.Setup(x => x.Resolve<IMessageHandler>(It.IsAny<MessageHandlerType>())).Returns(mockMessageHandler.Object);
            mockMessageHandler.Setup(x => x.SaveMessage(It.IsAny<string>())).ReturnsAsync(response);
            mockAppSettings.Setup(x => x.GetMessageHandlerTypeAppSettingsAsync()).ReturnsAsync("1");

            sutMessageLogic = new MessageLogic(mockAppSettings.Object, mockHandlerFactory.Object);
        }

        [TestClass]
        public class GetMessageAsync : MessageLogicTests
        {
            [TestInitialize]
            public override void Init()
            {
                base.Init();
            }

            [TestMethod]
            public async Task WhenGetMessageIsCalled_MessageIsReturned()
            {
                var result = await sutMessageLogic.GetMessageAsync();
                Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            }
        }

        [TestClass]
        public class SaveMessageAsync : MessageLogicTests
        {
            [TestInitialize]
            public override void Init()
            {
                base.Init();
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public async Task WhenInvalidMessageHandlerIsConfigured_ExceptionIsThrown()
            {
                mockAppSettings.Setup(x => x.GetMessageHandlerTypeAppSettingsAsync()).ReturnsAsync(string.Empty);
                var result = await sutMessageLogic.SaveMessageAsync("Saved to DB");
            }

            [TestMethod]
            public async Task WhenSaveMessageIsCalled_MessageIsSavedIntoDataBase()
            {
                var message = "Saved to DB";
                response.Message = message;
                mockMessageHandler.Setup(x => x.SaveMessage(It.IsAny<string>())).ReturnsAsync(response);
                mockAppSettings.Setup(x => x.GetMessageHandlerTypeAppSettingsAsync()).ReturnsAsync("1");
                var result = await sutMessageLogic.SaveMessageAsync(message);
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Persisted == true);
                Assert.IsTrue(result.Message.Equals(response.Message));
            }

            [TestMethod]
            public async Task WhenSaveMessageIsCalled_MessageIsWrittedToFile()
            {
                var message = "Written To File";
                response.Message = message;
                mockMessageHandler.Setup(x => x.SaveMessage(It.IsAny<string>())).ReturnsAsync(response);
                mockAppSettings.Setup(x => x.GetMessageHandlerTypeAppSettingsAsync()).ReturnsAsync("2");
                var result = await sutMessageLogic.SaveMessageAsync(message);
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Persisted == true);
                Assert.IsTrue(result.Message.Equals(response.Message));
            }

            [TestMethod]
            public async Task WhenSaveMessageIsCalled_MessageIsWrittenToConsole()
            {
                var message = "Written To Console";
                response.Message = message;
                mockMessageHandler.Setup(x => x.SaveMessage(It.IsAny<string>())).ReturnsAsync(response);
                mockAppSettings.Setup(x => x.GetMessageHandlerTypeAppSettingsAsync()).ReturnsAsync("3");
                var result = await sutMessageLogic.SaveMessageAsync(message);
                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Persisted == true);
                Assert.IsTrue(result.Message.Equals(response.Message));
            }
        }
    }
}
