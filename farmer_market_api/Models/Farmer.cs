using System;

namespace farmer_market_api.Models
{
    public class Farmer
    {
        private static int idCounter = 1;

        public int FarmerId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public double Rating { get; set; } = 0.0;
        public bool IsAvailable { get; set; }

        public Farmer(int ID, string name, string email, string phone, string address, string province, double rating, bool isAvailable)
        {
            FarmerId = ID;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Province = province;
            Rating = rating;
            IsAvailable = isAvailable;
        }

        // Needed for API model binding
        public Farmer() { }
    }
}