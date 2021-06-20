using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

/// <summary>
/// JsonUtils 的摘要说明
/// </summary>
public class JsonUtils
{
    public JsonUtils()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static string GetJson<T>(T t)
    {
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            json.WriteObject(ms, t);
            string Json = Encoding.UTF8.GetString(ms.ToArray());
            return Json;
        }
    }
}