namespace PropertyAPI;

public class Properties
{
    public List<Property> ListedProperties { get; set; }
}

public class Property
{
    public string StreetName { get; set; }
    public string CityStateName { get; set; }
    public int MaxBid { get; set;  }
    public string MaxBidder { get; set; }
    public int LastBid { get; set;  }
    public string LastBidder { get; set;  }
}

