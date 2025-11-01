using GrpcDemo.Server.Services;
using Proto.GrpcDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGrpcService<StreamingService>();

app.MapGet("/", () => "gRPC server is running. Use a gRPC client.");

app.Run();