public class Order 
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal sum = 0;
        foreach(Product product in _products)
        {
            sum += product.GetTotalCost();
        }
        decimal shippingCost = (_customer.isCustomerLivingInUSA()) ? (sum + 5) : (sum + 35);
        return sum + shippingCost;
        

    }

    public string packagingLabel()
    {
        string label = "Packaging Label:\n";
        
        foreach(Product product in _products)
        {
            label += $"\t({product.GetProductName()}) (ID: {product.GetProductID()})\n";
        }
        return label;
    } 

    public string shippingLabel()
    {
        string label = $"Shipping Label for {_customer.GetCustomerName()}:\n";
        label += $"\t{_customer.GetCustomerAddress().GetAddressDetails()}";
        return label;
    }  
}