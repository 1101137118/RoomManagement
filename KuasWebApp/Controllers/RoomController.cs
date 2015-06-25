using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class RoomController : ApiController
    {

        public IRoomService RoomService { get; set; }

        [HttpPost]
        public Room AddRoom(Room Room)
        {
            CheckRoomIsNotNullThrowException(Room);

            try
            {
                return RoomService.AddRoom(Room);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Room UpdateRoom(Room Room)
        {
            CheckRoomIsNullThrowException(Room);

            try
            {
                RoomService.UpdateRoom(Room);
                return RoomService.GetRoomByName(Room.Name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteEmployee(Room Room)
        {
            try
            {
                RoomService.DeleteRoom(Room);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Room> GetAllRoom()
        {
            return RoomService.GetAllRoom();
        }

        [HttpGet]
        public Room GetRoomById(string id)
        {
            var Room = RoomService.GetRoomById(id);

            if (Room == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Room;
        }

        [HttpGet]
        [ActionName("Name")]
        public Room GetRoomByName(string input)
        {
            var Room = RoomService.GetRoomByName(input);

            if (Room == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Room;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="Room">
        ///     課程資料.
        /// </param>
        private void CheckRoomIsNullThrowException(Room Room)
        {
            Room dbRoom = RoomService.GetRoomById(Room.Id);

            if (dbRoom == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="Room">
        ///     課程資料.
        /// </param>
        private void CheckRoomIsNotNullThrowException(Room Room)
        {
            Room dbRoom = RoomService.GetRoomById(Room.Id);

            if (dbRoom != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}