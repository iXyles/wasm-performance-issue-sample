using System.Diagnostics;

namespace shared_code;

public class SharedCode
{
    private const int I = 5000; // iterations we perform the look up
    private const int N = 3000; // the amount of items we have.
    private readonly List<Guid> _items = new();
    private readonly Guid _last;

    public SharedCode()
    {
        for (var i = 0; i < N; i++)
            _items.Add(Guid.NewGuid());
        _last = _items.Last();
    }

    public void PerformanceTest()
    {
        LinqFirstTest();
        ForLoopFirstTest();
    }

    private void ForLoopFirstTest()
    {
        Console.WriteLine($"For loop first test (worst case scenario {I} times on {N} items) start");
        var watch = new Stopwatch();
        watch.Start();

        for (var i = 0; i < I; i++)
            _items.First(i => i == _last);

        watch.Stop();
        Console.WriteLine($"For loop first test (worst case scenario {I} times on {N} items) finished, time: {watch.ElapsedMilliseconds}ms");
    }

    private void LinqFirstTest()
    {
        Console.WriteLine($"For loop first test (worst case scenario {I} times on {N} items) start");
        var watch = new Stopwatch();
        watch.Start();

        for (var i = 0; i < I; i++)
            foreach (var item in _items)
                if (item == _last)
                    break;

        watch.Stop();
        Console.WriteLine($"For loop first test (worst case scenario {I} times on {N} items) finished, time: {watch.ElapsedMilliseconds}ms");
    }
}