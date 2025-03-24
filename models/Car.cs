using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;


namespace RentCar.models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }

        [NotMapped]
        public IFormFile Image1 { get; set; }
        [NotMapped]
        public IFormFile Image2 { get; set; }
        [NotMapped]
        public IFormFile Image3 { get; set; }

        public float Price { get; set; }
        public int Multiplier { get; set; }
        public int Capacity { get; set; }
        public string Transmission { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }

        public int FuelCapacity { get; set; }
        public string City { get; set; }

        [ForeignKey("OwnerPhoneNumber")]
        [JsonIgnore]
        public User Owner { get; set; }

        public string OwnerPhoneNumber { get; set; }

        [JsonIgnore]
        public List<UserFavoriteCar> FavoritedByUsers { get; set; }

        [JsonIgnore]
        public List<Purchase> Purchases { get; set; }
    }
}
