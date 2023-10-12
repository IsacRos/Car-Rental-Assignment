using Car_Rental;
using Car_Rental.Business;
using Car_Rental.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection.Metadata.Ecma335;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<CollectionData>();
builder.Services.AddSingleton(ServiceProvider =>
    { 
        var collectionData = ServiceProvider.GetService<CollectionData>();
        if (collectionData is null) throw new InvalidOperationException("CollectionData doesn't exist");
        return new BookingProcessor(collectionData); 
    });  

await builder.Build().RunAsync();
