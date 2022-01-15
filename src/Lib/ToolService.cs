using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ToolService : IToolInterface
    {
        public IEnumerable<int> RundomArray()
        {

            var random = new Random();
            return Enumerable.Range(1, random.Next(2, 40));
        }


        public async Task DoTask(CancellationToken cancellationToken,int ms)
        {
            try
            {
                var po = new ParallelOptions()
                {
                    CancellationToken = cancellationToken,
                    MaxDegreeOfParallelism = int.MaxValue
                };
                Parallel.ForEach(Enumerable.Range(1, 5), po, async num =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var random = new Random().Next(0, 100);
                        Console.WriteLine($"{num}+{random}={num + random}");
                    }
                    await Task.Delay(ms);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
