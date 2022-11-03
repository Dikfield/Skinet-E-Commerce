using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {

    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await BrandsHandler(context);
                await TypesHandler(context);
                await ProductsHandler(context);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }

        private static async Task BrandsHandler(StoreContext context)
        {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }            
        }

                private static async Task TypesHandler(StoreContext context)
        {
                if(!context.ProductTypes.Any())
                {
                    var typesData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }            
        }

                private static async Task ProductsHandler(StoreContext context)
        {
                if(!context.Products.Any())
                {
                    var productsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }            
        }
    }
}