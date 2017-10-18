using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScoreConverter
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    class Hand
    {
        public bool TichuCall0 {get;set;}
        public bool TichuCall1 {get;set;}
        public bool TichuCall2 {get;set;}
        public bool TichuCall3 {get;set;}

        public bool GrandTichuCall0 {get;set;}
        public bool GrandTichuCall1 {get;set;}
        public bool GrandTichuCall2 {get;set;}
        public bool GrandTichuCall3 {get;set;}

        public int TichuScore0 {get;set;}
        public int TichuScore1 {get;set;}
        public int CardScore0 {get;set;}
        public int CardScore1 {get;set;}

        public int TotalScore0 {get;set;}
        public int TotalScore1 {get;set;}
        public int? OutFirst {get;set;}
    }
}