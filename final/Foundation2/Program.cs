using System;

public class Product{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity){

        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost(){

        return price * quantity;
    }

    public string GetName(){

        return name;
    }

    public int GetProductId(){

        return productId;
    }

    public double GetPrice(){

        return price;
    }

    public int GetQuantity(){

        return quantity;
    }
}

public class Address{

    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country){

        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool InUS(){

        return country.ToLower() == "usa";
    }

    public string GetAddressString(){

        return $"{street}\n{city}, {state}\n{country}";
    }
}

public class Customer{
    private string name;
    private Address address;

    public Customer(string name, Address address){

        this.name = name;
        this.address = address;
    }

    public bool InUS(){

        return address.InUS();
    }

    public string GetName(){

        return name;
    }

    public Address GetAddress(){

        return address;
    }
}

public class Order{

    private Customer customer;
    private List<Product> products;

    public Order(Customer customer){

        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product){

        products.Add(product);
    }

    public double TotalCost(){

        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        double shippingCost = customer.InUS() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel(){

        string packingLabel = "";
        foreach (var product in products){

            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel(){

        return $"{customer.GetName()}\n{customer.GetAddress().GetAddressString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {

        Product product1 = new Product("Laptop", 1, 9845, 2);
        Product product2 = new Product("Gimbal", 2, 79, 1);

        Address address1 = new Address("4000 S 4563 W", "Wonton", "CO", "USA");
        Address address2 = new Address("23 Tumpor", "Higgsville", "AL", "Canada");

        Customer customer1 = new Customer("Grand Wizard", address1);
        Customer customer2 = new Customer("Farn Swikh", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("\nOrder 1 Total Price:");
        Console.WriteLine("$" + order1.TotalCost());

        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("\nOrder 2 Total Price:");
        Console.WriteLine("$" + order2.TotalCost());
    }
}