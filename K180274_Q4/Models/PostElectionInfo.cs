using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K180274_Q4.Models
{
    public class PostElectionInfo
    {
        public string CandidateName;
        public int VoteCounts { get; set; }


        public PostElectionInfo(string CandidateName, int VoteCounts)
        {
            this.CandidateName = CandidateName;
            this.VoteCounts = VoteCounts;


        }

    }

    
}