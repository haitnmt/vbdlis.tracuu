using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddValkey("Cache", 6379);

var webApi = builder.AddProject<Haihv_VBDLIS_TraCuu_Web_Api>("WebApi")
    .WithReference(cache)
    .WaitFor(cache);

builder.AddProject<Haihv_VBDLIS_TraCuu_App_Web>("WebApp")
    .WithReference(webApi)
    .WaitFor(webApi);

builder.Build().Run();