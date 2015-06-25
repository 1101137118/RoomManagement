using Core;
using KuasCore.Models;
using KuasCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class RoomServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IRoomService RoomService { get; set; }

        [TestMethod]
        public void TestRoomService_AddRoom()
        {

            Room Room = new Room();
            Room.Id = "UnitTests";
            Room.Name = "單元測試";
            Room.maxpeople = "請做出單元測試";
            Room.weekdaysprice = "請做出單元測試";
            Room.holidayprice = "請做出單元測試";
            Room.statue = "請做出單元測試";
            RoomService.AddRoom(Room);

            Room dbRoom = RoomService.GetRoomByName(Room.Name);
            Assert.IsNotNull(dbRoom);
            Assert.AreEqual(Room.Name, dbRoom.Name);

            Console.WriteLine("課程編號為 = " + dbRoom.Id);
            Console.WriteLine("課程名稱為 = " + dbRoom.Name);
            Console.WriteLine("課程描述為 = " + dbRoom.maxpeople);
            Console.WriteLine("課程描述為 = " + dbRoom.weekdaysprice);
            Console.WriteLine("課程描述為 = " + dbRoom.holidayprice);
            Console.WriteLine("課程描述為 = " + dbRoom.statue);

            RoomService.DeleteRoom(dbRoom);
            dbRoom = RoomService.GetRoomByName(Room.Name);
            Assert.IsNull(dbRoom);
        }

    }
}
