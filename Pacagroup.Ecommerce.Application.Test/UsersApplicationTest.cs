using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacagroup.Ecommerce.Application.Interface;

namespace Pacagroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();

        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código.
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validación";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado.
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado.
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrecto_RetornarMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código.
            var userName = "jucastro";
            var password = "123456";
            var expected = "Autenticación Exitosa!!!";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado.
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado.
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código.
            var userName = "jucastro1";
            var password = "123456";
            var expected = "Usuario no existe";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado.
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado.
            Assert.AreEqual(expected, actual);

        }
    }
}
