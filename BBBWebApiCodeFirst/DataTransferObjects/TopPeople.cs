using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class TopPeople
    {
        public int Gid { get; set; }

        public int Id { get; set; }

        public int ZoneAct { get; set; }

        public int People { get; set; }

        public Geometry Geom { get; set; }
        

    }
}
