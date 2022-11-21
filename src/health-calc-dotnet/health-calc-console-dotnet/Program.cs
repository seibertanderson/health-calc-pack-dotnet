using health_calc_pack_dotnet;

Console.WriteLine("Entre com a sua Altura e Peso para Calcular seu IMC");
Console.WriteLine("----------------------------------------------------");

Console.Write("Altura: ");
double Height = double.Parse(Console.ReadLine());

Console.Write("Peso: ");
double Weight = double.Parse(Console.ReadLine());

var _imc = new IMC();
var Result = _imc.Calc(Height, Weight);
var Category = _imc.GetIMCCategory(Result);

Console.WriteLine($"Seu IMC é: {Result} - {Category}");
