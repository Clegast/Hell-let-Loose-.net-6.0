using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
   
    internal class Map
    {
        Coordinates coordinates;
        public string Name { get; set; }

        public int MapNorth { get; set; }

        public int PositionGer { get; set; }

        public int PositionAmy { get; set; }
        
        public int PositionSov { get; set; }

        public Coordinates[] Aryposition { get; set; }

        public Map(string name,int mapnorth,int positionGreman,int positionamy, int positionsov, Coordinates[] coordinates)
        {
            Name = name;
            MapNorth = mapnorth;
            PositionGer = positionGreman;
            PositionAmy = positionamy;
            PositionSov = positionsov;
            Aryposition = coordinates;

        }
        public Map(string name, int mapnorth, int positionGreman,  Coordinates[] coordinates,int positionsov)
        {
            Name = name;
            MapNorth = mapnorth;
            PositionGer = positionGreman;
            PositionSov = positionsov;
            Aryposition = coordinates;

        }
        Map Hürtgenwald = new Map("Hürtgenwald", 0, 270, 90, 0, new Coordinates[6] {new Coordinates(551,509), new Coordinates(551, 518),  new Coordinates(551, 527), new Coordinates(1365, 578), new Coordinates(1365, 582), new Coordinates(1365, 585) } );



    }

}
