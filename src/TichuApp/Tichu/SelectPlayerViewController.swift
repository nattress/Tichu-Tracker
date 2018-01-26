//
//  SelectPlayerViewController.swift
//  Tichu
//
//  Created by Simon Nattress on 10/24/17.
//  Copyright © 2017 Simon Nattress. All rights reserved.
//

import UIKit

class SelectPlayerViewController: UITableViewController {
    var players = [Player]()
    var selectedPlayerIndex: Int = 0
    var completionHandler:((Player) -> Void)?
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
        loadSamplePlayers()
        
        //self.tableView.register(PlayerListTableViewCell.self, forCellReuseIdentifier: "PlayerListTableViewCell")
        //self.tableView.register(UITableViewCell.self, forCellReuseIdentifier: "PlayerListTableViewCell")
        //tableView.dataSource = self
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    // MARK: - Table view data source
    override func numberOfSections(in tableView: UITableView) -> Int {
        // #warning Incomplete implementation, return the number of sections
        return 1
    }
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        // #warning Incomplete implementation, return the number of rows
        return players.count
    }
    
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cellIdentifier = "PlayerListTableViewCell"
        
        guard let cell = self.tableView.dequeueReusableCell(withIdentifier: cellIdentifier, for: indexPath) as? PlayerListTableViewCell
            else
        {
            fatalError("The dequeued cell is not of type PlayerListTableViewCell")
        }
        
        let player = players[indexPath.row]
        cell.playerName.text = player.name
        
        return cell
    }

    private func savePlayers()
    {
        //let isSuccessfulSave = NSKeyedArchiver.archiveRootObject(players, toFile: Player.ArchiveURL.path)
    }
    
    private func loadSamplePlayers()
    {
        let player1 = Player(name: "Simon")
        let player2 = Player(name: "Bruce")
        let player3 = Player(name: "Daniel")
        let player4 = Player(name: "Matt")
        let player5 = Player(name: "Drew")
        
        players += [player1, player2, player3, player4, player5]
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        completionHandler?(players[indexPath.row])
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
