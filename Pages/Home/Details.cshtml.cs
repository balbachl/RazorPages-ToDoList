using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages.Home
{
    public class DetailsModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public DetailsModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        public ToDoList ToDoList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoList = await _context.ToDoList.FirstOrDefaultAsync(m => m.ID == id);

            if (ToDoList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
