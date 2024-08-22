namespace AuctionApp.Pages.MyProfilePage.Models
{
    public class AddressModel
    {
        public string AddressTitle { get; private set; }

        public string Country { get; private set; }

        public string City { get; private set; }

        public string Region { get; private set; }

        public string District { get; private set; }

        public string Street { get; private set; }

        public string Building { get; private set; }

        public string Floor { get; private set; }

        public string Flat { get; private set; }

        public string PostIndex { get; private set; }

        public bool IsForShipment { get; private set; } = false;

        public bool IsDefaultForShipment { get; private set; } = false;

        public bool IsForReceiving { get; private set; } = false;

        public bool IsDefaultForReceiving { get; private set; } = false;

        public AddressModel(string addressTitle,
            string country,
            string city,
            string region,
            string district,
            string street,
            string building,
            string floor,
            string flat,
            string postIndex,
            bool isForShipment,
            bool isDefaultForShipment,
            bool isForReceiving,
            bool isDefaultForReceiving)
        {
            AddressTitle = addressTitle;
            Country = country;
            City = city;
            Region = region;
            District = district;
            Building = building;
            Street = street;
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
