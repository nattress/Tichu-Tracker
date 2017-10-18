using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
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
        }
    }
}
