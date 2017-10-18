using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScoreConverter
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    class Scores
    {
        public string Version => "1.0.0";
        public List<Player> Players {get;set;}
        public List<Game> Games {get;set;}
    }
}
