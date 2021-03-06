﻿using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels
{
    public class Team
    {
        public int Id { get; set; }

        public List<Player> PlayerList { get; set; }

        public string Name { get; set; }

        public BlobData PictureLogo { get; set; }

        public Stadium Stadium { get; set; }

        public string City { get; set; }
    }
}
