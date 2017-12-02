using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using PlistCS;

namespace ScoreConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "/Users/simonnattress/git/tichu/src/score_converter/test_data/allgames.xml";
            
            TichuPListParser tichuParser = new TichuPListParser(new PListParser(fileName));
            var scores = tichuParser.Parse();
            var serializer = Newtonsoft.Json.JsonSerializer.Create();
            using (TextWriter tw = File.CreateText("/Users/simonnattress/git/tichu/src/score_converter/test_data/allgames.converted.json"))
            {
                serializer.Serialize(tw, scores);
            }
            ValidateAgainstSchema();
        }

        private static void ValidateAgainstSchema()
        {
            JsonTextReader jsonReader = new JsonTextReader(File.OpenText("/Users/simonnattress/git/tichu/src/score_converter/test_data/allgames.converted.json"));
            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(jsonReader);
            validatingReader.Schema = JSchema.Load(new JsonTextReader(File.OpenText("/Users/simonnattress/git/tichu/src/score_converter/tichu_schema.json")));
            JsonSerializer serializer = new JsonSerializer();
            Scores scores = serializer.Deserialize<Scores>(validatingReader);
        }
    }
}
