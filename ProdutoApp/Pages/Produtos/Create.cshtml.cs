using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProdutoApp.Models;

namespace ProdutoApp.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Produto Produto { get; set; }

#pragma warning disable CS8618 
        public CreateModel(AppDbContext context)
#pragma warning restore CS8618 
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Produtos/Index");
        }
    }
}
