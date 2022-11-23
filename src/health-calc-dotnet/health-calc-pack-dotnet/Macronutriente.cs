using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy;

namespace health_calc_pack_dotnet
{
    public class Macronutriente : IMacronutriente
    {
        const int MIN_WEIGHT = 35;

        public MacronutrienteModel Calc(SexoEnum sexo,
            double Height,
            double Weight,
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            ObjetivoFisicoEnum ObjetivoFisico)
        {
            if (!IsValidData(Weight))
                throw new Exception("Invalid Parameters!");

            IMacronutrienteStrategy macronutrienteStrategy = new CuttingStrategy(sexo); ;

            if (ObjetivoFisico == ObjetivoFisicoEnum.Cutting)
                macronutrienteStrategy = new CuttingStrategy(sexo);
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Bulking)
            {
                if (NivelAtividadeFisica == NivelAtividadeFisicaEnum.BastanteAtivo
                    || NivelAtividadeFisica == NivelAtividadeFisicaEnum.ExtremamenteAtivo)
                {
                    macronutrienteStrategy = new BulkingNivelAtividadeAtivoStrategy(sexo);
                }
                else
                {
                    macronutrienteStrategy = new BulkingStrategy(sexo);
                }
            }
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Maintenance)
                macronutrienteStrategy = new MaintenanceStrategy(sexo);

            var context = new MacronutrienteContext(macronutrienteStrategy);
            var Result = context.Execute(Weight);

            return Result;
        }

        public bool IsValidData(double Weight)
        {
            if (Weight <= MIN_WEIGHT)
                return false;

            return true;
        }
    }
}
