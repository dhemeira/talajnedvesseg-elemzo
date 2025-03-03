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
        return MatrixSzorzas(talajnedvesseg.MatrixB, talajnedvesseg.NormalizaltC);
    }

    private List<List<double>> MatrixSzorzas(List<List<double>> a, List<List<double>> b)
    {
        List<List<double>> result = new List<List<double>>(a.Count);

        for (int i = 0; i < a.Count; i++)
        {
            result.Add(new List<double>(a[0].Count));
            for (int j = 0; j < a[0].Count; j++)
            {
                result[i].Add(a[i][j] * b[i][j]);
            }
        }

        return result;
    }
}
