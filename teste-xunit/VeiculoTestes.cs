using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace teste_xunit
{
    public class VeiculoTestes:IEnumerable<object[]>
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        
        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            this.saidaConsoleTeste = saidaConsoleTeste;
            this.saidaConsoleTeste.WriteLine("Construtor invocado!");
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo
                {
                    Proprietario = "André Silva",
                    Placa = "ASD-9999",
                    Cor="Verde",
                    Modelo="Fusca"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [Theory(DisplayName = "Teste com objeto de classe", Skip="Teste com problemas de implementação")]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Teste aceleração do veiculo")]
        //agrupador de testes
        [Trait("Funcionalidade", "Acelerar")]
        public void TesteVeiculoAcelerarComParametro10()
        {
            //Padrão AAA
            //Arrange - prepara cenário
            //var veiculo = new Veiculo();
            //Act - metodo sobre teste
            veiculo.Acelerar(10);
            //Assert - validãção dos resultados obtidos com os esperados
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact(DisplayName = "Teste frenagem do veiculo")]
        //agrupador de testes
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange - prepara cenário
            //var veiculo = new Veiculo();
            //Act - metodo sobre teste
            veiculo.Frear(10);
            //Assert - validãção dos resultados obtidos com os esperados
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
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
        public void ValidaNomeProprietaio()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            //Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = "Gabriel Tozatto";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "HB20";
            veiculo.Placa = "asd-9999";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do veículo:", dados);
        }

        [Fact]
        public void TesteTamanhoNomeProprietario()
        {
            //Arrange
            string nomeProprietario = "ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TesteExcecaoPlaca()
        {
            //Arrange
            string placa = "ASDF0808";

            //Assert/Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            //Act
            Assert.Contains("4°", mensagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ASD-995U";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );

        }
    }
}
