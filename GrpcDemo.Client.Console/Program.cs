using Grpc.Core;
using Proto.GrpcDemo;
using Grpc.Net.Client;

Console.WriteLine("gRPC .NET Client");

var serverAddress = "http://localhost:5265";
using var channel = GrpcChannel.ForAddress(serverAddress);

//Unary
/*
Console.Write("Enter your name: ");
var name = Console.ReadLine() ?? "world";

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
Console.WriteLine($"Reply from server: {reply.Message}");
*/

//Streaming
var client = new Streaming.StreamingClient(channel);

//Server Streaming
/*
Console.WriteLine("Server Streaming");
using(var call = client.GetTime(new TimeRequest{ Count = 5}))
{
    await foreach (var response in call.ResponseStream.ReadAllAsync())
        Console.WriteLine(response.Message);
}
*/

//Client Streaming
/*
using (var call = client.UploadNumbers())
{
    for (int i = 1; i <= 10; i++)
    {
        await call.RequestStream.WriteAsync(new NumberRequest { Number = i });
        Console.WriteLine($"Sent number: {i}");
    }

    await call.RequestStream.CompleteAsync();
    var summury = await call.ResponseAsync;
    Console.WriteLine($"Received summary: {summury}");
}
*/

//Bidirectional Streaming
/*
using (var call = client.Chat())
{
    var readTask = Task.Run(async () =>
    {
        await foreach (var reply in call.ResponseStream.ReadAllAsync())
            Console.WriteLine(reply.Message);
    });

    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"Sending: Message #{i}");
        await call.RequestStream.WriteAsync(new ChatMessage { Message = $"Message #{i}" });
    }
    await call.RequestStream.CompleteAsync();

    await readTask;
}
*/