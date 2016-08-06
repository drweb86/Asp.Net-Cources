using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SK.L16.Dal;
using SK.L16.Bl;
using Moq;

namespace SK.L16.UnitTests
{
    class FakeContext : IContext
    {
        public List<Photo> GetPhotos()
        {
            return (new List<Photo> { new Photo() { Name = "Kaka", Url = "1" } });
        }
    }

    [TestClass]
    public class PhotoServiceUnitTests
    {
        [TestMethod]
        public void TestPhotos_GetPhotos_ShouldReturnPhotos() // what's being tested _ what's used _ expected result
        {
            //arrange

            // all other staff is fake one.

            var mockContext = new Mock<IContext>();
            var photos = new List<Photo> { new Photo() { Name = "Kaka", Url = "1" } };
            mockContext.Setup(m => m.GetPhotos()).Returns(photos);


            //var service = new PhotoService(new FakeContext());
            var service = new PhotoService(mockContext.Object);
            mockContext.Verify(m => m.GetPhotos(), Times.Once);

            //var service = new PhotoService(new FakeContext());

            // act
            var result = service.GetPhotos();

            // assert
            Assert.AreEqual(true, result.Count > 0);
            //Assert.AreEqual(false, result.Count > 0);
        }
    }
}
