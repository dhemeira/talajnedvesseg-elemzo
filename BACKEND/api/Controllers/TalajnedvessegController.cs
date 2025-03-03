using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TalajnedvessegController : ControllerBase
{
    [HttpPost(Name = "Talajnedvesség")]
    public List<List<double>> Post([FromBody] Talajnedvesseg talajnedvesseg)
    {
        return talajnedvesseg.NormalizaltC;
    }
}
