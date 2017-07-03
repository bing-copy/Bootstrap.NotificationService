# Bootstrap.Service.NotificationService

This project provides a quick development solution about notification service which supports `sms`, `email`, `WeChat` and so on.

## Status

+ Under development

## Get Started

1. Customize or add your own message senders and handlers by modifying or adding files under `Business.Senders` and `Business.Handlers`.
1. Customize your own database by adding options to `AddDbContext` in `Startup.cs`.
3. Add your own business logic.
2. Publish and deploy.

## Project Structure

### Bootstrap.Components

See <a href="{todo: address to components}">here</a>.

### Bootstrap.NotificationService.Models

Default models.

### Bootstrap.NotificationService.Business

Default business logic layer. 
+ You can customize your own `XXXMessageHandler` and `XXXMessageSender` by implementing `IXXXHandler` and `IXXXSender`.
+ You can add new `XXXMessageHandler` and `XXXMessageSender` by adding interfaces inherit from `IMessageHandler` and `IMessageSender`.
+ You can modify or replace `MessageHandler` which provides a default message handling solution. 

## TODO

1. Full test.
1. Default WeChat message solution.
1. Retry mechanism.
2. Add scheduled message sending support.
1. Conditional compile.
1. Integrate publish and deployment files.