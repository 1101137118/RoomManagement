using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class RoomRowMapper : IRowMapper<Room>
    {
        public Room MapRow(IDataReader dataReader, int rowNum)
        {
            Room target = new Room();

            target.Id = dataReader.GetString(dataReader.GetOrdinal("Room_ID"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("Room_Name"));
            target.maxpeople = dataReader.GetString(dataReader.GetOrdinal("Room_maxpeople"));
            target.holidayprice = dataReader.GetString(dataReader.GetOrdinal("Room_holidayprice"));
            target.weekdaysprice = dataReader.GetString(dataReader.GetOrdinal("Room_weekdaysprice"));
            target.statue = dataReader.GetString(dataReader.GetOrdinal("Room_statue"));
            return target;
        }
    }
}