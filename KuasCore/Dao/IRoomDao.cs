using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao
{
    public interface IRoomDao
    {
        void AddRoom(Room Room);

        void UpdateRoom(Room Room);

        void DeleteRoom(Room Room);

        IList<Room> GetAllRoom();

        Room GetRoomByName(string name);

        Room GetRoomById(string id);

    }
}
