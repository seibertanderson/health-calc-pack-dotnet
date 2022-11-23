using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;

Console.WriteLine("Entre com a sua Altura e Peso para Calcular seu IMC");
Console.WriteLine("----------------------------------------------------");

Console.Write("Qual sua Altura: ");
double Height = double.Parse(Console.ReadLine());

Console.Write("Qual seu Peso Peso: ");
double Weight = double.Parse(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("F - Feminino");
Console.WriteLine("M - Masculino");
Console.Write("Qual seu Sexo: ");
string Sex = Console.ReadLine();
SexoEnum sexoEnum = Sex.ToUpper() == "F" ? SexoEnum.Feminino : SexoEnum.Masculino;

Console.WriteLine();
Console.WriteLine("Sedentario = 0");
Console.WriteLine("Moderadamente Ativo = 1");
Console.WriteLine("Bastante Ativo = 2");
Console.WriteLine("Extremamente Ativo = 3");
Console.Write("Qual seu Nível de Atividade Fisica: ");
NivelAtividadeFisicaEnum NivelAtividade = (NivelAtividadeFisicaEnum)int.Parse(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("Aumentar Peso (Bulking) = 0");
Console.WriteLine("Perder Gordura (Cutting) = 1");
Console.WriteLine("Manter meu Peso (Maintenance) = 2");
Console.Write("Qual seu Objetivo Físico: ");
ObjetivoFisicoEnum ObjetivoFisico = (ObjetivoFisicoEnum)int.Parse(Console.ReadLine());

var objImc = new IMC();
var objMacronutriente = new Macronutriente();

var CalculoIMC = objImc.Calc(Height, Weight);
var CategoriaIMC = objImc.GetIMCCategory(CalculoIMC);
var ResultMacroNutriente = objMacronutriente.Calc(sexoEnum, Height, Weight, NivelAtividade, ObjetivoFisico);

Console.WriteLine();
Console.WriteLine("##########  RESULTADO  ##########");
Console.WriteLine($"Seu IMC é: {CalculoIMC} - {CategoriaIMC}");
Console.WriteLine($"Seu consumo de Macronutrientes deve ser:");
Console.WriteLine($"Proteinas: {ResultMacroNutriente.Proteinas} Gramas ");
Console.WriteLine($"Gorduras: {ResultMacroNutriente.Gorduras} Gramas ");
Console.WriteLine($"Carboidratos: {ResultMacroNutriente.Carboidratos} Gramas ");
