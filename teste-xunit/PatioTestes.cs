using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace teste_xunit
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        private Operador operador;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "João Pedro";
            estacionamento.Operador = operador;

            this.saidaConsoleTeste = saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado!");
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            //Patio estacionamento = new Patio();
            //Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = "Gabriel Tozatto";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "HB20";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
            Assert.Equal("vermelho", veiculo.Cor.ToLower());

        }
    
        //teste com um volume maior de dados
        [Theory]
        [InlineData("Gabriel Tozatto", "asd-1233", "HB20S", "Vermelho")]
        [InlineData("Paulo Tozatto", "asd-9878", "CIVIC", "Preto")]
        [InlineData("Charlene Tozatto", "asd-9299", "PULSE", "Azul")]
        public void ValidaFaturamentoComVariosVeiculos(string nome, string placa, string modelo, string cor)
        {
            //Arrange
            //Patio estacionamento = new Patio();
            //Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = nome;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
            Assert.Equal(cor.ToLower(), veiculo.Cor.ToLower());
        }

        [Theory]
        [InlineData("Gabriel Tozatto", "asd-1233", "HB20S", "Vermelho")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string nome, string placa, string modelo, string cor)
        {
            //Arrange
            //Patio estacionamento = new Patio();
            //Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = nome;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            Veiculo consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Equal(placa, consultado.Placa);
            Assert.Contains("### Ticket Estacionamento Alura ###", veiculo.Ticket);


        }

        [Fact]
        public void AlteraDadosVeiculo()
        {
            //Arrange
            //Patio estacionamento = new Patio();
            //Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = "Gabriel Tozatto";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "HB20";
            veiculo.Placa = "asd-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Gabriel Tozatto";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "HB20";
            veiculoAlterado.Placa = "asd-9999";

            //Act
            Veiculo alterado = estacionamento.AlteraDadosVeiculos(veiculoAlterado);

            //Assert 
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Disposable invocado!");
        }
    }
}
