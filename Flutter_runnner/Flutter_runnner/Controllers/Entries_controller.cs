using Flutter_runnner.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> History(History_page_DOTs history_Page)
        {

            try
            {
                var entries =  _dataContext.Entries.ToListAsync();
                if (entries == null)
                {
                    return StatusCode(404, "No entries found");
                }
                return Ok(entries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
