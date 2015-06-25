using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class RoomService : IRoomService
    {
        public IRoomDao RoomDao { get; set; }

        public Room AddRoom(Room Room)
        {
            RoomDao.AddRoom(Room);
            return GetRoomByName(Room.Name);
        }

        public void UpdateRoom(Room Room)
        {
            RoomDao.UpdateRoom(Room);
        }

        public void DeleteRoom(Room Room)
        {
            Room = RoomDao.GetRoomByName(Room.Name);

            if (Room != null)
            {
                RoomDao.DeleteRoom(Room);
            }
        }

        public IList<Room> GetAllRoom()
        {
            return RoomDao.GetAllRoom();
        }

        public Room GetRoomByName(string name)
        {
            return RoomDao.GetRoomByName(name);
        }

        public Room GetRoomById(string id)
        {
            return RoomDao.GetRoomById(id);
        }
    }
}
