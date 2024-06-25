using Xunit;

namespace Teste.Tests
{
    public class EventosTestsController
    {
        [Fact]
        public void StatusCode201()
        {
            // Arrange
            var controller = new EventosTestsController();

            // Act
            var resultado = controller.CriarRecurso(StatusCode201);

            // Assert
            Assert.Equal(201, resultado.StatusCode);
        }
    }
}

