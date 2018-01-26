//
//  DateExtensions.swift
//  Tichu
//
//  Created by Simon Nattress on 1/20/18.
//  Copyright © 2018 Simon Nattress. All rights reserved.
//

import Foundation

extension Date
{
    func toString( dateFormat format  : String ) -> String
    {
        let dateFormatter = DateFormatter()
        dateFormatter.dateFormat = format
        return dateFormatter.string(from: self)
    }
    
}
