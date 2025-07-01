using System.Net;
using System.Text;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Ambev.DeveloperEvaluation.Functional.Carts
{
    public class CartFunctionalTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public CartFunctionalTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateCart_ValidRequest_ReturnsCreated()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();  

            var payload = new
            {
                userId = Guid.NewGuid(),
                date = DateTime.UtcNow,
                products = new[]
                {
                new { productId = Guid.NewGuid(), quantity = 2 }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("/api/Carts", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(responseBody);

            result.Should().NotBeNull();
            result!.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task ListCarts_ReturnsEmptyListInitially()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();

            // Act
            var response = await _httpClient.GetAsync("/api/Carts");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedResponse<ListCartsResponse>>(responseBody);

            result.Should().NotBeNull();
            result!.Success.Should().BeTrue();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task GetCart_ValidId_ReturnsCart()
        {
            // Arrange
            var client = _factory.CreateClient();

            var payload = new
            {
                userId = Guid.NewGuid(),
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.NewGuid(), quantity = 2 } }
            };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("/api/Carts", content);
            var createdCart = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(await createResponse.Content.ReadAsStringAsync());

            var cartId = createdCart!.Data.Id;

            // Act
            var response = await client.GetAsync($"/api/Carts/{cartId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseWithData<GetCartResponse>>(body);

            result.Should().NotBeNull();
            result!.Data.Id.Should().Be(cartId);
        }

        [Fact]
        public async Task UpdateCart_ValidData_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            var payload = new
            {
                userId = Guid.NewGuid(),
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.NewGuid(), quantity = 1 } }
            };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("/api/Carts", content);
            var createdCart = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(await createResponse.Content.ReadAsStringAsync());
            var cartId = createdCart!.Data.Id;
                  
            var updatePayload = new
            {
                id = cartId,
                userId = payload.userId,
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.NewGuid(), quantity = 3 } }
            };

            var updateContent = new StringContent(JsonConvert.SerializeObject(updatePayload), Encoding.UTF8, "application/json");
            
            // Act
            var updateResponse = await client.PutAsync($"/api/Carts/{cartId}", updateContent);
            
            // Assert
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteCart_ValidId_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.CreateClient();

            var payload = new
            {
                userId = Guid.NewGuid(),
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.NewGuid(), quantity = 1 } }
            };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var createResponse = await client.PostAsync("/api/Carts", content);
            var createdCart = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(await createResponse.Content.ReadAsStringAsync());
            var cartId = createdCart!.Data.Id;

            // Act
            var deleteResponse = await client.DeleteAsync($"/api/Carts/{cartId}");

            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
