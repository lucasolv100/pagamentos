using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Payments.Domain.DTOs;
using Payments.Domain.ViewModels;
using Payments.Tests.FakeData;
using Xunit;

namespace Payments.Tests
{
    public class AccountTests
    {
        public string BASE_URL => "http://localhost:5000/api/v1/account";
        
        
        [Fact]
        public async Task ShouldCreateAccountSuccessfuly()
        {
            var accountVM = new RegisterAccountVM {
                Document = CPFProvider.ValidCPFs().First(),
                IsLegalPerson = false,
                Name = "Fulano de tal"
            };

            string json = JsonConvert.SerializeObject(accountVM, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new();
            HttpResponseMessage resp = await client.PostAsync(BASE_URL, byteContent);
            string responseBody = await resp.Content.ReadAsStringAsync();
            resp.Should().Match<HttpResponseMessage>(m => m.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task ShouldNotCreateAccountInvalidCPF()
        {
            var accountVM = new RegisterAccountVM {
                Document = CPFProvider.InvalidCPFs().First(),
                IsLegalPerson = false,
                Name = "Fulano de tal"
            };

            string json = JsonConvert.SerializeObject(accountVM, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new();
            HttpResponseMessage resp = await client.PostAsync(BASE_URL, byteContent);
            string responseBody = await resp.Content.ReadAsStringAsync();
            var jsonReturn = JsonConvert.DeserializeObject<APIResponseDTO>(responseBody);
            jsonReturn.Should().Match<APIResponseDTO>(m => m.Errors.Contains("O cpf não parece válido"));
        }
        [Fact]
        public async Task ShouldNotCreateAccountShortName()
        {
            var accountVM = new RegisterAccountVM {
                Document = CPFProvider.ValidCPFs().First(),
                IsLegalPerson = false,
                Name = "Fu"
            };

            string json = JsonConvert.SerializeObject(accountVM, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new();
            HttpResponseMessage resp = await client.PostAsync(BASE_URL, byteContent);
            string responseBody = await resp.Content.ReadAsStringAsync();
            var jsonReturn = JsonConvert.DeserializeObject<APIResponseDTO>(responseBody);
            jsonReturn.Should().Match<APIResponseDTO>(m => m.Errors.Contains("O nome deve conter de 3 a 50 caracteres"));
        }
        [Fact]
        public async Task ShouldNotCreateAccountNameTooLong()
        {
            var accountVM = new RegisterAccountVM {
                Document = CPFProvider.ValidCPFs().First(),
                IsLegalPerson = false,
                Name = "Fulano de tal dkajslkdjalksjdlkjsakljdlsajdkjlksajlkdjaskldjlksajdkljaskldjklasjdklsajdlkjsakldjklsaj"
            };

            string json = JsonConvert.SerializeObject(accountVM, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new();
            HttpResponseMessage resp = await client.PostAsync(BASE_URL, byteContent);
            string responseBody = await resp.Content.ReadAsStringAsync();
            var jsonReturn = JsonConvert.DeserializeObject<APIResponseDTO>(responseBody);
            jsonReturn.Should().Match<APIResponseDTO>(m => m.Errors.Contains("O nome deve conter de 3 a 50 caracteres"));
        }
        [Fact]
        public async Task ShouldNotCreateAccountEmptyName()
        {
            var accountVM = new RegisterAccountVM {
                Document = CPFProvider.ValidCPFs().First(),
                IsLegalPerson = false,
                Name = null
            };

            string json = JsonConvert.SerializeObject(accountVM, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new();
            HttpResponseMessage resp = await client.PostAsync(BASE_URL, byteContent);
            string responseBody = await resp.Content.ReadAsStringAsync();
            var jsonReturn = JsonConvert.DeserializeObject<APIResponseDTO>(responseBody);
            jsonReturn.Should().Match<APIResponseDTO>(m => m.Errors.Contains("O nome deve ser preenchido"));
        }
        
    }
}
