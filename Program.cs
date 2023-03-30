using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/GetAllCoupans", () =>
{
    return Results.Ok(CoupanStore.coupansList.ToList());
}
).Produces<Coupan>(200).Produces(400);

app.MapGet("/GetCoupanByName/{name:String}", (string name) =>
{
    if (name != "" && name != null)
    {
        var record = CoupanStore.coupansList.Where(x => x.Name.Contains(name)).ToList();

        if (record.Count > 0)
        {
            return Results.Ok(record);
        }
        else
        {
            return Results.NotFound("No Coupans Found");
        }
    }
    else
    {
        return Results.BadRequest();
    }
}
).Produces<Coupan>(200).Produces(404).Produces(400);

app.MapPost("/AddCoupan", ([FromBody] Coupan coupan) =>
{
    CoupanStore.coupansList.Add(coupan);
    return Results.Accepted("/GetCoupanByName", new { coupan.Name });
});


app.UseHttpsRedirection();
app.Run();

