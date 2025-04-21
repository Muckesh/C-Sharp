using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

public interface IEntity {
    int Id {get; set;}
}


public interface IRepository<T> where T : class, IEntity {
    // Create

    void Add(T entity);

    // Read

    T GetById(int id);
    IEnumerable<T> GetAll();

    // Update
    void Update(T entity);

    // Delete
    void Delete(int id);
    void Delete(T entity);

    // Additional methods
    IEnumerable<T> Find(Func<T,bool> predicate);
    bool Exists(int id);
}

public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity {
    private readonly Dictionary<int, T> _entities = new Dictionary<int, T>();

    private int _nextId = 1;

    public void Add(T entity){
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        entity.Id = _nextId++;
        _entities.Add(entity.Id,entity);
    }

    public T GetById(int id){
        _entities.TryGetValue(id, out var entity);
        return entity;
    }

    public IEnumerable<T> GetAll(){
        return _entities.Values;
    }

    public void Update(T entity){
        if (entity==null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        if (!_entities.ContainsKey(entity.Id))
        {
            throw new KeyNotFoundException($"Entity with ID {entity.Id} not found.");
        }
        _entities[entity.Id] = entity;
    }

    public void Delete(int id){
        if (!_entities.Remove(id))
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
    }

    public void Delete(T entity){
        if (entity==null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        Delete(entity.Id);
    }

    public IEnumerable<T> Find(Func<T,bool> predicate){
        return _entities.Values.Where(predicate);
    }

    public bool Exists(int id){
        return _entities.ContainsKey(id);
    }
}

// Entity Class

public class Product : IEntity {
    public int Id {get;set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public string Category {get; set;}

    public override string ToString()
    {
        return $"ID : {Id}, Name : {Name}, Price : {Price:C}, Category : {Category}.";
    }
}

class Program {
    private static IRepository<Product> _productRepo = new InMemoryRepository<Product>();

    static void Main(string[] args){
        SeedSampleData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("PRODUCT REPOSITORY SYSTEM");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Product");
            Console.WriteLine("3. List All Products");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. Search Products");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": AddProduct(); break;
                case "2": ViewProduct(); break;
                case "3": ListProducts(); break;
                case "4": UpdateProduct(); break;
                case "5": DeleteProduct(); break;
                case "6": SearchProducts(); break;
                case "7": return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        }
    }

    private static void SeedSampleData()
    {
        _productRepo.Add(new Product {Name = "Laptop", Price = 999.99m, Category = "Electronics"});
        _productRepo.Add(new Product { Name = "Desk Chair", Price = 149.99m, Category = "Furniture" });
    }

    private static void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("Add New Product : ");
        var product = new Product();
        Console.Write("Name : ");
        product.Name = Console.ReadLine();

        Console.Write("Price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
            product.Price = price;
        else
        {
            Console.WriteLine("Invalid price format.");
            return;
        }
        
        Console.Write("Category: ");
        product.Category = Console.ReadLine();

        _productRepo.Add(product);
        Console.WriteLine("Product added successfully!");
        Console.ReadKey();
    }

    private static void ViewProduct()
    {
        Console.Clear();
        Console.WriteLine("VIEW PRODUCT");
        Console.Write("Enter Product ID: ");
        
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = _productRepo.GetById(id);
            if (product != null)
            {
                Console.WriteLine("\nPRODUCT DETAILS:");
                Console.WriteLine(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void ListProducts()
    {
        Console.Clear();
        Console.WriteLine("ALL PRODUCTS\n");
        
        var products = _productRepo.GetAll();
        if (products.Any())
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        else
        {
            Console.WriteLine("No products available.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void UpdateProduct()
    {
        Console.Clear();
        Console.WriteLine("UPDATE PRODUCT");
        Console.Write("Enter Product ID to update: ");
        
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = _productRepo.GetById(id);
            if (product != null)
            {
                Console.WriteLine("\nCurrent Details:");
                Console.WriteLine(product);
                Console.WriteLine("\nEnter new details:");
                
                Console.Write("Name: ");
                var name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    product.Name = name;
                
                Console.Write("Price: ");
                var priceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
                    product.Price = price;
                
                Console.Write("Category: ");
                var category = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(category))
                    product.Category = category;
                
                _productRepo.Update(product);
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void DeleteProduct()
    {
        Console.Clear();
        Console.WriteLine("DELETE PRODUCT");
        Console.Write("Enter Product ID to delete: ");
        
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            try
            {
                _productRepo.Delete(id);
                Console.WriteLine("Product deleted successfully!");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void SearchProducts()
    {
        Console.Clear();
        Console.WriteLine("SEARCH PRODUCTS");
        Console.WriteLine("1. By Name");
        Console.WriteLine("2. By Category");
        Console.WriteLine("3. By Price Range");
        Console.Write("Select search option: ");
        
        var option = Console.ReadLine();
        IEnumerable<Product> results = null;
        
        switch (option)
        {
            case "1":
                Console.Write("Enter product name: ");
                var name = Console.ReadLine();
                results = _productRepo.Find(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
                break;
                
            case "2":
                Console.Write("Enter category: ");
                var category = Console.ReadLine();
                results = _productRepo.Find(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
                break;
                
            case "3":
                Console.Write("Enter minimum price: ");
                decimal minPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Enter maximum price: ");
                decimal maxPrice = decimal.Parse(Console.ReadLine());
                results = _productRepo.Find(p => p.Price >= minPrice && p.Price <= maxPrice);
                break;
                
            default:
                Console.WriteLine("Invalid option.");
                return;
        }
        
        Console.WriteLine("\nSEARCH RESULTS:");
        if (results != null && results.Any())
        {
            foreach (var product in results)
            {
                Console.WriteLine(product);
            }
        }
        else
        {
            Console.WriteLine("No products found.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}