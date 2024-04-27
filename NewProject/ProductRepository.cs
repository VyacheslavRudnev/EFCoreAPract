using Microsoft.EntityFrameworkCore;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject;

public class ProductRepository : IRepository<Product>
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    

    public async Task AddAsync(Product item)
    {
        _dataContext.Product.Add(item);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IQueryable<Product>> GetAllAsync(CancellationToken token)
    {
        return (await _dataContext.Product
            .Include(p=>p.ProductInfo)
            .ToListAsync(token))
            .AsQueryable();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        Product product = await _dataContext.Product.FindAsync(id) ??
            throw new NullReferenceException();

        return product;
    }


}
