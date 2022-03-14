using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace teste_xunit
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();

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
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();

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

    }
}
