using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotCompanion
{
    public class Scenario
    {
        public Map map;
        public Faction[] factions;
        Faction Lannister, Stark, Baratheon, Greyjoy, Tyrell, Martell, Arryn;

        public int numPlayers;
        public int requiredVictoryPoints;
        public int roundNumber = 1;

        //Board game constants
        public const int MAX_FOOTMEN = 10;
        public const int MAX_KNIGHTS = 5;
        public const int MAX_SHIPS = 6;
        public const int MAX_SIEGETOWERS = 2;
        public const int MAX_POWERTOKENS = 20;

        //Influence Track
        public Faction[] IronThroneTrack, MessengerRavenTrack, ValyrianBladeTrack;

        public int[][] supplyValues = new int[][]
        {
            new int[] {2, 2},
            new int[] {3, 2},
            new int[] {3, 2, 2},
            new int[] {3, 2, 2, 2},
            new int[] {3, 3, 2, 2},
            new int[] {4, 3, 2, 2},
            new int[] {4, 3, 2, 2, 2}
        };
        public int[] starredOrders = new int[]
        {
            3, 3, 2, 1, 0, 0, 0
        };

        //Westeros Cards
        WesterosDeck WestDeck = new WesterosDeck(0);

        //Wildings
        public int wildlingStrength;


        //Setup scenario based on Scenario ID
        public Scenario(int scenarioId)
        {
            switch (scenarioId)
            {
                default:
                    #region A Game Of Thrones (7)
                    //Variables
                    numPlayers = requiredVictoryPoints = 7;
                    Lannister = new Faction();
                    Stark = new Faction();
                    Baratheon = new Faction();
                    Greyjoy = new Faction();
                    Tyrell = new Faction();
                    Martell = new Faction();
                    Arryn = new Faction();
                    wildlingStrength = 2;

                    //Map initialization
                    map = new Map();

                    //Factions
                    factions = new Faction[] { Lannister, Stark, Baratheon, Greyjoy, Tyrell, Martell, Arryn };
                    IronThroneTrack = new Faction[] { Baratheon, Lannister, Stark, Martell, Greyjoy, Tyrell, Arryn };
                    ValyrianBladeTrack = new Faction[] { Greyjoy, Tyrell, Martell, Arryn, Stark, Baratheon, Lannister };
                    MessengerRavenTrack = new Faction[] { Lannister, Arryn, Stark, Martell, Baratheon, Tyrell, Greyjoy };

                    #region Lannister

                    Lannister.name = "House Lannister";
                    Lannister.adjective = "Lannister";
                    Lannister.factionCapitol = map.Lannisport;
                    Lannister.houseCards = new HouseDeck("Lannister");

                    Lannister.addPlot(map.Lannisport);
                    Lannister.addPlot(map.StoneySept);
                    Lannister.addPlot(map.GoldenSound);

                    Lannister.numStarredOrders = starredOrders[0];
                    Lannister.updateCastles(this);
                    Lannister.updateSupply(this);
                    //Lannister.updateVictoryPoints(this);

                    map.Lannisport.addUnit(new Unit(2, Lannister), map);
                    map.Lannisport.addUnit(new Unit(1, Lannister), map);
                    map.StoneySept.addUnit(new Unit(1, Lannister), map);
                    map.GoldenSound.addUnit(new Unit(3, Lannister), map);

                    #endregion Lannister

                    #region Stark

                    Stark.name = "House Stark";
                    Stark.adjective = "Stark";
                    Stark.factionCapitol = map.Winterfell;
                    Stark.houseCards = new HouseDeck("Stark");

                    Stark.addPlot(map.Winterfell);
                    Stark.addPlot(map.WhiteHarbor);
                    Stark.addPlot(map.ShiveringSea);

                    Stark.numStarredOrders = starredOrders[2];
                    Stark.updateCastles(this);
                    Stark.updateSupply(this);
                    //Stark.updateVictoryPoints(this);

                    map.Winterfell.addUnit(new Unit(2, Stark), map);
                    map.Winterfell.addUnit(new Unit(1, Stark), map);
                    map.WhiteHarbor.addUnit(new Unit(1, Stark), map);
                    map.ShiveringSea.addUnit(new Unit(3, Stark), map);

                    #endregion Stark

                    #region Baratheon

                    Baratheon.name = "House Baratheon";
                    Baratheon.adjective = "Baratheon";
                    Baratheon.factionCapitol = map.Dragonstone;
                    Baratheon.houseCards = new HouseDeck("Baratheon");

                    Baratheon.addPlot(map.Dragonstone);
                    Baratheon.addPlot(map.Kingswood);
                    Baratheon.addPlot(map.ShipbreakerBay);

                    Baratheon.numStarredOrders = starredOrders[4];
                    Baratheon.updateCastles(this);
                    Baratheon.updateSupply(this);
                    //Baratheon.updateVictoryPoints(this);

                    map.Dragonstone.addUnit(new Unit(2, Baratheon), map);
                    map.Dragonstone.addUnit(new Unit(1, Baratheon), map);
                    map.Kingswood.addUnit(new Unit(1, Baratheon), map);
                    map.ShipbreakerBay.addUnit(new Unit(3, Baratheon), map);
                    map.ShipbreakerBay.addUnit(new Unit(3, Baratheon), map);

                    #endregion Baratheon

                    #region Greyjoy

                    Greyjoy.name = "House Greyjoy";
                    Greyjoy.adjective = "Greyjoy";
                    Greyjoy.factionCapitol = map.Pyke;
                    Greyjoy.houseCards = new HouseDeck("Greyjoy");

                    Greyjoy.addPlot(map.Pyke);
                    Greyjoy.addPlot(map.GreywaterWatch);
                    Greyjoy.addPlot(map.IronmansBay);

                    Greyjoy.numStarredOrders = starredOrders[6];
                    Greyjoy.updateCastles(this);
                    Greyjoy.updateSupply(this);
                    //Greyjoy.updateVictoryPoints(this);

                    map.Pyke.addUnit(new Unit(2, Greyjoy), map);
                    map.Pyke.addUnit(new Unit(1, Greyjoy), map);
                    map.GreywaterWatch.addUnit(new Unit(1, Greyjoy), map);
                    map.IronmansBay.addUnit(new Unit(3, Greyjoy), map);
                    map.IronmansBay.addUnit(new Unit(3, Greyjoy), map);

                    #endregion Greyjoy

                    #region Tyrell

                    Tyrell.name = "House Tyrell";
                    Tyrell.adjective = "Tyrell";
                    Tyrell.factionCapitol = map.Highgarden;
                    Tyrell.houseCards = new HouseDeck("Tyrell");

                    Tyrell.addPlot(map.Highgarden);
                    Tyrell.addPlot(map.DornishMarches);
                    Tyrell.addPlot(map.RedwyneStraights);

                    Tyrell.numStarredOrders = starredOrders[5];
                    Tyrell.updateCastles(this);
                    Tyrell.updateSupply(this);
                    //Tyrell.updateVictoryPoints(this);

                    map.Highgarden.addUnit(new Unit(2, Tyrell), map);
                    map.Highgarden.addUnit(new Unit(1, Tyrell), map);
                    map.DornishMarches.addUnit(new Unit(1, Tyrell), map);
                    map.RedwyneStraights.addUnit(new Unit(3, Tyrell), map);

                    #endregion Tyrell

                    #region Martell

                    Martell.name = "House Martell";
                    Martell.adjective = "Martell";
                    Martell.factionCapitol = map.Sunspear;
                    Martell.houseCards = new HouseDeck("Martell");

                    Martell.addPlot(map.Sunspear);
                    Martell.addPlot(map.SaltShore);
                    Martell.addPlot(map.SeaOfDorne);

                    Martell.numStarredOrders = starredOrders[3];
                    Martell.updateCastles(this);
                    Martell.updateSupply(this);
                    //Martell.updateVictoryPoints(this);

                    map.Sunspear.addUnit(new Unit(2, Martell), map);
                    map.Sunspear.addUnit(new Unit(1, Martell), map);
                    map.SaltShore.addUnit(new Unit(1, Martell), map);
                    map.SeaOfDorne.addUnit(new Unit(3, Martell), map);

                    #endregion Martell

                    #region Arryn

                    Arryn.name = "House Arryn";
                    Arryn.adjective = "Arryn";
                    Arryn.factionCapitol = map.Eyrie;
                    Arryn.houseCards = new HouseDeck("Arryn");

                    Arryn.addPlot(map.Eyrie);
                    Arryn.addPlot(map.MoonMountains);

                    map.Eyrie.addUnit(new Unit(2, Arryn), map);
                    map.Eyrie.addUnit(new Unit(1, Arryn), map);
                    map.MoonMountains.addUnit(new Unit(1, Arryn), map);
                    
                    Arryn.numStarredOrders = starredOrders[1];
                    Arryn.updateCastles(this);
                    Arryn.updateSupply(this);
                    //Arryn.updateVictoryPoints(this);

                    #endregion Arryn


                    #endregion A Game of Thrones (7)
                    break;



            }

        }
        /*
        private void setupWolfAndLion()
        {
            #region Initialize Variables/Map

            numPlayers = 2;
            requiredVictoryPoints = 1;
            wildlingStrength = 0;
            map = new Map();

            //Impassable regions
            Plot[] Impassable =
            {
                map.Highgarden, map.Oldtown, map.DornishMarches, map.ThreeTowers, map.StormsEnd, map.Sunspear,
                map.Starfall, map.Yronwood, map.PrincesPass, map.Boneway, map.SaltShore
            };

            foreach(Plot p in Impassable)
            {
                p.isImpassable = true;
            }

            #endregion Initialize Variables

            #region Initialize Factions

            //Faction 1
            Faction Lannister = new Faction();
            Lannister.name = "House Lannister";
            Lannister.adjective = "Lannister";
            Lannister.houseCards = new HouseCard[]
            {
                new HouseCard("Cersei Lannister", 0, 0, 0),
                new HouseCard("Tyrion Lannister", 1, 0, 0),
                new HouseCard("Ser Kevan Lannister", 1, 0, 0),
                new HouseCard("The Hound", 2, 0, 2),
                new HouseCard("Ser Jaime Lannister", 2, 1, 0),
                new HouseCard("Ser Gregor Clegane", 3, 3, 0),
                new HouseCard("Tywin Lannister", 4, 0, 0)
            };

            Lannister.factionCapitol = map.Lannisport;

            Lannister.addPlot(map.Lannisport);
            Lannister.addPlot(map.StoneySept);

            map.Lannisport.units.Add(new Unit(1, Lannister));
            map.Lannisport.units.Add(new Unit(2, Lannister));
            map.StoneySept.units.Add(new Unit(1, Lannister));
            map.GoldenSound.units.Add(new Unit(3, Lannister));

            Lannister.numPowerTokens = 5;
            Lannister.numStarredOrders = 3;
            Lannister.numSupply = 2;
            Lannister.numVictoryPoints = 0;
            Lannister.supplyValues = supplyValues[Lannister.numSupply];

            //Faction 2
            Faction Stark = new Faction();
            Stark.name = "House Stark";
            Stark.adjective = "Stark";
            Stark.houseCards = new HouseCard[]
            {
                new HouseCard("Catelyn Stark", 0, 0, 0),
                new HouseCard("Ser Rodrick Cassel", 1, 0, 2),
                new HouseCard("The Blackfish", 1, 0, 0),
                new HouseCard("Greatjon Umber", 2, 1, 0),
                new HouseCard("Roose Bolton", 2, 0, 0),
                new HouseCard("Robb Stark", 3, 0, 0),
                new HouseCard("Eddard Stark", 4, 2, 0)
            };

            Stark.factionCapitol = map.Winterfell;

            Stark.addPlot(map.Winterfell);
            Stark.addPlot(map.StonyShore);

            map.Winterfell.units.Add(new Unit(2, Stark));
            map.Winterfell.units.Add(new Unit(1, Stark));
            map.StonyShore.units.Add(new Unit(1, Stark));
            map.BayOfIce.units.Add(new Unit(3, Stark));

            Stark.numPowerTokens = 5;
            Stark.numStarredOrders = 3;
            Stark.numSupply = 2;
            Stark.numVictoryPoints = 0;
            Stark.supplyValues = supplyValues[Stark.numSupply];

            factions = new Faction[] { Lannister, Stark };

            #endregion Initialize Factions

            #region Influence Tracks

            IronThroneTrack = new Faction[] { Lannister, Stark };
            MessengerRavenTrack = new Faction[] { Stark, Lannister };
            ValyrianBladeTrack = new Faction[] { Stark, Lannister };

            #endregion Influence Tracks

        }
        */

    }
}
