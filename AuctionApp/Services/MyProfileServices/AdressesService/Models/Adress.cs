namespace AuctionApp.Services.MyProfileServices.AdressesService.Models
{
    public class Adress
    {
        public Guid AdressId { get; private set; } = Guid.Empty;

        public string AdressTitle { get; private set; } = string.Empty;

        public string Country { get; private set; } = string.Empty;

        public string City { get; private set; } = string.Empty;

        public string Region { get; private set; } = string.Empty;

        public string District { get; private set; } = string.Empty;

        public string Street { get; private set; } = string.Empty;

        public string Building { get; private set; } = string.Empty;

        public string Floor { get; private set; } = string.Empty;

        public string Flat { get; private set; } = string.Empty;

        public string PostIndex { get; private set; } = string.Empty;

        public bool IsForShipment { get; private set; }

        public bool IsDefaultForShipment { get; private set; }

        public bool IsForReceiving { get; private set; }

        public bool IsDefaultForReceiving { get; private set; }

        public Adress(Guid adressId, string adressTitle, string country, string city, string region, string district, string street, string building, string floor, string flat, string postIndex, bool isForShipment, bool isDefaultForShipment, bool isForReceiving, bool isDefaultForReceiving)
        {
            AdressId = adressId;
            AdressTitle = adressTitle;
            Country = country;
            City = city;
            Region = region;
            District = district;
            Street = street;
            Building = building;
            Floor = floor;
            Flat = flat;
            PostIndex = postIndex;
            IsForShipment = isForShipment;
            IsDefaultForShipment = isDefaultForShipment;
            IsForReceiving = isForReceiving;
            IsDefaultForReceiving = isDefaultForReceiving;
        }
    }
}
