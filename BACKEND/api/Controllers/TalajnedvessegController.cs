using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TalajnedvessegController : ControllerBase
{
    [HttpPost(Name = "Talajnedvesség")]
    public double[] Post([FromBody] Talajnedvesseg talajnedvesseg)
    {
        return new double[2] { 3, 2 };
    }
}
