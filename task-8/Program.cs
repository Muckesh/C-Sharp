using System;
using System.Collections.Generic;
using System.Linq;

interface IEntity {
    int Id { get; set; }
}

interface IRepository<T> where T : class, IEntity {
    void Add(T item);
    T Get(int id);
    void Update(int id, T item);
    void Delete(int id);
    List<T> GetAll();
}

class InMemoryRepository<T> : IRepository<T> where T : class, IEntity {
    private Dictionary<int, T> _items = new();
    private int _nextId = 1;

    public void Add(T item) {
        item.Id = _nextId++;
        _items[item.Id] = item;
    }

    public T Get(int id) => _items.ContainsKey(id) ? _items[id] : null;

    public void Update(int id, T item) {
        if (_items.ContainsKey(id)) {
            item.Id = id;
            _items[id] = item;
        }
    }

    public void Delete(int id) => _items.Remove(id);

    public List<T> GetAll() => _items.Values.ToList();
}

class Product : IEntity {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Program {
    static void Main() {
        IRepository<Product> productRepo = new InMemoryRepository<Product>();

        // Add products
        productRepo.Add(new Product { Name = "Laptop", Price = 1200 });
        productRepo.Add(new Product { Name = "Mouse", Price = 20 });

        Console.WriteLine("All Products:");
        foreach (var product in productRepo.GetAll()) {
            Console.WriteLine($"{product.Id}: {product.Name} - ${product.Price}");
        }

        // Update product
        productRepo.Update(2, new Product { Name = "Wireless Mouse", Price = 25 });

        // Delete product
        productRepo.Delete(1);

        Console.WriteLine("\nAfter update & delete:");
        foreach (var product in productRepo.GetAll()) {
            Console.WriteLine($"{product.Id}: {product.Name} - ${product.Price}");
        }
    }
}
