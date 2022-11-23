using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;
using System;
using Xunit;

namespace health_calc_test_xunit
{
    public class MacronutrienteTest
    {
        [Fact]
        public void When_RequestMacronutrienteCalcWithValidDataForCutting_ThenReturnResult()
        {
            //Arrange
            var Macronutriente = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividade = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Cutting;

            var Expected = new MacronutrienteModel()
            {
                Carboidratos = 170,
                Proteinas = 170,
                Gorduras = 85
            };

            //Act
            var Result = Macronutriente.Calc(Sexo, Height, Weight, NivelAtividade, ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Gorduras, Result.Gorduras);
            Assert.Equal(Expected.Carboidratos, Result.Carboidratos);
            Assert.Equal(Expected.Proteinas, Result.Proteinas);
        }

        [Theory]
        [InlineData(NivelAtividadeFisicaEnum.Sedentario, 340, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.ModeradamenteAtivo, 340, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 595, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 595, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 476, 136, 136, SexoEnum.Feminino)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 476, 136, 136, SexoEnum.Feminino)]
        public void When_RequestMacronutrienteCalcWithValidDataForBuking_ThenReturnResult(
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            double Carboidratos,
            double Proteinas,
            double Gorduras,
            SexoEnum sexo)
        {
            //Arrange
            var Macronutriente = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = sexo;
            var NivelAtividade = NivelAtividadeFisica;
            var ObjetivoFisico = ObjetivoFisicoEnum.Bulking;

            var Expected = new MacronutrienteModel()
            {
                Carboidratos = Carboidratos,
                Proteinas = Proteinas,
                Gorduras = Gorduras
            };

            //Act
            var Result = Macronutriente.Calc(Sexo, Height, Weight, NivelAtividade, ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Gorduras, Gorduras);
            Assert.Equal(Expected.Carboidratos, Carboidratos);
            Assert.Equal(Expected.Proteinas, Proteinas);
        }

        [Fact]
        public void When_RequestMacronutrienteCalcWithValidDataForMaintenance_ThenReturnResult()
        {
            //Arrange
            var Macronutriente = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividade = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Maintenance;

            var Expected = new MacronutrienteModel()
            {
                Carboidratos = 425,
                Proteinas = 170,
                Gorduras = 85
            };

            //Act
            var Result = Macronutriente.Calc(Sexo, Height, Weight, NivelAtividade, ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Gorduras, Result.Gorduras);
            Assert.Equal(Expected.Carboidratos, Result.Carboidratos);
            Assert.Equal(Expected.Proteinas, Result.Proteinas);
        }

        [Fact]
        public void When_RequestMacronutrienteCalcWithInvalidData_ThenThrowExcpetion()
        {
            //Arrange
            var Macronutriente = new Macronutriente();
            var Height = 1.68;
            var Weight = 34;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividade = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Maintenance;

            //Act and Assert
            Assert.Throws<Exception>(() => Macronutriente.Calc(Sexo, Height, Weight, NivelAtividade, ObjetivoFisico));
        }
    }
}