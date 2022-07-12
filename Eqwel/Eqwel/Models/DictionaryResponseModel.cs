using Newtonsoft.Json;

namespace Eqwel.Models
{
    public class DictionaryResponseModel
    {
        [JsonProperty("en")]
        public string English { get; set; }

        [JsonProperty("ru")]
        public string Russian { get; set; }
    }
}
