using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{/// <summary>
 /// 需要在将公共语言运行时 (CLR) 对象映射到 MongoDB 集合时使用。
///    使用[BsonId] 进行批注，以将此属性指定为文档的主键。
///使用[BsonRepresentation(BsonType.ObjectId)] 进行批注，以允许将参数作为类型 string 而非 ObjectId 结构传递。 Mongo 处理从 string 到 ObjectId 的转换。
///BookName 属性使用[BsonElement] 特性进行批注。 Name 的属性值表示 MongoDB 集合中的属性名称。
/// </summary>
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
