//
//  NewGameViewController.swift
//  Tichu
//
//  Created by Simon Nattress on 10/18/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class NewGameViewController: UIViewController {

    @IBOutlet weak var northButton: UIButton!
    @IBOutlet weak var eastButton: UIButton!
    @IBOutlet weak var southButton: UIButton!
    @IBOutlet weak var westButton: UIButton!
    var completionHandler:(([Player]) -> Void)?
    var currentButton: UIButton? = nil
    let selectPlayer: String = "Select Player"
    var players = [Player?](repeating: nil, count:4)
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func ButtonPressed(_ sender: UIButton)
    {
        let viewController:UIViewController = UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "SelectPlayerViewController") as UIViewController
        (viewController as! SelectPlayerViewController).completionHandler =  { player in
            if (sender == self.northButton)
            {
                self.players[0] = player
            }
            else if (sender == self.eastButton)
            {
                self.players[1] = player
            }
            else if (sender == self.southButton)
            {
                self.players[2] = player
            }
            else if (sender == self.westButton)
            {
                self.players[3] = player
            }
            sender.setTitle(player.name, for: [])
        }
        self.navigationController?.pushViewController(viewController, animated: true)
    }
    
    @IBAction func startGamePressed(_ sender: Any) {
        completionHandler?(players as! [Player])
        navigationController?.popViewController(animated: true)
    }
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
