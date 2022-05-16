using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnumExample;

namespace Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<TestEnumsDescription>();
    }

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class TestEnumsDescription
    {
        [Benchmark(Baseline = true)]
        public  void GetEnumDescriptionWithReflection()
        {
           var description = AnotherTestEnum.ValueOne.GetDescription();
        }

        [Benchmark]
        public  void GetEnumDescriptionFromSourceCode()
        {
            var description = AnotherTestEnum.ValueOne.GetDescriptionSourceGen();

        }
    }
}