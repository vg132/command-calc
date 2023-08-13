using System.Globalization;
using System.Text.RegularExpressions;

if (Environment.GetCommandLineArgs().Length<2)
{
	Console.WriteLine("Usage: commandcalc 10+10. Only supports + - * /");
	return;
}

var expression = Environment.GetCommandLineArgs()[1];
var parts = Regex.Split(expression, "^([\\d\\.,]*)([+|-|*|\\/])([\\d\\.,]*)$")
	.Where(item=>!string.IsNullOrEmpty(item))
	.ToList();

if (parts.Count() == 3)
{
	var culture = new CultureInfo("en-us");
	if (!float.TryParse(parts[0].Replace(",", "."), NumberStyles.Any, culture.NumberFormat, out var firstValue))
	{
		Console.WriteLine($"Invalid input, needs to be a number: {parts[0]}");
		return;
	}
	if (!float.TryParse(parts[2].Replace(",", "."), NumberStyles.Any, culture.NumberFormat, out var secondValue))
	{
		Console.WriteLine($"Invalid input, needs to be a number: {parts[1]}");
		return;
	}
	if (parts[1]=="+")
	{
		Console.WriteLine(firstValue + secondValue);
	}
	else if (parts[1]=="-")
	{
		Console.WriteLine(firstValue - secondValue);
	}
	else if (parts[1]=="/")
	{
		Console.WriteLine(firstValue / secondValue);
	}
	else if (parts[1]=="*")
	{
		Console.WriteLine(firstValue * secondValue);
	}
	else
	{
		Console.WriteLine($"Invalid input, needs to be one of +-/*: {parts[1]}");
	}
}
else
{
	Console.WriteLine($"Invalid input, needs to be an expression, 10+10. Only support + - * /");
}