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
        [InlineData(NivelAtividadeFisicaEnum.Sedentario, 340)]
        [InlineData(NivelAtividadeFisicaEnum.ModeradamenteAtivo, 340)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 595)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 595)]
        public void When_RequestMacronutrienteCalcWithValidDataForBuking_ThenReturnResult(
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            int Carboidratos)
        {
            //Arrange
            var Macronutriente = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividade = NivelAtividadeFisica;
            var ObjetivoFisico = ObjetivoFisicoEnum.Bulking;

            var Expected = new MacronutrienteModel()
            {
                Carboidratos = Carboidratos,
                Proteinas = 170,
                Gorduras = 170
            };

            //Act
            var Result = Macronutriente.Calc(Sexo, Height, Weight, NivelAtividade, ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Gorduras, Result.Gorduras);
            Assert.Equal(Expected.Carboidratos, Result.Carboidratos);
            Assert.Equal(Expected.Proteinas, Result.Proteinas);
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