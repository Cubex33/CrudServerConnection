using CurlConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace CurlConnection
{
    public static class DatabaseProvider
    {
        public static async Task<IResult> GetAll<T>(AppDbContext context) where T : Entity
        {
            var responce = await context.Set<T>().ToListAsync();
            if (responce == null) return Results.NotFound();
            return Results.Ok(responce);
        }

        public static async Task<IResult> GetById<T>(AppDbContext context, int id) where T : Entity
        {
            var responce = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            if (responce == null) return Results.NotFound();
            return Results.Ok(responce);
        }

        public static async Task<IResult> Create<T>(AppDbContext context, T data) where T : Entity
        {
            var responce = context.Set<T>().Add(data);
            await context.SaveChangesAsync();
            if (responce == null) return Results.NotFound();
            return Results.Ok(responce);
        }

        public static async Task<IResult> Update<T>(AppDbContext context, T data) where T : Entity
        {
            var response = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == data.Id);

            if (response == null) return Results.NotFound();
            context.Entry(response).CurrentValues.SetValues(data);
            await context.SaveChangesAsync();
            return Results.Ok(response);
        }

        public static async Task<IResult> Delete<T>(AppDbContext context, int id) where T : Entity
        {
            var responce = await context.Set<T>().Where(t => t.Id == id).ExecuteDeleteAsync();
            if (responce == 0) return Results.NotFound();
            return Results.Ok(responce);
        }
    }
}
