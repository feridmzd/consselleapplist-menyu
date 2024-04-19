namespace ConsoleApp33
{
    using System;
    using System.Collections.Generic;

    
   

   

    class Program
    {
        static List<Hotel> hotels = new List<Hotel>();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n******Menu******");
                Console.WriteLine("1.Sisteme giris");
                Console.WriteLine("0.Cixis");
                Console.Write("Seciminizi edin: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            SistemeGiris();
                            break;
                        case 0:
                            Console.WriteLine("Sistemden cixildi.");
                            break;
                        default:
                            Console.WriteLine("Duzgun secim edilmeyib.");
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Secim edilmeyib. Zehmet olmasa yeniden secim edin.");
                }
            } while (choice != 0);
        }

        static void SistemeGiris()
        {
            int choice;
            do
            {
                Console.WriteLine("\nSisteme giris");
                Console.WriteLine("1.Hotel yarat");
                Console.WriteLine("2.Butun Hotelleri gor");
                Console.WriteLine("3.Hotel sec");
                Console.WriteLine("0.Exit");
                Console.Write("Seciminizi edin: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            HotelYarat();
                            break;
                        case 2:
                            ButunHotelleriGor();
                            break;
                        case 3:
                            HotelSec();
                            break;
                        case 0:
                            Console.WriteLine("Menuya qayidilir...");
                            break;
                        default:
                            Console.WriteLine("Duzgun secim edilmeyib.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Secim edilmeyib. Zehmet olmasa yeniden secim edin.");
                }
            } while (choice != 0);
        }

        static void HotelYarat()
        {
            Console.Write("Hotel adini daxil edin: ");
            string name = Console.ReadLine();

            if (hotels.Exists(h => h.Name == name))
            {
                Console.WriteLine("Bu adda hotel artiq movcuddur.");
            }
            else
            {
                try
                {
                    Hotel hotel = new Hotel(name);
                    hotels.Add(hotel);
                    Console.WriteLine($"{name} adli hotel yaradildi.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Xeta bas verdi: {ex.Message}");
                }
            }
        }

        static void ButunHotelleriGor()
        {
            Console.WriteLine("\nButun Hoteller:");
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"Hotel ID: {hotel.Id}, Name: {hotel.Name}");
            }
        }

        static void HotelSec()
        {
            Console.Write("Hotel adini daxil edin: ");
            string name = Console.ReadLine();

            Hotel selectedHotel = hotels.Find(h => h.Name == name);

            if (selectedHotel == null)
            {
                Console.WriteLine("Daxil edilen ada uygun hotel tapilmadi.");
            }
            else
            {
                HotelMenu(selectedHotel);
            }
        }

        static void HotelMenu(Hotel hotel)
        {
            int choice;
            do
            {
                Console.WriteLine("\n******Menu******");
                Console.WriteLine("1.Room yarat");
                Console.WriteLine("2.Roomlari gor");
                Console.WriteLine("3.Rezervasya et");
                Console.WriteLine("4.Evvelki menuya qayit.");
                Console.WriteLine("0.Exit");
                Console.Write("Seciminizi edin: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RoomYarat(hotel);
                            break;
                        case 2:
                            RoomlariGor(hotel);
                            break;
                        case 3:
                            RezervasyaEt(hotel);
                            break;
                        case 4:
                            Console.WriteLine("Menuya qayidilir...");
                            break;
                        case 0:
                            Console.WriteLine("Menuya qayidilir...");
                            break;
                        default:
                            Console.WriteLine("Duzgun secim edilmeyib.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Secim edilmeyib. Zehmet olmasa yeniden secim edin.");
                }
            } while (choice != 4 && choice != 0);
        }

        static void RoomYarat(Hotel hotel)
        {
            Console.Write("Otaq adini daxil edin: ");
            string name = Console.ReadLine();
            Console.Write("Otaq qiymetini daxil edin: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Duzgun qiymet daxil edin:");
            }
            Console.Write("Otaq nəfərlik kapasitesini daxil edin: ");
            int capacity;
            while (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine("Duzgun nəfərlik kapasitesini daxil edin:");
            }

            try
            {
                Room room = new Room(name, price, capacity);
                hotel.AddRoom(room);
                Console.WriteLine($"'{name}' adli otaq yaradildi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
        }

        static void RoomlariGor(Hotel hotel)
        {
            Console.WriteLine("\nHoteldeki Otaqlar:");
            foreach (var room in hotel.GetAllRooms())
            {
                Console.WriteLine(room);
            }
        }

        static void RezervasyaEt(Hotel hotel)
        {
            if (hotel.GetAllRooms().Count == 0)
            {
                Console.WriteLine("Hotelde hec bir otaq yoxdur. Rezervasya emeliyyati edile bilmez.");
                return;
            }

            Console.Write("Rezervasya etmek istediyiniz otaqin ID-sini daxil edin: ");
            int roomId;
            while (!int.TryParse(Console.ReadLine(), out roomId))
            {
                Console.WriteLine("Duzgun otaq ID-si daxil edin:");
            }

            Console.Write("Neçə nəfərlik rezervasiya etmek istəyirsiniz? ");
            int numberOfGuests;
            while (!int.TryParse(Console.ReadLine(), out numberOfGuests))
            {
                Console.WriteLine("Duzgun say daxil edin:");
            }

            try
            {
                hotel.MakeReservation(roomId, numberOfGuests);
                Console.WriteLine("Rezervasiya ugurla edildi.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
            catch (NotAvailableException ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
        }
    }

}
