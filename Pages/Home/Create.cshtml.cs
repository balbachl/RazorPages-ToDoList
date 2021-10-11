using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages.Home
{
    public class CreateModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public CreateModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoList ToDoList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoList.Add(ToDoList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
