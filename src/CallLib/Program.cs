using System.Text.Json;
using Lib;

IToolInterface tool = new ToolService();
var cts = new CancellationTokenSource();
int i = 0;
Task.Factory.StartNew(async () =>
{
    await tool.DoTask(cts.Token, 3000);
});
while (i <= 5)
{
    Console.WriteLine(JsonSerializer.Serialize(tool.RundomArray()));
    Task.Delay(1000).Wait();
    i++;
    if (i == 5)
        cts.Cancel();
}
Console.WriteLine("来了");



Console.ReadKey();
