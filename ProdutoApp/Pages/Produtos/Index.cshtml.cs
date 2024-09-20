using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProdutoApp.Models;

namespace ProdutoApp.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Produto> Produtos { get; set; }

#pragma warning disable CS8618 
        public IndexModel(AppDbContext context)
#pragma warning restore CS8618 
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produtos.ToListAsync();
        }
    }
}
