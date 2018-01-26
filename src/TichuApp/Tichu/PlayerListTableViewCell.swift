//
//  PlayerListTableViewCell.swift
//  Tichu
//
//  Created by Simon Nattress on 10/24/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class PlayerListTableViewCell: UITableViewCell {

    
    @IBOutlet weak var playerName: UILabel!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
