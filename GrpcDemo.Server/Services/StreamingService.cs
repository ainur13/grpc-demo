using Grpc.Core;
using Proto.GrpcDemo;

namespace GrpcDemo.Server.Services;

public class StreamingService : Streaming.StreamingBase
{
    public override async Task GetTime(TimeRequest request, IServerStreamWriter<TimeReply> responseStream, ServerCallContext context)
    {
        for (int i = 1; i <= request.Count; i++)
        {
            await responseStream.WriteAsync(new TimeReply { Message = $"{i} {DateTime.Now:T}" });
            await Task.Delay(1000);
        }
    }

    public override async Task<NumberSummary> UploadNumbers(IAsyncStreamReader<NumberRequest> requestStream, ServerCallContext context)
    {
        int sum = 0;
        int count = 0;

        await foreach (var request in requestStream.ReadAllAsync())
        {
            sum += request.Number;
            count++;
        }
        return new NumberSummary { Sum = sum, Count = count };
    }

    public override async Task Chat(IAsyncStreamReader<ChatMessage> requestStream, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync())
        {
            await responseStream.WriteAsync(new ChatMessage
            {
                User = "Server",
                Message = $"Received: {request.Message}"
            });
        }
    }
}