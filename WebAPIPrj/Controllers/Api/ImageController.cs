using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Drawing;

namespace WebAPIPrj.Controllers.Api {
    /// <summary>
    /// 接收並解析保存base64格式的圖片
    /// </summary>
    public class ImageController : ApiController {
        /// <summary>
        /// 接收Base64編碼格式的圖片
        /// </summary>
        public void Upload() {
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            string text = context.Request.Form["file"];

            //獲取文件儲存路徑
            string path = context.Request.MapPath("~/App_Data/"); //獲取當前項目所在目錄
            string suffix = ".jpg"; //文件的後綴名根據實際情況
            string strPath = path + GetTimeStamp() + suffix;

            //獲取圖片並保存
            Base64ToImg(text).Save(strPath);
        }

        //解析base64編碼獲取圖片
        private Bitmap Base64ToImg(string base64Code) {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64Code));
            return new Bitmap(stream);
        }

        //獲取當前時間段額時間戳
        private string GetTimeStamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}
