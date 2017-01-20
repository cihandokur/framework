namespace TeknikBilgi.Infrastructure.Interface
{
    public interface ICookieManager
    {
        int? ExpireMinute { get; set; }
        string Name { get; set; }

        bool IsHttpOnly { get; set; }

        /// <summary>
        /// Cookie'ye yazma işlemini yapar.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="isHttpOnly"></param>
        /// <param name="expireMinute">Null set edilirse Session Bazlı set eder</param>
        /// <returns>true  / false </returns>
        bool Write(object value, string name = "", bool isHttpOnly = true, int? expireMinute = null);

        string Read(string name = "");

        bool Remove(string name = "");
    }
}