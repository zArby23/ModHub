using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class GameCategory
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }
        public int GameId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
