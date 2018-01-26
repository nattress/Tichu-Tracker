//
//  GameTableViewController.swift
//  Tichu
//
//  Created by Simon Nattress on 10/1/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class GameTableViewController: UITableViewController {

    // MARK: Properties
    var games = [Game]()
    
    @IBOutlet var gameTableView: UITableView!
    override func viewDidLoad() {
        super.viewDidLoad()

        // Uncomment the following line to preserve selection between presentations
        // self.clearsSelectionOnViewWillAppear = false

        // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
        // self.navigationItem.rightBarButtonItem = self.editButtonItem
        
        // Do any additional setup after loading the view, typically from a nib.
        let backItem = UIBarButtonItem(title: "+", style: .plain, target: self, action: #selector(newGame(sender:)))
        self.navigationItem.rightBarButtonItem = backItem
        
    }
    
    @objc func newGame(sender: UIBarButtonItem)
    {
        let viewController:UIViewController = UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "NewGameViewController") as UIViewController
        (viewController as! NewGameViewController).completionHandler =  { players in
            //sender.setTitle(player.name, for: [])
            let game = Game(players: players, creationDate: Date(), team1Score: 0, team2Score: 0, scoreLimit: 1000, gameOver: false, hands: [])
            self.games.insert(game, at: 0)
            self.gameTableView.reloadData()
        }
        self.navigationController?.pushViewController(viewController, animated: true)
    }
    
    // MARK: - Table view data source

    override func numberOfSections(in tableView: UITableView) -> Int {
        // #warning Incomplete implementation, return the number of sections
        return 1
    }

    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        // #warning Incomplete implementation, return the number of rows
        return games.count
    }
    
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        guard let cell = tableView.dequeueReusableCell(withIdentifier: "GameTableViewCell", for: indexPath) as? GameTableViewCell
            else
        {
            fatalError("The dequeued cell is not of type PlayerListTableViewCell")
        }
        
        let game = self.games[indexPath.row]
        // Configure the cell...
        cell.player1Name.text = game.players[0].name
        cell.player2Name.text = game.players[2].name
        cell.player3Name.text = game.players[1].name
        cell.player4Name.text = game.players[3].name
        cell.date.text = game.creationDate.toString(dateFormat: "MM/dd")
        cell.score.text = "\(game.team1Score) : \(game.team2Score)"
        return cell
    }
    
    /*
    // Override to support conditional editing of the table view.
    override func tableView(_ tableView: UITableView, canEditRowAt indexPath: IndexPath) -> Bool {
        // Return false if you do not want the specified item to be editable.
        return true
    }
    */

    /*
    // Override to support editing the table view.
    override func tableView(_ tableView: UITableView, commit editingStyle: UITableViewCellEditingStyle, forRowAt indexPath: IndexPath) {
        if editingStyle == .delete {
            // Delete the row from the data source
            tableView.deleteRows(at: [indexPath], with: .fade)
        } else if editingStyle == .insert {
            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
        }    
    }
    */

    /*
    // Override to support rearranging the table view.
    override func tableView(_ tableView: UITableView, moveRowAt fromIndexPath: IndexPath, to: IndexPath) {

    }
    */

    /*
    // Override to support conditional rearranging of the table view.
    override func tableView(_ tableView: UITableView, canMoveRowAt indexPath: IndexPath) -> Bool {
        // Return false if you do not want the item to be re-orderable.
        return true
    }
    */

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
