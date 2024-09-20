using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProdutoApp.Models;

namespace ProdutoApp.Pages.Produtos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Produto Produto { get; set; }

#pragma warning disable CS8618 
        public DeleteModel(AppDbContext context)
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
            var produto = await _context.Produtos.FindAsync(Produto.Id);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Produtos/Index");
        }
    }
}
