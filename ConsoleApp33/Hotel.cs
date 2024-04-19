using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
  
        public class Hotel
        {
            private static int nextId = 1;

            public int Id { get; }
            public string Name { get; }
            private List<Room> rooms;

            public Hotel(string name)
            {
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Name bos ola bilmez");

                Id = nextId++;
                Name = name;
                rooms = new List<Room>();
            }

            public void AddRoom(Room room)
            {
                rooms.Add(room);
            }

            public List<Room> FindAllRooms(Predicate<Room> predicate)
            {
                return rooms.FindAll(predicate);
            }

            public void MakeReservation(int? roomId, int numberOfGuests)
            {
                if (roomId == null)
                    throw new ArgumentNullException(nameof(roomId), "Room ID bos ola bilmez");

                Room room = rooms.Find(r => r.Id == roomId);

                if (room == null)
                    throw new ArgumentException("Invalid Room ID.");

                if (!room.IsAvailable)
                throw new NotAvailableException("Room rezervasiyaya uygun deyil");

                if (room.PersonCapacity < numberOfGuests)
                    throw new ArgumentException("Room tutumu heddinden artiqdir");

                room.IsAvailable = false;
            }

            public List<Room> GetAllRooms()
            {
                return rooms;
            }
        }
    }

