using System.Text.RegularExpressions;

if (Environment.GetCommandLineArgs().Length<2)
{
	Console.WriteLine("Usage: commandcalc 10+10. Only supports + - * /");
	return;
}

var expression = Environment.GetCommandLineArgs()[1];
var parts = Regex.Split(expression, "^([\\d]*)([+|-|*|\\/])([\\d]*)$")
	.Where(item=>!string.IsNullOrEmpty(item))
	.ToList();

if (parts.Count() == 3)
{
	if (!int.TryParse(parts[0], out var firstValue))
	{
		Console.WriteLine($"Invalid input, needs to be a number: {parts[0]}");
		return;
	}
	if (!int.TryParse(parts[2], out var secondValue))
	{
		Console.WriteLine($"Invalid input, needs to be a number: {parts[1]}");
		return;
	}
	if (parts[1]=="+")
	{
		Console.WriteLine(int.Parse(parts[0]) + int.Parse(parts[2]));
	}
	else if (parts[1]=="-")
	{
		Console.WriteLine(int.Parse(parts[0]) - int.Parse(parts[2]));
	}
	else if (parts[1]=="/")
	{
		Console.WriteLine(int.Parse(parts[0]) / int.Parse(parts[2]));
	}
	else if (parts[1]=="*")
	{
		Console.WriteLine(int.Parse(parts[0]) * int.Parse(parts[2]));
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