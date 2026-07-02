var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FoodDeliveryBlazorApp>("food-delivery-web")
    .WithExternalHttpEndpoints();

builder.Build().Run();
