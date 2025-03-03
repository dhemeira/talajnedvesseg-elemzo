using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TalajnedvessegController : ControllerBase
{
    [HttpPost(Name = "Talajnedvesség")]
    public List<List<double>> Post([FromBody] Talajnedvesseg talajnedvesseg)
    {
        List<List<double>> BszerCnorm = MatrixMuvelet(talajnedvesseg.MatrixB, talajnedvesseg.NormalizaltC, (x, y) => x * y);
        return MatrixMuvelet(BszerCnorm, talajnedvesseg.MatrixAErtekek, (x, y) => x / y);
    }

    private static List<List<double>> MatrixMuvelet(List<List<double>> a, List<List<double>> b, Func<double,double,double> muvelet)
    {
        List<List<double>> result = new List<List<double>>(a.Count);

        for (int i = 0; i < a.Count; i++)
        {
            result.Add(new List<double>(a[0].Count));
            for (int j = 0; j < a[0].Count; j++)
            {
                double eredmeny = muvelet(a[i][j], b[i][j]);
                if (!double.IsNaN(eredmeny) && !double.IsInfinity(eredmeny))
                    result[i].Add(eredmeny);
                else 
                    result[i].Add(0);
            }
        }

        return result;
    }
}
