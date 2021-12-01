using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_REST.Data;
using API_REST.Model;


namespace API_REST.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public LinqController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("/api/linqsoma")]
        public dynamic SomaTotal()
        {
            var soma = from x in _context.Compra
                       group x by x.ClientId
                       into g
                       select new
                       {
                          Soma = g.Sum(x => x.Total)
                       };

            return soma;
        }

        [HttpGet, Route("/api/linqsoma/{ClientId}")]
        public dynamic GetSomaById(int ClientId)
        {

            var soma = from x in _context.Compra
                       where x.ClientId == ClientId
                       group x by x.ClientId
                       into g
                       select new
                       {
                         Soma = g.Sum(x => x.Total)
                       };

            return soma;
        }

        [HttpGet, Route("/api/linqavg")]
        public dynamic Avg()
        {
            var avg = from x in _context.Compra
                      group x by x.ClientId
                      into g
                      select new
                      {
                          Avg = g.Average(x => x.Total)
                };
            return avg;
        }

        [HttpGet, Route("/api/linqmax")]
        public dynamic max()
        {
            var max = from x in _context.Compra
                      group x by x.ClientId
                      into g
                      select new
                      {
                          max = g.Max(x => x.Total)
                      };
            return max;
        }
    }
}
