using System;
using Xunit;
using WebApi.Controllers;

namespace WebApi.Test
{
    public class WebApiFixture
    {
        [Fact]
        public void When_Hi_prints_hello()
        {
            var userController = new UserController();
            var response = userController.Get("hi").Value;
            Assert.Equal("hello", response);

        }
        [Fact]
        public void When_Hello_prints_hi()
        {
            var userController = new UserController();
            var response = userController.Get("hello").Value;
            Assert.Equal("hi", response);
        }
        [Fact]
        public void When_invalid_salutation_prints_invalid()
        {
            var userController = new UserController();
            var response = userController.Get("sdfsdf").Value;
            Assert.Equal("invalid", response);

        }
    }
}
