# wasm-performance-issue-sample
Sample to demonstrate Linq &amp; For loop search performance issue in wasm vs native console app
This example is based on .NET 6

# Performance difference (executed code on 6.0.1)

Without AOT

![execution-time](https://user-images.githubusercontent.com/5310286/151583780-872f2545-cab6-4b8e-9e2e-447467688516.png)

# Performance difference (executed code on .NET 7 RC 2)

Without AOT

![execution-time](https://user-images.githubusercontent.com/5310286/195196104-7c245692-5aa2-4dcb-a05e-e9781d804d1c.png)

With AOT

![with-AOT](https://user-images.githubusercontent.com/5310286/195196163-bd36bc26-9088-4331-b3f6-61a0e66bc2fc.png)

# Link to code
https://github.com/iXyles/wasm-performance-issue-sample/blob/1d8255c85ef01235ef8d36f29ebdbe8a2dc28589/shared-code/SharedCode.cs

# Code
```csharp
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
```
