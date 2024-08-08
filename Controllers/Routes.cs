namespace EdTechAPI.Controllers
{
    public class Routes
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/public/students").MapGroupPublic().WithTags("Students");
            app.MapGroup("/private/students").MapGroupPrivate().WithTags("Students");
        }
    }
}