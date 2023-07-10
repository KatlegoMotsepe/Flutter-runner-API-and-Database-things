using Flutter_runnner.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Flutter_runnner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Entries_controller : Controller
    {

        private DataContext _dataContext;
        private readonly IConfiguration configeration;

        public Entries_controller(IConfiguration config, DataContext dataContext)
        {

            configeration = config;
            _dataContext = dataContext;
        }

        [HttpGet("getHistory")]
        public async Task<ActionResult<History_page_DOTs>> History(History_page_DOTs inputUser)
        {
            using var db = new DataContext();

            //var dbEntries = await db.Entries.SingleOrDefaultAsync(x => x.entry_id == id);

            List<double> ks = new List<double>();

            ks.Add(inputUser.points);

            return Ok("");
        }



        [HttpGet("getSpecificHistory/{id}")]

        public async Task<IActionResult> ViewSpecificHistoy(int id, Selected_history_DTOs selected_History)
        {
            try
            {
                var entries = await _dataContext.Entries.ToListAsync();

                if (selected_History == null)
                {
                    return NotFound();

                }
                return Ok(selected_History);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }
        }
    }
}
