using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace teste_xunit
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Teste aceleração do veiculo")]
        //agrupador de testes
        [Trait("Funcionalidade", "Acelerar")]
        public void TesteVeiculoAcelerar()
        {
            //Padrão AAA
            //Arrange - prepara cenário
            var veiculo = new Veiculo();
            //Act - metodo sobre teste
            veiculo.Acelerar(10);
            //Assert - validãção dos resultados obtidos com os esperados
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact(DisplayName = "Teste frenagem do veiculo")]
        //agrupador de testes
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange - prepara cenário
            var veiculo = new Veiculo();
            //Act - metodo sobre teste
            veiculo.Frear(10);
            //Assert - validãção dos resultados obtidos com os esperados
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

            //Act
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            //Assert
            Assert.Equal(TipoVeiculo.Motocicleta, veiculo.Tipo);
        }

        //skip ignorará o teste seguinte
        [Fact(Skip = "Teste ainda não implementado!")]
        public void ValidaProprietaio()
        {

        }
    }
}
