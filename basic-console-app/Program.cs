// See https://aka.ms/new-console-template for more information

using shared_code;

var instance = new SharedCode();
Console.WriteLine("Starting performance test in console app.");
instance.PerformanceTest();
Console.ReadKey();