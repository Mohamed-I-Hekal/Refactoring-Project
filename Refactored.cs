publc class OrderManager // Class that manages the order made
{
    const int LARGE_ORDER_SIZE = 100; // Used for large orders
    const int SMALL_ORDER_SIZE = 10; // Used for small orders

    readonly IOrderStore orderStore;

    public OrderManager(IOrderStore orderStore)  // This is good for testing
    {
      orderStore = orderStore;
    }

    public void GetAndWriteOrders(bool largeOrders) // Function tht gets and writes the orders
    {
        int orderSize = largeOrders ? LARGE_ORDER_SIZE : SMALL_ORDER_SIZE; // Check the size of the order

        var orders = orderStore.GetOrders();
        var writer = new OrderWriter();

        writer.WriteOrders(orders.Where(o => o.Size <= orderSize)
                             .OrderBy(o => o.Size));
    }
}


public class Order // A class for order
{
    public double Price { get; set; }
    public int Size { get; set; }
    public string Symbol { get; set; }
}



// These are stub interfaces that already exist in the system
// They're out of scope of the code review
public interface IOrderWriter
{
    void WriteOrders(IEnumerable<Order> orders);
}

public class OrderWriter : IOrderWriter
{
    public void WriteOrders(IEnumerable<Order> orders)
    {
    }
}

public interface IOrderStore
{
    List<Order> GetOrders();
}

public class OrderStore : IOrderStore
{
    public List<Order> GetOrders()
    {
        return new List<Order> { new Order {
            Price = 10,
            Size =1,
            Symbol = "TShirt"
        }, new Order {
            Price = 15,
            Size =2,
            Symbol = "Sport Goods"
        } 
        };
    }
}