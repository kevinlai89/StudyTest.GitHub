using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace UserSystem.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 返回对象序列化
        /// </summary>
        /// <param name="obj">源对象</param>
        /// <returns>json数据</returns>
        public static string ToJson(object obj)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj);
        }
    }
}
