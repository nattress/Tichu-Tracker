using System;
using System.Diagnostics;

namespace ScoreConverter
{
    class TichuPListParser
    {
        PListParser _parser;
        
        public TichuPListParser(PListParser parser)
        {
            _parser = parser;
        }

        public Scores Parse()
        {
            Scores scores = new Scores();

            // Root contains an array named "NS.objects" which contains the list of all
            // games played.
            var root = _parser.RootNode;
            var gamesList = root.AsDictionaryNode()["NS.objects"].AsArrayNode();
            DateTime webkitEpoch = new DateTime(2001, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            for (int i = 0; i < gamesList.Count; i++)
            {
                var game = gamesList[i].AsDictionaryNode();
                var score1 = game["score1"];
                var score2 = game["score2"];
                var date = game["date"].AsDictionaryNode()["NS.time"].AsDouble();
                
                var gameObject = new Game();
                gameObject.CreationDateTime = webkitEpoch.AddSeconds(date).Subtract(unixEpoch).TotalSeconds.ToString();
                gameObject.GameOver = game["gameOver"].AsBool();
            }

            return scores;
        }
    }
}