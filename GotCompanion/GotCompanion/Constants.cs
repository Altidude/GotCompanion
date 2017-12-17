using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotCompanion
{
    #region Game Board

    public class Plot
    {
        public string name;
        public int fort;
        public int supply;
        public int power;
        public int garrison;

        public bool isLand;
        public bool isImpassable;

        public Faction owner;

        public Plot[] adjacentLand;
        public Plot[] adjacentSea;

        public List<Unit> units;
        public Order order;

        public Plot(string name, int fort, int supply, int power, bool isLand)
        {
            this.name = name;
            this.fort = fort;
            this.supply = supply;
            this.power = power;
            this.isLand = isLand;

            //Default Values
            isImpassable = false;
            garrison = 0;

            owner = null;
            adjacentLand = adjacentSea = null;
            units = null;
            order = null;

            units = new List<Unit>();

        }

        /// <summary>
        /// Attempts to add a unit to the plot. If this is not compliant with supply, it will not be done and return false.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool addUnit(Unit u, Map map)
        {
            //TODO: Add method to check supply compliance ahead of time to ensure that any change in units will be the cause of supply error

            List<int> armies = new List<int>();

            foreach (Plot p in map.MapPlots)
            {
                if ((p.owner == this.owner) && p.units.Count > 1)
                {
                    if (p == this) armies.Add(p.units.Count + 1);
                    else armies.Add(p.units.Count);
                }
            }

            armies.Sort();
            int[] sizes = new int[armies.Count];
            int[] supplies = u.owner.supplyValues;

            for (int i = 0; i < armies.Count; i++)
            {
                sizes[armies.Count - 1 - i] = armies.ElementAt<int>(i);
            }

            //Compare unit values
            for (int j = 0; j < sizes.Length; j++)
            {
                if (sizes[j] > supplies[j]) return false;
            }

            //If everything compliant, add the unit to the plot
            this.units.Add(u);
            return true;
        }


    }

    public class Map
    {
        //Declare all plots on the map
        public Plot Arbor, Blackwater, Boneway, CastleBlack, CrackclawPoint, DornishMarches, Dragonstone, Eyrie, Fingers, FlintsFinger,
            GreywaterWatch, Harrenhal, Highgarden, Karhold, KingsLanding, Kingswood, Lannisport, MoatCailin, MoonMountains, Oldtown,
            PrincesPass, Pyke, Reach, Riverrun, SaltShore, Seagard, SearoadMarches, Starfall, StoneySept, StonyShore, StormsEnd, Sunspear,
            ThreeTowers, Twins, WhiteHarbor, WidowsWatch, Winterfell, Yronwood, BayOfIce, BlackwaterBay, EastSummerSea, GoldenSound, IronmansBay,
            NarrowSea, RedwyneStraights, SeaOfDorne, ShipbreakerBay, ShiveringSea, SunsetSea, WestSummerSea;

        public Plot[] MapPlots;
        public Plot[] Ports;

        public Map()
        {
            Arbor = new Plot("The Arbor", 0, 0, 1, true);
            Blackwater = new Plot("Blackwater", 0, 2, 0, true);
            Boneway = new Plot("The Boneway", 0, 0, 1, true);
            CastleBlack = new Plot("Castle Black", 0, 0, 1, true);
            CrackclawPoint = new Plot("Crackclaw Point", 1, 0, 0, true);
            DornishMarches = new Plot("Dornish Marches", 0, 0, 1, true);
            Dragonstone = new Plot("Dragonstone", 2, 1, 1, true); //has port
            Eyrie = new Plot("The Eyrie", 1, 1, 1, true);
            Fingers = new Plot("The Fingers", 0, 1, 0, true);
            FlintsFinger = new Plot("Flint's Finger", 1, 0, 0, true);
            GreywaterWatch = new Plot("Greywater Watch", 0, 1, 0, true);
            Harrenhal = new Plot("Harrenhal", 1, 0, 1, true);
            Highgarden = new Plot("Highgarden", 2, 2, 0, true);
            Karhold = new Plot("Karhold", 0, 0, 1, true);
            KingsLanding = new Plot("King's Landing", 2, 0, 2, true);
            Kingswood = new Plot("The Kingswood", 0, 1, 1, true);
            Lannisport = new Plot("Lannisport", 2, 2, 0, true); //has port
            MoatCailin = new Plot("Moat Cailin", 1, 0, 0, true);
            MoonMountains = new Plot("The Mountains of the Moon", 0, 1, 0, true);
            Oldtown = new Plot("Oldtown", 2, 0, 0, true); //has port
            PrincesPass = new Plot("Prince's Pass", 0, 1, 1, true);
            Pyke = new Plot("Pyke", 2, 1, 1, true); //has port
            Reach = new Plot("The Reach", 1, 0, 0, true);
            Riverrun = new Plot("Riverrun", 2, 1, 1, true);
            SaltShore = new Plot("Salt Shore", 0, 1, 0, true);
            Seagard = new Plot("Seagard", 2, 1, 1, true);
            SearoadMarches = new Plot("Searoad Marches", 0, 1, 0, true);
            Starfall = new Plot("Starfall", 1, 1, 0, true);
            StoneySept = new Plot("Stoney Sept", 0, 0, 1, true);
            StonyShore = new Plot("The Stony Shore", 0, 1, 0, true);
            StormsEnd = new Plot("Storm's End", 1, 0, 0, true); //has port
            Sunspear = new Plot("Sunspear", 2, 1, 1, true); //has port
            ThreeTowers = new Plot("Three Towers", 0, 1, 0, true);
            Twins = new Plot("The Twins", 0, 0, 1, true);
            WhiteHarbor = new Plot("White Harbor", 1, 0, 0, true); //has port
            WidowsWatch = new Plot("Widow's Watch", 0, 1, 0, true);
            Winterfell = new Plot("Winterfell", 2, 1, 1, true); //has port
            Yronwood = new Plot("Yronwood", 1, 0, 0, true);

            BayOfIce = new Plot("Bay of Ice", 0, 0, 0, false);
            BlackwaterBay = new Plot("Blackwater Bay", 0, 0, 0, false);
            EastSummerSea = new Plot("East Summer Sea", 0, 0, 0, false);
            GoldenSound = new Plot("The Golden Sound", 0, 0, 0, false);
            IronmansBay = new Plot("Ironman's Bay", 0, 0, 0, false);
            NarrowSea = new Plot("The Narrow Sea", 0, 0, 0, false);
            RedwyneStraights = new Plot("Redwyne Straights", 0, 0, 0, false);
            SeaOfDorne = new Plot("The Sea of Dorne", 0, 0, 0, false);
            ShipbreakerBay = new Plot("Shipbreaker Bay", 0, 0, 0, false);
            ShiveringSea = new Plot("The Shivering Sea", 0, 0, 0, false);
            SunsetSea = new Plot("Sunset Sea", 0, 0, 0, false);
            WestSummerSea = new Plot("West Summer Sea", 0, 0, 0, false);

            initializeMapRoutes();

            MapPlots = new Plot[]{
                Arbor, Blackwater, Boneway, CastleBlack, CrackclawPoint, DornishMarches, Dragonstone, Eyrie, Fingers, FlintsFinger,
                GreywaterWatch, Harrenhal, Highgarden, Karhold, KingsLanding, Kingswood, Lannisport, MoatCailin, MoonMountains, Oldtown,
                PrincesPass, Pyke, Reach, Riverrun, SaltShore, Seagard, SearoadMarches, Starfall, StoneySept, StonyShore, StormsEnd, Sunspear,
                ThreeTowers, Twins, WhiteHarbor, WidowsWatch, Winterfell, Yronwood, BayOfIce, BlackwaterBay, EastSummerSea, GoldenSound, IronmansBay,
                NarrowSea, RedwyneStraights, SeaOfDorne, ShipbreakerBay, ShiveringSea, SunsetSea, WestSummerSea
            };

            Ports = new Plot[]
            {
                Dragonstone, Lannisport, Oldtown, Pyke, StormsEnd, Sunspear, WhiteHarbor, Winterfell
            };

        }

        //Establishes movement connections between plots
        private void initializeMapRoutes()
        {
            Arbor.adjacentLand = new Plot[] { null };
            Arbor.adjacentSea = new Plot[] { RedwyneStraights, WestSummerSea };

            Blackwater.adjacentLand = new Plot[] { StoneySept, Harrenhal, CrackclawPoint, KingsLanding, Reach, SearoadMarches };
            Blackwater.adjacentSea = new Plot[] { null };

            Boneway.adjacentLand = new Plot[] { Yronwood, PrincesPass, DornishMarches, Reach, Kingswood, StormsEnd };
            Boneway.adjacentSea = new Plot[] { SeaOfDorne };

            CastleBlack.adjacentLand = new Plot[] { Karhold, Winterfell };
            CastleBlack.adjacentSea = new Plot[] { BayOfIce, ShiveringSea };

            CrackclawPoint.adjacentLand = new Plot[] { KingsLanding, Blackwater, Harrenhal, MoonMountains };
            CrackclawPoint.adjacentSea = new Plot[] { NarrowSea, ShipbreakerBay, BlackwaterBay };

            DornishMarches.adjacentLand = new Plot[] { Reach, Boneway, PrincesPass, ThreeTowers, Oldtown, Highgarden };
            DornishMarches.adjacentSea = new Plot[] { null };

            Dragonstone.adjacentLand = new Plot[] { null };
            Dragonstone.adjacentSea = new Plot[] { ShipbreakerBay };

            Eyrie.adjacentLand = new Plot[] { MoonMountains };
            Eyrie.adjacentSea = new Plot[] { NarrowSea };

            Fingers.adjacentLand = new Plot[] { Twins, MoonMountains };
            Fingers.adjacentSea = new Plot[] { NarrowSea };

            FlintsFinger.adjacentLand = new Plot[] { GreywaterWatch };
            FlintsFinger.adjacentSea = new Plot[] { BayOfIce, SunsetSea, IronmansBay };

            GreywaterWatch.adjacentLand = new Plot[] { FlintsFinger, Seagard, MoatCailin };
            GreywaterWatch.adjacentSea = new Plot[] { BayOfIce, IronmansBay };

            Harrenhal.adjacentLand = new Plot[] { Riverrun, StoneySept, Blackwater, CrackclawPoint };
            Harrenhal.adjacentSea = new Plot[] { null };

            Highgarden.adjacentLand = new Plot[] { SearoadMarches, Reach, DornishMarches, Oldtown };
            Highgarden.adjacentSea = new Plot[] { RedwyneStraights, WestSummerSea };

            Karhold.adjacentLand = new Plot[] { CastleBlack, Winterfell };
            Karhold.adjacentSea = new Plot[] { ShiveringSea };

            KingsLanding.adjacentLand = new Plot[] { CrackclawPoint, Blackwater, Reach, Kingswood };
            KingsLanding.adjacentSea = new Plot[] { BlackwaterBay };

            Kingswood.adjacentLand = new Plot[] { KingsLanding, Reach, Boneway, StormsEnd };
            Kingswood.adjacentSea = new Plot[] { BlackwaterBay, ShipbreakerBay };

            Lannisport.adjacentLand = new Plot[] { Riverrun, StoneySept, SearoadMarches };
            Lannisport.adjacentSea = new Plot[] { GoldenSound };

            MoatCailin.adjacentLand = new Plot[] { WhiteHarbor, Winterfell, GreywaterWatch, Seagard, Twins };
            MoatCailin.adjacentSea = new Plot[] { NarrowSea };

            MoonMountains.adjacentLand = new Plot[] { Twins, Fingers, Eyrie, CrackclawPoint };
            MoonMountains.adjacentSea = new Plot[] { NarrowSea };

            Oldtown.adjacentLand = new Plot[] { Highgarden, DornishMarches, ThreeTowers };
            Oldtown.adjacentSea = new Plot[] { RedwyneStraights };

            PrincesPass.adjacentLand = new Plot[] { ThreeTowers, DornishMarches, Boneway, Yronwood, Starfall };
            PrincesPass.adjacentSea = new Plot[] { null };

            Pyke.adjacentLand = new Plot[] { null };
            Pyke.adjacentSea = new Plot[] { IronmansBay };

            Reach.adjacentLand = new Plot[] { Highgarden, SearoadMarches, Blackwater, KingsLanding, Kingswood, Boneway, DornishMarches };
            Reach.adjacentSea = new Plot[] { null };

            Riverrun.adjacentLand = new Plot[] { Seagard, Harrenhal, StoneySept, Lannisport };
            Riverrun.adjacentSea = new Plot[] { GoldenSound, IronmansBay };

            SaltShore.adjacentLand = new Plot[] { Starfall, Yronwood, Sunspear };
            SaltShore.adjacentSea = new Plot[] { EastSummerSea };

            Seagard.adjacentLand = new Plot[] { Riverrun, Twins, MoatCailin, GreywaterWatch };
            Seagard.adjacentSea = new Plot[] { IronmansBay };

            SearoadMarches.adjacentLand = new Plot[] { Lannisport, StoneySept, Blackwater, Reach, Highgarden };
            SearoadMarches.adjacentSea = new Plot[] { GoldenSound, SunsetSea, WestSummerSea };

            Starfall.adjacentLand = new Plot[] { PrincesPass, Yronwood, SaltShore };
            Starfall.adjacentSea = new Plot[] { EastSummerSea, WestSummerSea };

            StoneySept.adjacentLand = new Plot[] { Lannisport, Riverrun, Harrenhal, Blackwater, SearoadMarches };
            StoneySept.adjacentSea = new Plot[] { null };

            StonyShore.adjacentLand = new Plot[] { Winterfell };
            StonyShore.adjacentSea = new Plot[] { BayOfIce };

            StormsEnd.adjacentLand = new Plot[] { Boneway, Kingswood };
            StormsEnd.adjacentSea = new Plot[] { EastSummerSea, SeaOfDorne, ShipbreakerBay };

            Sunspear.adjacentLand = new Plot[] { SaltShore, Yronwood };
            Sunspear.adjacentSea = new Plot[] { SeaOfDorne, EastSummerSea };

            ThreeTowers.adjacentLand = new Plot[] { Oldtown, DornishMarches, PrincesPass };
            ThreeTowers.adjacentSea = new Plot[] { RedwyneStraights, WestSummerSea };

            Twins.adjacentLand = new Plot[] { MoatCailin, Seagard, Fingers, MoonMountains };
            Twins.adjacentSea = new Plot[] { NarrowSea };

            WhiteHarbor.adjacentLand = new Plot[] { Winterfell, WidowsWatch, MoatCailin };
            WhiteHarbor.adjacentSea = new Plot[] { NarrowSea, ShiveringSea };

            WidowsWatch.adjacentLand = new Plot[] { WhiteHarbor };
            WidowsWatch.adjacentSea = new Plot[] { NarrowSea, ShiveringSea };

            Winterfell.adjacentLand = new Plot[] { CastleBlack, Karhold, WhiteHarbor, MoatCailin, StonyShore };
            Winterfell.adjacentSea = new Plot[] { BayOfIce, ShiveringSea };

            Yronwood.adjacentLand = new Plot[] { Boneway, PrincesPass, Starfall, SaltShore, Sunspear };
            Yronwood.adjacentSea = new Plot[] { SeaOfDorne };

            //Begin water bodies
            BayOfIce.adjacentLand = new Plot[] { CastleBlack, Winterfell, StonyShore, GreywaterWatch, FlintsFinger };
            BayOfIce.adjacentSea = new Plot[] { SunsetSea };

            BlackwaterBay.adjacentLand = new Plot[] { CrackclawPoint, KingsLanding, Kingswood };
            BlackwaterBay.adjacentSea = new Plot[] { ShipbreakerBay };

            EastSummerSea.adjacentLand = new Plot[] { StormsEnd, Sunspear, SaltShore, Starfall };
            EastSummerSea.adjacentSea = new Plot[] { ShipbreakerBay, SeaOfDorne, WestSummerSea };

            GoldenSound.adjacentLand = new Plot[] { Riverrun, Lannisport, SearoadMarches };
            GoldenSound.adjacentSea = new Plot[] { IronmansBay, SunsetSea };

            IronmansBay.adjacentLand = new Plot[] { Pyke, FlintsFinger, GreywaterWatch, Seagard, Riverrun };
            IronmansBay.adjacentSea = new Plot[] { GoldenSound, SunsetSea };

            NarrowSea.adjacentLand = new Plot[] { WidowsWatch, WhiteHarbor, MoatCailin, Twins, Fingers, MoonMountains, Eyrie, CrackclawPoint };
            NarrowSea.adjacentSea = new Plot[] { ShiveringSea, ShipbreakerBay };

            RedwyneStraights.adjacentLand = new Plot[] { Arbor, Highgarden, Oldtown, ThreeTowers };
            RedwyneStraights.adjacentSea = new Plot[] { WestSummerSea };

            SeaOfDorne.adjacentLand = new Plot[] { StormsEnd, Boneway, Yronwood, Sunspear };
            SeaOfDorne.adjacentSea = new Plot[] { EastSummerSea };

            ShipbreakerBay.adjacentLand = new Plot[] { Dragonstone, CrackclawPoint, Kingswood, StormsEnd };
            ShipbreakerBay.adjacentSea = new Plot[] { BlackwaterBay, NarrowSea, EastSummerSea };

            ShiveringSea.adjacentLand = new Plot[] { CastleBlack, Karhold, WidowsWatch, Winterfell, WhiteHarbor };
            ShiveringSea.adjacentSea = new Plot[] { NarrowSea };

            SunsetSea.adjacentLand = new Plot[] { FlintsFinger, SearoadMarches };
            SunsetSea.adjacentSea = new Plot[] { BayOfIce, IronmansBay, GoldenSound, WestSummerSea };

            WestSummerSea.adjacentLand = new Plot[] { SearoadMarches, Highgarden, Arbor, ThreeTowers, Starfall };
            WestSummerSea.adjacentSea = new Plot[] { EastSummerSea, RedwyneStraights, SunsetSea };
        }

    }



    #endregion Game Board

    #region Factions

    public class Faction
    {
        public string name;
        public string adjective;

        public int numSupply;
        public int numPowerTokens;
        public int numVictoryPoints;
        public int numStarredOrders;
        public int numCastles;

        public int[] supplyValues = { 2, 2 };
        public HouseDeck houseCards;
        public Order[] OrderSet;

        public Plot factionCapitol = null;

        public Faction()
        {
            numSupply = numPowerTokens = numVictoryPoints = numStarredOrders = 0;

            OrderSet = new Order[]
            {
                new Order(1, 2, true), new Order(1, 1, false), new Order(1, 1, false),
                new Order(2, 1, true), new Order(2, 0, false), new Order(2, -1, false),
                new Order(3, 1, true), new Order(3, 0, false), new Order(3, 0, false),
                new Order(4, 0, true), new Order(4, 0, false), new Order(4, 0, false),
                new Order(5, 0, true), new Order(5, 0, false), new Order(5, 0, false)
            };

        }

        /// <summary>
        /// Adds the plot to the faction's control
        /// </summary>
        /// <param name="p"></param>
        public void addPlot(Plot p)
        {
            p.owner = this;
        }

        public void updateVictoryPoints(Scenario game)
        {
            if (this.factionCapitol.owner != this) return;

            foreach (Faction f in game.factions)
            {
                if (f.factionCapitol != this.factionCapitol && f.factionCapitol.owner == this) numVictoryPoints++;
            }

            if (game.map.KingsLanding.owner == this) numVictoryPoints++;
        }

        public void updateSupply(Scenario game)
        {
            int supply = 0;
            foreach (Plot p in game.map.MapPlots)
            {
                if (p.owner == this) supply += p.supply;
            }
            numSupply = supply;

            int index = numSupply;
            if (numSupply > 6) index = 6;
            supplyValues = game.supplyValues[index];
        }

        public void updateCastles(Scenario game)
        {
            int castles = 0;
            foreach (Plot p in game.map.MapPlots)
            {
                if (p.fort > 0 && p.owner == this) castles++;
            }
            numCastles = castles;
        }

    }



    #endregion Factions

    #region Game Pieces

    public class Unit
    {
        public int strength; //normal combat strength
        public int siegepower; //combat strength when attacking castle/stronghold
        public int unitId;

        //Note: unitId
        // 1 - Footman, 2 - Knight, 3 - Ship, 4 - SiegeTower

        public bool isRouted;
        public bool Footman, Knight, Ship, SiegeTower;
        public Faction owner;

        public Unit(int unitConstant, Faction owner)
        {
            this.owner = owner;
            isRouted = false;

            Footman = Knight = Ship = SiegeTower = false;
            unitId = unitConstant; //Determines type of unit

            switch (unitId)
            {
                case 1:
                    Footman = true;
                    strength = 1;
                    siegepower = 1;

                    break;
                case 2:
                    Knight = true;
                    strength = 2;
                    siegepower = 2;

                    break;
                case 3:
                    Ship = true;
                    strength = 1;
                    siegepower = 1;

                    break;
                case 4:
                    SiegeTower = true;
                    strength = 0;
                    siegepower = 4;

                    break;
                default: throw new Exception("Invalid UnitID entered.");
            }

        }

    }

    public class Order
    {
        public int strength;
        public Plot location;
        public bool isStarred;
        public int orderId;
        //Note: orderId
        // 1 - Defense, 2 - March, 3 - Support, 4 - Raid, 5 - ConsolidatePower

        public bool Defense, March, Support, Raid, ConsolidatePower;

        public Order(int id, int str, bool starred)
        {
            orderId = id;
            isStarred = starred;

            Defense = March = Support = Raid = ConsolidatePower = false;
            strength = 0;

            switch (orderId)
            {
                case 1:
                    Defense = true;
                    strength = str;
                    break;
                case 2:
                    March = true;
                    strength = str;
                    break;
                case 3:
                    Support = true;
                    strength = str;
                    break;
                case 4:
                    Raid = true;
                    break;
                case 5:
                    ConsolidatePower = true;
                    break;
                default: throw new Exception("Invalid OrderID entered.");
            }
        }

        public string ToString()
        {
            if (this.ConsolidatePower) return "Consolidate Power";
            if (this.Defense) return "Defense (" + this.strength + ")";
            if (this.March) return "March (" + this.strength + ")";
            if (this.Raid) return "Raid";
            if (this.Support) return "Support (" + this.strength + ")";
            return "";
        }

    }

    #endregion Game Pieces

    #region Cards

    public class HouseCard
    {
        public string name;
        public int combatStrength;
        public int numSwords;
        public int numTowers;
        public bool discarded;

        public HouseCard(string name, int combatStrength, int numSwords, int numTowers)
        {
            this.name = name;
            this.combatStrength = combatStrength;
            this.numSwords = numSwords;
            this.numTowers = numTowers;
            discarded = false;
        }
    }

    public class HouseDeck
    {
        public HouseCard[] cards;

        public HouseDeck(string house)
        {
            switch (house)
            {
                case "Lannister":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Cersei Lannister", 0, 0, 0),
                            new HouseCard("Tyrion Lannister", 1, 0, 0),
                            new HouseCard("Ser Kevan Lannister", 1, 0, 0),
                            new HouseCard("The Hound", 2, 0, 2),
                            new HouseCard("Ser Jaime Lannister", 2, 1, 0),
                            new HouseCard("Ser Gregor Clegane", 3, 3, 0),
                            new HouseCard("Tywin Lannister", 4, 0, 0)
                    };
                    break;

                case "Stark":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Catelyn Stark", 0, 0, 0),
                            new HouseCard("Ser Rodrick Cassel", 1, 0, 2),
                            new HouseCard("The Blackfish", 1, 0, 0),
                            new HouseCard("Greatjon Umber", 2, 1, 0),
                            new HouseCard("Roose Bolton", 2, 0, 0),
                            new HouseCard("Robb Stark", 3, 0, 0),
                            new HouseCard("Eddard Stark", 4, 2, 0)
                    };
                    break;

                case "Baratheon":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Patchface", 0, 0, 0),
                            new HouseCard("Salladhor Saan", 1, 0, 0),
                            new HouseCard("Melisandre", 1, 1, 0),
                            new HouseCard("Ser Davos Seaworth", 2, 0, 0),
                            new HouseCard("Brienne of Tarth", 2, 1, 1),
                            new HouseCard("Renly Baratheon", 3, 0, 0),
                            new HouseCard("Stannis Baratheon", 4, 0, 0)
                    };
                    break;

                case "Greyjoy":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Aeron Damphair", 0, 0, 0),
                            new HouseCard("Asha Greyjoy", 1, 0, 0),
                            new HouseCard("Dagmer Cleftjaw", 1, 1, 1),
                            new HouseCard("Theon Greyjoy", 2, 0, 0),
                            new HouseCard("Balon Greyjoy", 2, 0, 0),
                            new HouseCard("Victarion Greyjoy", 3, 0, 0),
                            new HouseCard("Euron Crow's Eye", 4, 1, 0)
                    };
                    break;

                case "Tyrell":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Queen of Thorns", 0, 0, 0),
                            new HouseCard("Margaery Tyrell", 1, 0, 1),
                            new HouseCard("Alester Florent", 1, 0, 1),
                            new HouseCard("Randyll Tarly", 2, 1, 0),
                            new HouseCard("Ser Garlan Tyrell", 2, 2, 0),
                            new HouseCard("Ser Loras Tyrell", 3, 0, 0),
                            new HouseCard("Mace Tyrell", 4, 0, 0)
                    };
                    break;

                case "Martell":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Doran Martell", 0, 0, 0),
                            new HouseCard("Nymeria Sand", 1, 0, 0),
                            new HouseCard("Arianne Martell", 1, 0, 0),
                            new HouseCard("Darkstar", 2 , 1, 0),
                            new HouseCard("Obara Sand", 2 , 1, 0),
                            new HouseCard("Areo Hotah", 3, 0, 1),
                            new HouseCard("The Red Viper", 4, 2, 1)
                    };
                    break;

                case "Arryn":
                    cards = new HouseCard[]
                    {
                            new HouseCard("Lysa Arryn", 0, 0, 0),
                            new HouseCard("Alayne Stone", 1, 0, 0),
                            new HouseCard("Lothor Brune", 1, 1, 1),
                            new HouseCard("Nestor Royce", 2, 0, 2),
                            new HouseCard("Lyn Corbray", 2, 1, 0),
                            new HouseCard("Littlefinger", 3, 0, 0),
                            new HouseCard("Bronze Yohn Royce", 4, 0, 0)
                    };
                    break;

                default: throw new Exception("Invalid house: Cannot build HouseDeck.");
            }
        }
    }

    public class WesterosCard
    {
        public string name;
        public bool moreWildlings;
        public bool discarded;

        public WesterosCard(string name, bool moreWildlings)
        {
            this.name = name;
            this.moreWildlings = moreWildlings;
            discarded = false;
        }
    }

    public class WesterosDeck
    {
        public WesterosCard[] deck1;
        public WesterosCard[] deck2;
        public WesterosCard[] deck3;

        public WesterosDeck(int set)
        {
            switch (set)
            {
                default:
                    deck1 = new WesterosCard[]
                    {
                        new WesterosCard("Last Days of Summer", true),
                        new WesterosCard("Winter is Coming", false),
                        new WesterosCard("Supply", false),
                        new WesterosCard("Supply", false),
                        new WesterosCard("Supply", false),
                        new WesterosCard("Mustering", false),
                        new WesterosCard("Mustering", false),
                        new WesterosCard("Mustering", false),
                        new WesterosCard("A Throne of Blades", true),
                        new WesterosCard("A Throne of Blades", true)
                    };
                    deck2 = new WesterosCard[]
                    {
                        new WesterosCard("Last Days of Summer", true),
                        new WesterosCard("Winter is Coming", false),
                        new WesterosCard("Dark Wings, Dark Words", true),
                        new WesterosCard("Dark Wings, Dark Words", true),
                        new WesterosCard("Game of Thrones", false),
                        new WesterosCard("Game of Thrones", false),
                        new WesterosCard("Game of Thrones", false),
                        new WesterosCard("Clash of Kings", false),
                        new WesterosCard("Clash of Kings", false),
                        new WesterosCard("Clash of Kings", false)
                    };
                    deck3 = new WesterosCard[]
                     {
                        new WesterosCard("Wildlings Attack", false),
                        new WesterosCard("Wildlings Attack", false),
                        new WesterosCard("Wildlings Attack", false),
                        new WesterosCard("Put to the Sword", false),
                        new WesterosCard("Put to the Sword", false),
                        new WesterosCard("Feast for Crows", true),
                        new WesterosCard("Web of Lies", true),
                        new WesterosCard("Sea of Storms", true),
                        new WesterosCard("Storm of Swords", true),
                        new WesterosCard("Rains of Autumn", true)
                     };
                    break;
            }
        }

    }

    public class WildlingCard
    {
        public string name;

        public WildlingCard(string name)
        {
            this.name = name;
        }
    }


    #endregion Cards
}
