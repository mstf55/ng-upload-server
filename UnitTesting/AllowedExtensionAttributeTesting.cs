using FileServer.Attributes;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using Xunit;

namespace UnitTesting
{
    public class AllowedExtensionAttributeTesting
    {
        private Mock<IFormFile> _fileMock;
        public AllowedExtensionAttributeTesting()
        {
            _fileMock = new Mock<IFormFile>();
            var fileName = "test.pdf";
            _fileMock.Setup(_ => _.FileName).Returns(fileName);
        }
        [Fact]
        public void ShouldPassWhenTheExtensionIsAllowed()
        {
            //Arrange
            var allowedTypes = new string[] { ".pdf" };
            var attribute = new AllowedExtensionsAttribute(allowedTypes);

            //Act
            var result = attribute.IsValid(_fileMock.Object);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldRaiseAnExceptionWhenNotAllowed()
        {
            //Arrange
            var allowedTypes = new string[] { ".png" };
            var attribute = new AllowedExtensionsAttribute(allowedTypes);
            var expectedErrorMessage = ".pdf extension is not allowed!";

            //Act
            Action act = () => attribute.IsValid(_fileMock.Object);

            //Assert
            var exception = Assert.Throws<ApplicationException>(act);
            Assert.Equal(exception.Message, expectedErrorMessage);
        }
    }
}
