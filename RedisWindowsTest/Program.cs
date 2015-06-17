using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisWindowsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            string elementKey = "testKeyRedis";
            string message = string.Empty;
            using (RedisClient redisClient = new RedisClient(host))
            {
                redisClient.Password = "foobared";
                IRedisTypedClient<List<Hotel>> hotels = redisClient.As<List<Hotel>>();
               // IRedisList<Hotel> ho = redis.Lists["urn:phones:ho"];
                List<Hotel> hotel1 = hotels.GetValue("HotelList");
               List<Hotel> myHotel = new List<Hotel>();
               if (hotel1 == null)
                {
                    // make a small delay
                   // Thread.Sleep(5000);
                    // creating a new Phone entry
                    Hotel hotel = new Hotel
                    {
                        Id = 5,
                        Name = "Avasa",
                        star = 5,
                        Location="Hyderabad",
                        Room = new Room
                        {
                           
                            RoomType = "OldOne",
                            RoomSet = 2,
                            BedType = "King"
                        }
                    };

                    myHotel.Add(hotel);
                    Hotel hotel11 = new Hotel
                    {
                        Id = 5,
                        Name = "Taj",
                        star = 5,
                        Location = "Hyderabad",
                        Room = new Room
                        {

                            RoomType = "New",
                            RoomSet = 2,
                            BedType = "King"
                        }
                    };

                    myHotel.Add(hotel11);
                    // adding Entry to the typed entity set
                    hotels.SetEntry("HotelList", myHotel);
                }
                
            }
        }
    }

    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int star { get; set; }
        public string Location { get; set; }

        public Room Room { get; set; }
    }
    public class Room
    {
        public string RoomType { get; set; }
        public int RoomSet { get; set; }
        public string BedType { get; set; }
        public double  price { get; set; }

    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
    }
}
