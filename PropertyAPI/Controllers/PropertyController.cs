using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PropertyAPI.Controllers;

[ApiController]
[Route("api/")]
public class PropertyController : ControllerBase
{
    private readonly ILogger<PropertyController> _logger;

    public PropertyController(ILogger<PropertyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("getproperties", Name = "GetProperties")]
    public List<Property> GetProperties()
    {
        List<Property> properties = new List<Property>();
        using (StreamReader file = System.IO.File.OpenText(@"Properties/properties.json"))
        {
            JsonSerializer serializer = new JsonSerializer();

            dynamic listedProperties = serializer.Deserialize(file, typeof(object));

            foreach (var property in listedProperties.properties)
            {
                Property propertyToAdd = new Property {
                    StreetName = property.streetName,
                    CityStateName = property.cityStateName,
                    MaxBid = property.maxBid,
                    MaxBidder = property.maxBidder,
                    LastBid = property.lastBid,
                    LastBidder = property.lastBidder
                };
                properties.Add(propertyToAdd);
            }
        }

        return properties;
    }

    [HttpGet("getbids", Name = "GetBids")]
    public Bid GetBids()
    {
        Bid bids = new();
        using (StreamReader file = System.IO.File.OpenText(@"Properties/bids.json"))
        {
            JsonSerializer serializer = new JsonSerializer();

            dynamic bidData = serializer.Deserialize(file, typeof(object));
            bids.WinningBids = bidData.winningBids;
            bids.LosingBids = bidData.losingBids;
            bids.ActiveBids = bidData.activeBids;
        }
        return bids;
    }

    [HttpGet("getbidvalue", Name = "GetBidValues")]
    public BidValue GetBidValues()
    {
        BidValue bidValues = new();
        using (StreamReader file = System.IO.File.OpenText(@"Properties/bids.json"))
        {
            JsonSerializer serializer = new JsonSerializer();

            dynamic bidData = serializer.Deserialize(file, typeof(object));
            bidValues.WinningBidValue = bidData.winningBidValue;
            bidValues.LosingBidValue = bidData.losingBidValue;
            bidValues.ActiveBidValue = bidData.activeBidValue;
        }
        return bidValues;
    }
}

