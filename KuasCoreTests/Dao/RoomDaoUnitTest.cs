using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class RoomDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IRoomDao RoomDao { get; set; }


        [TestMethod]
        public void TestRoomDao_AddRoom()
        {
            Room Room = new Room();
            Room.Id = "UnitTests";
            Room.Name = "單元測試";
            Room.maxpeople = "請做出單元測試";
            Room.weekdaysprice = "請做出單元測試";
            Room.holidayprice = "請做出單元測試";
            Room.statue = "請做出單元測試";
            RoomDao.AddRoom(Room);

            Room dbRoom = RoomDao.GetRoomByName(Room.Name);
            Assert.IsNotNull(dbRoom);
            Assert.AreEqual(Room.Name, dbRoom.Name);

            Console.WriteLine("課程編號為 = " + dbRoom.Id);
            Console.WriteLine("課程名稱為 = " + dbRoom.Name);
            Console.WriteLine("課程描述為 = " + dbRoom.maxpeople);
            Console.WriteLine("課程描述為 = " + dbRoom.weekdaysprice);
            Console.WriteLine("課程描述為 = " + dbRoom.holidayprice);
            Console.WriteLine("課程描述為 = " + dbRoom.statue);

            RoomDao.DeleteRoom(dbRoom);
            dbRoom = RoomDao.GetRoomByName(Room.Name);
            Assert.IsNull(dbRoom);
        }

    }
}
