using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Committee_Microservices_Integration
{
    public class UnitTest
    {
        private readonly TestContext _context;

        public UnitTest()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResponse()
        {
            // Act
            var response = await _context.Client.GetAsync("/api/Values");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
