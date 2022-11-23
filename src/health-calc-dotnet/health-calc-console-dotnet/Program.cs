using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;

Console.WriteLine("Entre com a sua Altura e Peso para Calcular seu IMC");
Console.WriteLine("----------------------------------------------------");

Console.Write("Altura: ");
double Height = double.Parse(Console.ReadLine());

Console.Write("Peso: ");
double Weight = double.Parse(Console.ReadLine());

Console.Write("Sexo (F ou M): ");
string Sex = Console.ReadLine();
SexoEnum sexoEnum = Sex.ToUpper() == "F" ? SexoEnum.Feminino : SexoEnum.Masculino;

//Console.Write("Nível de Atividade Fisica (F ou M): ");
//string NivelAtividade = Console.ReadLine();

var objImc = new IMC();
var objMacronutriente = new Macronutriente();

var Result = objImc.Calc(Height, Weight);
var Category = objImc.GetIMCCategory(Result);

Console.WriteLine($"Seu IMC é: {Result} - {Category}");

var ResultMacroNutriente = objMacronutriente.Calc(sexoEnum, Height, Weight, NivelAtividadeFisicaEnum.ModeradamenteAtivo, ObjetivoFisicoEnum.Maintenance);
Console.WriteLine($"Seu consumo de Macronutrientes deve ser:");
Console.WriteLine($"Proteinas: {ResultMacroNutriente.Proteinas} Gramas ");
Console.WriteLine($"Gorduras: {ResultMacroNutriente.Gorduras} Gramas ");
Console.WriteLine($"Carboidratos: {ResultMacroNutriente.Carboidratos} Gramas ");
