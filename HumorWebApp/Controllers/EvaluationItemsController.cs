using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumorWebApp.Data;
using HumorWebApp.Models;

namespace HumorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EvaluationItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EvaluationApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluationItem>>> GetEvaluationItem()
        {
            return await _context.EvaluationItem.ToListAsync();
        }

        // GET: api/EvaluationApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationItem>> GetEvaluationItem(int id)
        {
            var evaluationItem = await _context.EvaluationItem.FindAsync(id);

            if (evaluationItem == null)
            {
                return NotFound();
            }

            return evaluationItem;
        }
    }
}
