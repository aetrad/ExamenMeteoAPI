using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bunit.JSInterop;
using Bunit;
using Xunit;
using meteoAPI.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Web;
using Moq;
using System.Net;
using Moq.Protected;

namespace meteoAPI
{
    public class ClassdIntegr
    {
        TestContext testContext = new();

        [Fact]
        public async Task ObtenirMeteo_Click_RetourneDonneesMeteo()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                       {
                           Content = new StringContent("""
                           {"Main":{"Temp":25},"Weather":[{"Description":"Sunny"}]}
                           """)
                       });

            var httpClient = new HttpClient(handlerMock.Object);
            testContext.Services.AddSingleton(httpClient);
            testContext.Services.AddSingleton<WeatherService>();
            testContext.JSInterop.Mode = JSRuntimeMode.Loose;
            var cut = testContext.RenderComponent<meteoAPI.Pages.Index>();

            // Act
            // Simuler le changement de la valeur de l'input
            var inputElement = cut.Find("input[type='text']");
            inputElement.Change("Paris"); // Changer la valeur de l'input

            // Créer un objet MouseEventArgs pour passer à ClickAsync
            var mouseEventArgs = new MouseEventArgs();

            // Cliquer sur le bouton avec les arguments de la souris
            var buttonElement = cut.Find("button");
            await buttonElement.ClickAsync(mouseEventArgs);

            // Assert
            // Vérifier si les données météo sont affichées
            var temperatureElement = cut.Find("p:contains('Température')");
            var descriptionElement = cut.Find("p:contains('Description')");
            Assert.NotNull(temperatureElement);
            Assert.NotNull(descriptionElement);
        }
    }
}
