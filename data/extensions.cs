using ContosoPizza.Data;

namespace contosopizza.Data;

public class Extentions
{
    public static void CreateDbIfNotExist(IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PizzaContext>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }
        }
    }
}