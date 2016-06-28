using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities
{
    public class SearchData
    {
        public string Name { get; set; }

        public Sex? Sex { get; set; }

        public int? AgeFrom { get; set; }

        public int? AgeTo { get; set; }

        public string Hometown { get; set; }
    }
}
