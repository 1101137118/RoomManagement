using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class RoomDao : GenericDao<Room>, IRoomDao
    {
        override protected IRowMapper<Room> GetRowMapper()
        {
            return new RoomRowMapper();
        }

        public void AddRoom(Room Room)
        {
            string command = @"INSERT INTO Room (Room_ID, Room_Name,Room_maxpeople,Room_holidayprice,Room_weekdaysprice,Room_statue) VALUES (@Id, @Name, @maxpeople,@holidayprice,@weekdaysprice,@statue);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = Room.Id;
            parameters.Add("Name", DbType.String).Value = Room.Name;
            parameters.Add("maxpeople", DbType.String).Value = Room.maxpeople;
            parameters.Add("weekdaysprice", DbType.String).Value = Room.weekdaysprice;
            parameters.Add("holidayprice", DbType.String).Value = Room.holidayprice;
            parameters.Add("statue", DbType.String).Value = Room.statue;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateRoom(Room Room)
        {
            string command = @"UPDATE Room SET Room_Name = @Name, Room_maxpeople = @maxpeople, Room_weekdaysprice = @weekdaysprice, Room_holidayprice = @holidayprice, Room_statue = @statue WHERE Room_ID = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = Room.Id;
            parameters.Add("Name", DbType.String).Value = Room.Name;
            parameters.Add("maxpeople", DbType.String).Value = Room.maxpeople;
            parameters.Add("weekdaysprice", DbType.String).Value = Room.weekdaysprice;
            parameters.Add("holidayprice", DbType.String).Value = Room.holidayprice;
            parameters.Add("statue", DbType.String).Value = Room.statue;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteRoom(Room Room)
        {
            string command = @"DELETE FROM Room WHERE Room_ID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = Room.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Room> GetAllRoom()
        {
            string command = @"SELECT * FROM Room ORDER BY Room_ID ASC";
            IList<Room> Room = ExecuteQueryWithRowMapper(command);
            return Room;
        }

        public Room GetRoomByName(string name)
        {
            string command = @"SELECT * FROM Room WHERE Room_Name = @Name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Name", DbType.String).Value = name;

            IList<Room> Room = ExecuteQueryWithRowMapper(command, parameters);
            if (Room.Count > 0)
            {
                return Room[0];
            }

            return null;
        }

        public Room GetRoomById(string id)
        {
            string command = @"SELECT * FROM Room WHERE Room_ID = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = id;

            IList<Room> Room = ExecuteQueryWithRowMapper(command, parameters);
            if (Room.Count > 0)
            {
                return Room[0];
            }

            return null;
        }
    }
}
