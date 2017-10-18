using System;
using System.Collections.Generic;
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
            tichuParser.Parse();
        }
    }
}
