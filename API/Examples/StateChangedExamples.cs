using Backend.Model.Request;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

public class StateChangedExamples : IMultipleExamplesProvider<StateChanger>
{
    public IEnumerable<SwaggerExample<StateChanger>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "Ligar",
            new StateChanger()
            {
                IdState = 5,
                IdHardware = 21
            });
        
        yield return SwaggerExample.Create(
            "Desligar",
            new StateChanger()
            {
                IdState = 6,
                IdHardware = 21
            });
    }
}