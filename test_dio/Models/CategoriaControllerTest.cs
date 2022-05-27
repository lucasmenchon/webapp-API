using api_dio.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using mvc_dio.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace dio_test.Models
{
    public class CategoriaControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriaControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Test Categoria" };

            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Categorias.FindAsync(1))
                .ReturnsAsync(_categoria);

            _mockContext.Setup(m => m.SetModified(_categoria));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        }

        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }

        [Fact]
        public async Task Post_Categoria()
        {

            var service = new CategoriasController(_mockContext.Object);
            await service.PostCategoria(_categoria);

            _mockSet.Verify(x => x.Add(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once());
        }

        [Fact]
        public async Task Delete_Categoria()
        {

            var service = new CategoriasController(_mockContext.Object);
            await service.DeleteCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
            Times.Once());

            _mockContext.Verify(x => x.Remove(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once());
        }
    }
}
