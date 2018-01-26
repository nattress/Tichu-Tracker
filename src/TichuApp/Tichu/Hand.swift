//
//  Hand.swift
//  Tichu
//
//  Created by Simon Nattress on 10/18/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import Foundation

class Hand
{
    var tichuCall0: Bool
    var tichuCall1: Bool
    var tichuCall2: Bool
    var tichuCall3: Bool
    
    var grandTichuCall0: Bool
    var grandTichuCall1: Bool
    var grandTichuCall2: Bool
    var grandTichuCall3: Bool
    
    var tichuScore0: Int
    var tichuScore1: Int
    
    var cardScore0: Int
    var cardScore1: Int
    
    var totalScore0: Int
    var totalScore1: Int
    var outFirst: Int
    
    init(tichuCall0: Bool,
         tichuCall1: Bool,
         tichuCall2: Bool,
         tichuCall3: Bool,
         grandTichuCall0: Bool,
         grandTichuCall1: Bool,
         grandTichuCall2: Bool,
         grandTichuCall3: Bool,
         tichuScore0: Int,
         tichuScore1: Int,
         cardScore0: Int,
         cardScore1: Int,
         totalScore0: Int,
         totalScore1: Int,
         outFirst: Int)
    {
        self.tichuCall0 = tichuCall0
        self.tichuCall1 = tichuCall1
        self.tichuCall2 = tichuCall2
        self.tichuCall3 = tichuCall3
        self.grandTichuCall0 = grandTichuCall0
        self.grandTichuCall1 = grandTichuCall1
        self.grandTichuCall2 = grandTichuCall2
        self.grandTichuCall3 = grandTichuCall3
        self.tichuScore0 = tichuScore0
        self.tichuScore1 = tichuScore1
        self.cardScore0 = cardScore0
        self.cardScore1 = cardScore1
        self.totalScore0 = totalScore0
        self.totalScore1 = totalScore1
        self.outFirst = outFirst
    }
}
