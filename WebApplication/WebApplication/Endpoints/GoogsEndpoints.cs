namespace WebApplication.Endpoints;

public static class GoogsEndpoints
{
    public static IEndpointRouteBuilder MapGoods(this IEndpointRouteBuilder app)
    {
        var goodsGroup = app.MapGroup("/api/goods").WithTags("Goods");

        goodsGroup.MapGet("/", () => new[] { "Good 1", "Good 2" });
        // ...

        return app;
    }
}
