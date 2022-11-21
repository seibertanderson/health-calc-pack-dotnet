using health_calc_pack_dotnet.Interfaces;

namespace health_calc_pack_dotnet
{
    public class IMC : IIMC
    {
        public double Calc(double Height, double Weight)
        {
            try
            {
                if (!IsValidData(Height, Weight))
                {
                    throw new Exception("Invalid Parameters!");
                }
                else
                {
                    return Math.Round(Weight / (Math.Pow(Height, 2)), 2);
                }
            }
            catch
            {

                throw;
            }
        }

        public string GetIMCCategory(double IMC)
        {
            var result = "";
            if (IMC < 18.5)
            {
                result = "Abaixo do Peso";
            }
            else if (IMC >= 18.5 && IMC < 25)
            {
                result = "Peso Normal";
            }
            else if (IMC >= 25 && IMC < 30)
            {
                result = "Pré-Obesidade";
            }
            else if (IMC >= 30 && IMC < 35)
            {
                result = "Obesidade Grau 1";
            }
            else if (IMC >= 35 && IMC < 40)
            {
                result = "Obesidade Grau 2";
            }
            else if (IMC >= 40)
            {
                result = "Obesidade Grau 3";
            }
            return result;
        }

        public bool IsValidData(double Height, double Weight)
        {
            if (Height <= 0 || Weight <= 0)
                return false;

            return true;
        }
    }
}