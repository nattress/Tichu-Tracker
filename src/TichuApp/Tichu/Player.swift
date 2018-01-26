//
//  Player.swift
//  Tichu
//
//  Created by Simon Nattress on 10/1/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit
import os.log

class Player: NSObject, NSCoding
{
    struct PropertyKey
    {
        static let name = "name"
    }
    
    var name: String
    
    init(name: String)
    {
        self.name = name
    }
    
    public func encode(with aCoder: NSCoder)
    {
        aCoder.encode(name, forKey: PropertyKey.name)
    }
    
    required convenience init?(coder aDecoder: NSCoder)
    {
        guard let name = aDecoder.decodeObject(forKey: PropertyKey.name) as? String else {
            os_log("Unable to decode the name for a Player object.", log: OSLog.default, type: .debug)
            return nil
        }
        self.init(name: name)
    }
    
    //MARK: Archiving Paths
    static let DocumentsDirectory = FileManager().urls(for: .documentDirectory, in: .userDomainMask).first!
    static let ArchiveURL = DocumentsDirectory.appendingPathComponent("players")
}
