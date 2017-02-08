using TaskManagerWebApi.Mappings;

namespace TaskManagerWebApi.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}