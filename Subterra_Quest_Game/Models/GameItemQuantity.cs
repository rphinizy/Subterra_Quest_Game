﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class GameItemQuantity
    {
        public GameItem GameItem { get; set; }
        public int Quantity { get; set; }

        public GameItemQuantity()
        {

        }

        public GameItemQuantity(GameItem gameItem, int quantity)
        {
            GameItem = gameItem;
            Quantity = quantity;
        }
    }
}
