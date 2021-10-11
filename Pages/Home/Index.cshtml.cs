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
    public class IndexModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public IndexModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        public IList<ToDoList> ToDoList { get;set; }

        public async Task OnGetAsync()
        {
            ToDoList = await _context.ToDoList.ToListAsync();
        }
    }
}
