using Backend.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um atuador
    /// </summary>
    public class StateListExamples : IMultipleExamplesProvider<List<StateHardware>>
    {
        /// <summary>
        /// Exemplos de Estados de um Hardware
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<StateHardware>>> GetExamples()
        {
            yield return SwaggerExample.Create(
            "List1", new List<StateHardware> {
            new StateHardware()
            {
                Id = 1,
                Name = "Ocupado"
            },
            new StateHardware()
             {
                 Id = 2,
                 Name = "Livre"
             },
            new StateHardware()
               {
                   Id = 3,
                   Name = "Ligado"
               },
            new StateHardware()
              {
                  Id = 4,
                  Name = "Desligado"
              },
            new StateHardware()
             {
                 Id = 5,
                 Name = "Quente"
             },
            new StateHardware()
                {
                    Id = 6,
                    Name = "Frio"
                }
            });
        }
    }
}
