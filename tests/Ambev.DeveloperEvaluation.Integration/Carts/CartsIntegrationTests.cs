using System.Net;
using System.Text;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.Carts
{
    [TestCaseOrderer("Ambev.DeveloperEvaluation.Integration.PriorityOrderer", "Ambev.DeveloperEvaluation.Integration")]
    public class CartsIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        
        public CartsIntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact, TestPriority(1)]
        public async Task ListCarts_ValidPaginationParams_ReturnsPagedResponse()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();

            // Act
            var response = await _httpClient.GetAsync("/api/Carts?_page=1&_size=10");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var pagedResponse = JsonConvert.DeserializeObject<PaginatedResponse<ListCartsResponse>>(body);

            pagedResponse.Should().NotBeNull();
            pagedResponse!.Success.Should().BeTrue();
        }

        [Fact, TestPriority(2)]
        public async Task CreateCart_ValidPayload_ReturnsCreatedResponse()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();

            var payload = new
            {
                userId = Guid.Parse("be5ce2c2-c320-41d5-ae59-eb3f66d1b656"),
                date = DateTime.UtcNow,
                products = new[]
                {
                    new { productId = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b"), quantity = 2 }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("/api/Carts", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var body = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(body);

            apiResponse.Should().NotBeNull();
            apiResponse!.Success.Should().BeTrue();
            apiResponse.Data.Should().NotBeNull();
            apiResponse.Data.Products.Should().HaveCount(1);
        }

        [Fact, TestPriority(3)]
        public async Task GetCart_ValidId_ReturnsSuccessResponse()
        {   
            // Arrange
            var _httpClient = _factory.CreateClient();

            var productId = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b");
            var payload = new
            {
                userId = Guid.Parse("be5ce2c2-c320-41d5-ae59-eb3f66d1b656"),
                date = DateTime.UtcNow,
                products = new[]
                {
                new { productId = productId, quantity = 1 }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var postResponse = await _httpClient.PostAsync("/api/Carts", content);
            postResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var body = await postResponse.Content.ReadAsStringAsync();
            var createdCart = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(body);
            var createdCartId = createdCart!.Data.Id;

            // Act: 
            var getResponse = await _httpClient.GetAsync($"/api/Carts/{createdCartId}");

            // Assert
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var getBody = await getResponse.Content.ReadAsStringAsync();
            var getCart = JsonConvert.DeserializeObject<ApiResponseWithData<GetCartResponse>>(getBody);

            getCart.Should().NotBeNull();
            getCart!.Data.Id.Should().Be(createdCartId);
            getCart.Data.Products.Should().HaveCount(1);
        }

        [Fact, TestPriority(4)]
        public async Task UpdateCart_ValidPayload_ReturnsUpdatedResponse()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();

            var createPayload = new
            {
                userId = Guid.NewGuid(),
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b"), quantity = 1 } }
            };

            var createContent = new StringContent(JsonConvert.SerializeObject(createPayload), Encoding.UTF8, "application/json");
            var createResponse = await _httpClient.PostAsync("/api/Carts", createContent);
            var createdBody = await createResponse.Content.ReadAsStringAsync();
            var created = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(createdBody);

            // Act
            var updatePayload = new
            {
                id = created!.Data.Id,
                userId = created.Data.UserId,
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b"), quantity = 2 } }
            };

            var updateContent = new StringContent(JsonConvert.SerializeObject(updatePayload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Carts/{updatePayload.id}", updateContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact, TestPriority(5)]
        public async Task DeleteCart_ValidId_ReturnsSuccessResponse()
        {
            // Arrange
            var _httpClient = _factory.CreateClient();

            var createPayload = new
            {
                userId = Guid.Parse("be5ce2c2-c320-41d5-ae59-eb3f66d1b656"),
                date = DateTime.UtcNow,
                products = new[] { new { productId = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b"), quantity = 1 } }
            };

            var createContent = new StringContent(JsonConvert.SerializeObject(createPayload), Encoding.UTF8, "application/json");
            var createResponse = await _httpClient.PostAsync("/api/Carts", createContent);
            var createBody = await createResponse.Content.ReadAsStringAsync();
            var created = JsonConvert.DeserializeObject<ApiResponseWithData<CreateCartResponse>>(createBody);

            // Act
            var response = await _httpClient.DeleteAsync($"/api/Carts/{created!.Data.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
