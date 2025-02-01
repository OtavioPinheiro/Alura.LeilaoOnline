using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje - cenário
            var valorNegativo = -100;
            
            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act - método sob teste
                () => new Lance(null, valorNegativo)
            );
        }
    }
}
