using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using WebAPIPrj.Models;

namespace WebAPIPrj.Controllers.Api
{
    public class RestController : ApiController {
        private List<Users> _userList = new List<Users>
        {
            new Users { UserID = 1 , UserName = "zzl" , UserEmail = "bfyxzls@sina.com" } ,
            new Users { UserID = 2 , UserName = "Spiderman" , UserEmail = "Spiderman@cnblogs.com" } ,
            new Users { UserID = 3 , UserName = "Batman" , UserEmail = "Batman@cnblogs.com" }
        };

        /// <summary>
        /// 得到清單物件R
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> Get() {
            return _userList;
        }

        /// <summary>
        /// 得到一個實體，根據主鍵R
        /// </summary>
        /// <param name="id">主鍵</param>
        /// <returns></returns>
        public Users Get(int id) {
            return _userList.FirstOrDefault(p => p.UserID == id);
        }

        /// <summary>
        /// 添加C
        /// </summary>
        /// <param name="entity">表單物件，它是唯一的</param>
        /// <returns></returns>
        public Users Post([FromBody]Users entity) {
            _userList.Add(entity);
            return entity;
        }

        /// <summary>
        /// 更新U
        /// </summary>
        /// <param name="id">主鍵</param>
        /// <param name="entity">表單物件，它是唯一的</param>
        /// <returns></returns>
        public Users Put(int id, [FromBody]Users entity) {
            var user = _userList.FirstOrDefault(i => i.UserID == id);
            if (user != null) {
                user.UserName = entity.UserName;
                user.UserEmail = entity.UserEmail;
            }
            return user;
        }

        /// <summary>
        /// 刪除D
        /// </summary>
        /// <param name="id">主鍵</param>
        public void Delete(int id) {
            _userList.Remove(_userList.FirstOrDefault(u => u.UserID == id));
        }
    }
}
