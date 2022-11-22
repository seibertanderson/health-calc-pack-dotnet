using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet
{
    public class Macronutriente : IMacronutriente
    {
        const int PROTEINA = 2;
        const int GORDURA_BUKING = 2;
        const int GORDURA = 1;
        const int CARBOIDRATO_BUKING_T1 = 4;
        const int CARBOIDRATO_BUKING_T2 = 7;
        const int CARBOIDRATO_CUTTING = 2;
        const int CARBOIDRATO_MAINTENANCE = 5;
        const int MIN_WEIGHT = 35;

        public MacronutrienteModel Calc(SexoEnum sexo,
            double Height,
            double Weight,
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            ObjetivoFisicoEnum ObjetivoFisico)
        {
            if (!IsValidData(Weight))
                throw new Exception("Invalid Parameters!");


            var Proteinas = 0;
            var Carboidratos = 0;
            var Gorduras = 0;

            if (ObjetivoFisico == ObjetivoFisicoEnum.Cutting)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_CUTTING * (int)Weight;
                Gorduras = GORDURA * (int)Weight;
            }
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Bulking)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_BUKING_T1 * (int)Weight;
                Gorduras = GORDURA_BUKING * (int)Weight;

                if (NivelAtividadeFisica == NivelAtividadeFisicaEnum.BastanteAtivo || NivelAtividadeFisica == NivelAtividadeFisicaEnum.ExtremamenteAtivo)
                {
                    Carboidratos = CARBOIDRATO_BUKING_T2 * (int)Weight;
                }
            }
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Maintenance)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_MAINTENANCE * (int)Weight;
                Gorduras = GORDURA * (int)Weight;
            }

            var Result = new MacronutrienteModel()
            {
                Proteinas = Proteinas,
                Carboidratos = Carboidratos,
                Gorduras = Gorduras,
            };

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
