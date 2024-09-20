using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProdutoApp.Models;

namespace ProdutoApp.Pages.Produtos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Produto Produto { get; set; }

#pragma warning disable CS8618 
        public EditModel(AppDbContext context)
#pragma warning restore CS8618 
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
#pragma warning disable CS8601 
            Produto = await _context.Produtos.FindAsync(id);
#pragma warning restore CS8601 

            if (Produto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produtos.Update(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Produtos/Index");
        }
    }
}
