using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Category Category { get; set; }
    }
}