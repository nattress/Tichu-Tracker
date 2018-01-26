//
//  GameTableViewCell.swift
//  Tichu
//
//  Created by Simon Nattress on 10/1/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class GameTableViewCell: UITableViewCell {

    //MARK: Properties
    
    @IBOutlet weak var player1Name: UILabel!
    @IBOutlet weak var player2Name: UILabel!
    @IBOutlet weak var player3Name: UILabel!
    @IBOutlet weak var player4Name: UILabel!
    @IBOutlet weak var date: UILabel!
    @IBOutlet weak var score: UILabel!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
