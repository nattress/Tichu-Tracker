//
//  Game.swift
//  Tichu
//
//  Created by Simon Nattress on 10/1/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class Game
{
    var players: [Player] = []
    var creationDate: Date
    var team1Score: Int
    var team2Score: Int
    var scoreLimit: Int
    var gameOver: Bool
    var hands: [Hand] = []
    
    init(players: [Player], creationDate: Date, team1Score: Int, team2Score: Int, scoreLimit: Int, gameOver: Bool, hands: [Hand])
    {
        self.players = players
        self.creationDate = creationDate
        self.team1Score = team1Score
        self.team2Score = team2Score
        self.scoreLimit = scoreLimit
        self.gameOver = gameOver
        self.hands = hands
    }
}
