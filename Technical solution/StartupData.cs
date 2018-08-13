using System.Linq;
using Technical_solution.Models;

namespace Technical_solution
{
    public static class StartupData
    {
        public static void Initialize(SentencesContext context)
        {
            if (!context.sentenсes.Any())
            {

                context.SaveChanges();
            }
        }
    }
}
