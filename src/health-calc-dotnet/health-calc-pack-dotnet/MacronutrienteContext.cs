using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet
{
    public class MacronutrienteContext
    {
        private IMacronutrienteStrategy Strategy;

        public MacronutrienteContext(IMacronutrienteStrategy _Strategy)
        {
            Strategy = _Strategy;
        }

        public void SetStrategy(IMacronutrienteStrategy Strategy)
        {
            this.Strategy = Strategy;
        }

        public MacronutrienteModel Execute(double Weight)
        {
            return Strategy.Calc(Weight);
        }
    }
}
