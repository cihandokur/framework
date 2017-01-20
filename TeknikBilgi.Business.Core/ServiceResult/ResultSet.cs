using Newtonsoft.Json;
using System;
using TeknikBilgi.Localization;

namespace TeknikBilgi.Business.Core.ServiceResult
{
    /// <summary>
    /// Varsayılan değerleri 
    /// Success = false
    /// Message = "İşleminiz gerçekleştirilemedi"
    /// </summary>
    [JsonObject]
    [Serializable]
    public class ResultSet
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultSet()
        {
            Success = false;
            Message = Common.OperationFailed;
        }

        public ResultSet(bool defaultValue)
        {
            Success = defaultValue;
            Message = defaultValue ? Common.OperationSuccess : Common.OperationFailed;
        }
    }

    /// <summary>
    /// Varsayılan değerleri 
    /// Success = false
    /// Message = "İşleminiz gerçekleştirilemedi"
    /// </summary>
    /// 
    [JsonObject]
    [Serializable]
    public class ResultSet<T> : ResultSet
    {
        public T Object { get; set; }
    }
}