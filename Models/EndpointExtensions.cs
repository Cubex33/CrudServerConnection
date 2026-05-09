namespace CurlConnection.Models
{
    public static class EndpointExtensions
    {
        public static void MapCrudEndpoints<T>(this WebApplication app, string route)
            where T : Entity
        {
            app.MapGet($"/{route}", (AppDbContext db)
                => DatabaseProvider.GetAll<T>(db));

            app.MapGet($"/{route}/{{id}}", (AppDbContext db, int id)
                => DatabaseProvider.GetById<T>(db, id));

            app.MapPost($"/{route}", (AppDbContext db, T data)
                => DatabaseProvider.Create(db, data));

            app.MapPut($"/{route}", (AppDbContext db, T data)
                => DatabaseProvider.Update(db, data));

            app.MapDelete($"/{route}/{{id}}", (AppDbContext db, int id)
                => DatabaseProvider.Delete<T>(db, id));
        }
    }
}
