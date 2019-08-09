using api.Controllers;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiTester
{
    public class ClientControllerTest
    {
        ClientController _controller;
        IClientService _service;

        public ClientControllerTest()
        {
            _service = new ClientServiceFake();
            _controller = new ClientController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Client>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
}
