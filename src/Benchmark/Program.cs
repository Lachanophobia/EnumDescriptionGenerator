using EnumExample;

namespace Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(AnotherTestEnum.ValueOne.GetDescription());
        Console.WriteLine(AnotherTestEnum.ValueTwo.GetDescription());
    }
}