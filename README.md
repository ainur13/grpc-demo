# gRPC Demo

Мини-проект со всеми типами взаимодействия в gRPC:
- Unary
- Server Streaming
- Client Streaming
- Bidirectional Streaming

Основные компоненты:
protos - папка содержащая все .proto-файлы 
GrpcDemo.Client - консольное приложение, вызывающие методы сервера
GrpcDemo.Server - gRPC-сервер, реализующие сервисы .proto-файлов

Реализовано по гайдам [Microsoft](https://learn.microsoft.com/en-gb/aspnet/core/grpc)
