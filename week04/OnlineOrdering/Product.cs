public class Product 
{
    private string _name;
    private int _productID;
    private decimal _pricePerUnit;
    private int _quantity;

    public Product(string name, int productID, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productID = productID;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string GetProductName()
    {
        return _name;
    }
    public int GetProductID()
    {
        return _productID;
    }

    public decimal GetTotalCost()
    {
        return (decimal) _pricePerUnit * _quantity;
    }
}