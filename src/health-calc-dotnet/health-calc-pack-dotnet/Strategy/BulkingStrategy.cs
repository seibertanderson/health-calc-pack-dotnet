using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy.Base;

namespace health_calc_pack_dotnet.Strategy
{
    public class BulkingStrategy : MacronutrienteBase, IMacronutrienteStrategy
    {
        const double PROTEINA = 2;
        const double GORDURA = 2;
        const double CARBOIDRATO = 4;

        public BulkingStrategy(SexoEnum Sexo) : base(Sexo)
        {
        }

        public MacronutrienteModel Calc(double Weight)
        {
            var Result = new MacronutrienteModel()
            {
                Proteinas = PROTEINA * (int)Weight * GENDER_MULTIPLIER,
                Carboidratos = CARBOIDRATO * (int)Weight * GENDER_MULTIPLIER,
                Gorduras = GORDURA * (int)Weight * GENDER_MULTIPLIER,
            };

            return Result;

        }
    }
}
