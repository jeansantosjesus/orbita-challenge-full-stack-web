using EdTechAPI.Model;
using EdTechAPI.Structure;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace EdTechAPI.Controllers
{
    public static class RouteExtension
    {
        public static RouteGroupBuilder MapGroupPublic(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (ConnectionContext db) =>
            {
                var students = db.Students.ToList();
                return Results.Ok(students);
            });

            group.MapGet("/{ra:int}", async (int ra, ConnectionContext db) =>
            {
                var student = db.Students.Find(ra);
                return Results.Ok(student);
            });

            group.MapGet("/{name}", async (string name, ConnectionContext db) =>
            {
                var students = db.Students.Where(x => x.name.Contains(name));
                return Results.Ok(students);
            });

            return group;
        }

        public static RouteGroupBuilder MapGroupPrivate(this RouteGroupBuilder group) 
        {
            group.MapPost("/students", async (List<Student> students, IValidator<Student> validator, ConnectionContext db) =>
            {
                foreach (var student in students)
                {
                    var validation = await validator.ValidateAsync(student);
                    if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());
                    db.Students.Add(student);
                    await db.SaveChangesAsync();

                }

                    return Results.Ok(students);
            });

            group.MapPost("/students/{name}", async (List<Student> students, IValidator<Student> validator, ConnectionContext db) =>
            {
                foreach (var student in students)
                {
                    var validation = await validator.ValidateAsync(student);
                    if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());                    
                }

                var watchRange = System.Diagnostics.Stopwatch.StartNew();
                db.AddRange(students);
                db.SaveChanges();
                watchRange.Stop();

                var elapsedRangeMls = watchRange.ElapsedMilliseconds;
                Console.Write($"\n AddRange: {elapsedRangeMls} \n");


                var watchBulk = System.Diagnostics.Stopwatch.StartNew();
                db.BulkInsert(students);
                watchBulk.Stop();

                var elapsedBulkMls = watchBulk.ElapsedMilliseconds;
                Console.WriteLine($"\n BulkInsert: {elapsedRangeMls} \n");

                return Results.Ok();
            });

            group.MapDelete("/{ra:int}", async (int ra, ConnectionContext db) =>
            {
                var student = db.Students.Find(ra);
                db.Remove(student);
                db.SaveChanges();
                return Results.Ok(true);
            });

            return group;
        }
    }
}
