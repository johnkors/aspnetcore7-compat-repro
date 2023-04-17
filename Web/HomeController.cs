using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Web;

[ApiController]
[Route("/")]
public class HomeController
{

    [HttpPost("/someclass")]
    public string PostSomeClass([FromBody] SomeClass<SomeSubType> model)
    {
        var stringObj = JsonSerializer.Serialize(model);
        return $"SomeClass: {stringObj}";
    }
    
    [HttpPost("/someotherclass")]
    public string PostSomeOtherClass([FromBody] SomOtherClassWithAnExtraProp<SomeSubType> model)
    {
        var stringObj = JsonSerializer.Serialize(model);
        return $"SomeOtherClass: {stringObj}";
    }
}

public class SomeClass<T>
{
    public T? Thing {get;set;}
    
    public string MightBeRequiredDependingOnNullabilityProp { get; set; }
}

public class SomOtherClassWithAnExtraProp<T>
{
    public T? Thing {get;set;}
    
    public string MightBeRequiredDependingOnNullabilityProp { get; set; }

    public string SomeRandomOtherProp { get; set; }
}

public class SomeSubType
{
    public string Name { get; set; }
}
