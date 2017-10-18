using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScoreConverter
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    class Game
    {
        public int Id {get;set;}

        public List<int> Players;

        public int GameOverScore {get;set;}
        public bool GameOver {get;set;}
        public int Team1Score {get;set;}
        public int Team2Score {get;set;}
        public string CreationDateTime {get;set;}

        public List<Hand> Hands {get;set;}
    }

}