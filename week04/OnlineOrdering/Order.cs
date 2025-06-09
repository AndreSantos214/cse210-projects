using System;
using System.Collections.Generic;

public class Order
{
  private List<Product> _products;
  private Customer _customer;

  public Order(Customer customer)
  {
    _customer = customer;
    _products = new List<Product>();
  }

  public List<Product> GetProducts()
  {
    return _products;
  }

  public Customer GetCustomer()
  {
    return _customer;
  }

  public void SetCustomer(Customer customer)
  {
    _customer = customer;
  }

  public void AddProduct(Product product)
  {
    _products.Add(product);
  }

  public double CalculateTotalCost()
  {
    double totalProductCost = 0;
    foreach (Product product in _products)
    {
      totalProductCost += product.GetTotalCost();
    }

    double shipingCost;
    if (_customer.LivesInUsa())
    {
      shipingCost = 5.0;
    }
    else
    {
      shipingCost = 35.0;
    }

    return totalProductCost + shipingCost;
  }

  public string GetPackingLabel()
  {
    string packingLabel = "PACKING LABEL: \n=====================\n";
    foreach (Product product in _products)
    {
      packingLabel += $"Product: {product.GetName()} (ID: '{product.GetProductId()}') - ${product.GetPrice()} X {product.GetQuantity()}\n";
    }
    return packingLabel;
  }

  public string GetShippingLabel()
  {
    return $"SHIPPING LABEL:\n=======================\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}\n";
  }
}