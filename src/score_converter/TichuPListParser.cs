using System;
using System.Collections.Generic;
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
            Dictionary<string, Player> playersDictionary = new Dictionary<string, Player>();
            List<Player> playersList = new List<Player>();

            // Root contains an array named "NS.objects" which contains the list of all
            // games played.
            var root = _parser.RootNode;
            var gamesList = root.AsDictionaryNode()["NS.objects"].AsArrayNode();
            
            for (int i = 0; i < gamesList.Count; i++)
            {
                var game = gamesList[i].AsDictionaryNode();
                
                var gameObject = new Game();
                gameObject.Id = i;
                var date = game["date"].AsDictionaryNode()["NS.time"].AsDouble();
                gameObject.CreationDateTime = WebkitTimeConverter.ToUnixTimestamp(date).ToString();
                gameObject.GameOver = game["gameOver"].AsBool();
                gameObject.Team1Score = game["score1"].AsInt();
                gameObject.Team2Score = game["score2"].AsInt();
                if (game.ContainsKey("gameLimit"))
                {
                    gameObject.ScoreLimit = game["gameLimit"].AsInt();
                }
                
                var hands = game["hands"].AsDictionaryNode();
                gameObject.Hands = ParseHandsForGame(hands["NS.objects"].AsArrayNode());

                //
                // Players are created on demand when they're first encountered in a game. A player
                // ID is generated which is the 0-based order they were discovered while parsing
                // the scores.
                //
                gameObject.Players = new List<int>();
                for (int j = 0; j < 4; j++)
                {
                    string playerName;

                    // The data format changed somewhere around 2015 from an NS.string nested in a
                    // dictionary, to just a string element.
                    if (game["name" + j] is PListDictionaryNode)
                    {
                        playerName = game["name" + j].AsDictionaryNode()["NS.string"].AsString();
                    }
                    else
                    {
                        playerName = game["name" + j].AsString();
                    }
                    if (!playersDictionary.ContainsKey(playerName))
                    {
                        var newPlayer = new Player(playersDictionary.Count, playerName);
                        playersDictionary.Add(playerName, newPlayer);
                        Debug.Assert(playersList.Count == newPlayer.Id);
                        playersList.Add(newPlayer);
                    }
                    gameObject.Players.Add(playersDictionary[playerName].Id);
                }

                scores.Games.Add(gameObject);
            }

            scores.Players = playersList;
            
            return scores;
        }

        private List<Hand> ParseHandsForGame(PListArrayNode hands)
        {
            List<Hand> handsList = new List<Hand>();

            for (int i = 0; i < hands.Count; i++)
            {
                var hand = hands[i].AsDictionaryNode();
                var handObject = new Hand();
                handObject.TichuScore0 = hand["tichuScore1"].AsInt();
                handObject.TichuScore1 = hand["tichuScore2"].AsInt();
                handObject.CardScore0 = hand["cardScore1"].AsInt();
                handObject.CardScore1 = hand["cardScore2"].AsInt();
                handObject.TotalScore0 = hand["totalScore1"].AsInt();
                handObject.TotalScore1 = hand["totalScore2"].AsInt();
                handObject.OutFirst = hand["outFirst"].AsInt();
                handObject.GrandTichuCall0 = hand["grandTichu0"].AsBool();
                handObject.GrandTichuCall1 = hand["grandTichu1"].AsBool();
                handObject.GrandTichuCall2 = hand["grandTichu2"].AsBool();
                handObject.GrandTichuCall3 = hand["grandTichu3"].AsBool();
                handObject.TichuCall0 = hand["tichu0"].AsBool();
                handObject.TichuCall1 = hand["tichu1"].AsBool();
                handObject.TichuCall2 = hand["tichu2"].AsBool();
                handObject.TichuCall3 = hand["tichu3"].AsBool();

                handsList.Add(handObject);
                Console.WriteLine($"Hand score {handObject.TotalScore0}:{handObject.TotalScore1}");
            }

            return handsList;
        }
    }
}