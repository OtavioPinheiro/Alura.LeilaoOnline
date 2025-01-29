using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            var pedro = new Interessada("Pedro", leilao);
            var maria = new Interessada("Maria", leilao);
            var joao = new Interessada("Jo�o", leilao);

            leilao.RecebeLance(joao, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(joao, 990);
            leilao.RecebeLance(pedro, 1400);

            //Act - m�todo sob teste
            leilao.TerminaPregao();
            
            //Assert
            var valorEsperado = 1400;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(pedro, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);

            //Act - m�todo sob teste
            leilao.TerminaPregao();
            
            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        
        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoSemLances()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            
            //Act - m�todo sob teste
            leilao.TerminaPregao();
            
            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}