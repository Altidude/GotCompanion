using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GotCompanion
{
    public partial class frmGame : Form
    {
        Scenario game;
        Queue<Event> EventBuffer;

        public frmGame(int scenarioId)
        {
            InitializeComponent();

            game = new Scenario(scenarioId);
            displayMapInfo();

            playGame();
        }

        //Main driving method
        private void playGame()
        {
            EventBuffer = new Queue<Event>();
            
            
            #region Initial Form Setup

            label_CurrentEffects.Text = "Current Effects: N/A";
            label_WildlingStrength.Text = "Wildling Strength: " + game.wildlingStrength;
            label_Round.Text = "Round " + game.roundNumber;
            label_Phase.Text = "Planning Phase";

            #region Faction Info Labels
            try
            {
                label_faction1.Text = game.factions[0].name;
                label_faction1_info.Text = "Victory Points: " + game.factions[0].numVictoryPoints
                                            + "\nPower: " + game.factions[0].numPowerTokens
                                            + "\nSupply: " + game.factions[0].numSupply
                                            + "\nCastles: " + game.factions[0].numCastles
                                            + "\nStarred Orders: " + game.factions[0].numStarredOrders;
            }catch(Exception e)
            {
                label_faction1.Text = label_faction1_info.Text = "";
            }

            try
            {
                label_faction2.Text = game.factions[1].name;
                label_faction2_info.Text = "Victory Points: " + game.factions[1].numVictoryPoints
                                            + "\nPower: " + game.factions[1].numPowerTokens
                                            + "\nSupply: " + game.factions[1].numSupply
                                            + "\nCastles: " + game.factions[1].numCastles
                                            + "\nStarred Orders: " + game.factions[1].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction2.Text = label_faction2_info.Text = "";
            }

            try
            {
                label_faction3.Text = game.factions[2].name;
                label_faction3_info.Text = "Victory Points: " + game.factions[2].numVictoryPoints
                                            + "\nPower: " + game.factions[2].numPowerTokens
                                            + "\nSupply: " + game.factions[2].numSupply
                                            + "\nCastles: " + game.factions[2].numCastles
                                            + "\nStarred Orders: " + game.factions[2].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction3.Text = label_faction3_info.Text = "";
            }

            try
            {
                label_faction4.Text = game.factions[3].name;
                label_faction4_info.Text = "Victory Points: " + game.factions[3].numVictoryPoints
                                            + "\nPower: " + game.factions[3].numPowerTokens
                                            + "\nSupply: " + game.factions[3].numSupply
                                            + "\nCastles: " + game.factions[3].numCastles
                                            + "\nStarred Orders: " + game.factions[3].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction4.Text = label_faction4_info.Text = "";
            }

            try
            {
                label_faction5.Text = game.factions[4].name;
                label_faction5_info.Text = "Victory Points: " + game.factions[4].numVictoryPoints
                                            + "\nPower: " + game.factions[4].numPowerTokens
                                            + "\nSupply: " + game.factions[4].numSupply
                                            + "\nCastles: " + game.factions[4].numCastles
                                            + "\nStarred Orders: " + game.factions[4].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction5.Text = label_faction5_info.Text = "";
            }

            try
            {
                label_faction6.Text = game.factions[5].name;
                label_faction6_info.Text = "Victory Points: " + game.factions[5].numVictoryPoints
                                            + "\nPower: " + game.factions[5].numPowerTokens
                                            + "\nSupply: " + game.factions[5].numSupply
                                            + "\nCastles: " + game.factions[5].numCastles
                                            + "\nStarred Orders: " + game.factions[5].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction6.Text = label_faction6_info.Text = "";
            }

            try
            {
                label_faction7.Text = game.factions[6].name;
                label_faction7_info.Text = "Victory Points: " + game.factions[6].numVictoryPoints
                                            + "\nPower: " + game.factions[6].numPowerTokens
                                            + "\nSupply: " + game.factions[6].numSupply
                                            + "\nCastles: " + game.factions[6].numCastles
                                            + "\nStarred Orders: " + game.factions[6].numStarredOrders;
            }
            catch (Exception e)
            {
                label_faction7.Text = label_faction7_info.Text = "";
            }


            #endregion Faction Info Labels

            #endregion Initial Form Setup

            PlanningPhase();
        }

        private void PlanningPhase()
        {
            EventBuffer.Clear();
            EventBuffer.Enqueue(new Event(null, "Place Orders"));

            foreach (Faction f in game.IronThroneTrack)
            {
                EventBuffer.Enqueue(new Event(f, "Reveal Orders"));
                updateEventUI();
            }

            tab_Decision.SelectedIndex = 0;
        }

        public void displayMapInfo()
        {
            Label[] labels =
            {
                label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16,
                label17, label18, label19, label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31,
                label32, label33, label34, label35, label36, label37, label38, label39, label40, label41, label42, label43, label44, label45, label46,
                label47, label48, label49, label50, label51, label52, label53, label54, label55, label56, label57, label58, label59, label60, label61,
                label62, label63, label64, label65, label66, label67, label68, label69, label70, label71, label72, label73, label74, label75, label76,
                label77, label78, label79, label80, label81, label82, label83, label84, label85, label86, label87, label88, label89, label90, label91,
                label92, label93, label94, label95, label96, label97, label98, label99, label100, label101, label102, label103, label104, label105, label106,
                label107, label108, label109, label110, label111, label112, label113, label114, label115, label116, label117, label118, label119, label120, label121,
                label122, label123, label124, label125, label126, label127, label128, label129, label130, label131, label132, label133, label134, label135, label136,
                label137, label138, label139, label140, label141, label142, label143, label144, label145, label146, label147, label148, label149, label150, label151,
                label152, label153, label154, label155, label156, label157, label158, label159, label160, label161, label162, label163, label164, label165, label166,
                label167, label168, label169, label170, label171, label172, label173, label174, label175, label176, label177, label178, label179, label180, label181,
                label182, label183, label184, label185, label186, label187, label188, label189, label190, label191, label192, label193, label194, label195, label196,
                label197, label198, label199, label200, label201, label202, label203, label204
            };

            int footmen, knights, ships, siegetowers;
            int i = 4;

            for (int j = 0; j < game.map.MapPlots.Length; j++)
            {
                Plot p = game.map.MapPlots.ElementAt<Plot>(j);

                labels[i].Text = p.name;

                if (p.owner == null) labels[i + 1].Text = "Neutral";
                else labels[i + 1].Text = p.owner.name;

                footmen = knights = ships = siegetowers = 0;
                foreach (Unit u in p.units)
                {
                    if (u.Footman) footmen++;
                    else if (u.Knight) knights++;
                    else if (u.Ship) ships++;
                    else if (u.SiegeTower) siegetowers++;
                    else throw new Exception("Invalid Unit in " + p.name);
                }
                labels[i + 2].Text = footmen + " Footmen, " + knights + " Knights, " + siegetowers + " Siege Towers, " + ships + " Ships";

                if (p.order == null) labels[i + 3].Text = "None";
                else labels[i + 3].Text = p.order.ToString();

                i += 4;
            }            
        }


        #region Form Methods
        private void updateEventUI()
        {
            if (EventBuffer.Count == 0)
            {
                label_CurrentFaction.Text = "";
                label_CurrentAction.Text = "";
            }
            else
            {
                label_CurrentFaction.Text = EventBuffer.ElementAt<Event>(0).Player.name;
                label_CurrentAction.Text = EventBuffer.ElementAt<Event>(0).Text;
            }
            
            try
            {
                label_Upcoming1.Text = EventBuffer.ElementAt<Event>(1).Player.name + ": " + EventBuffer.ElementAt<Event>(1).Text;
            }
            catch(Exception e)
            {
                label_Upcoming1.Text = "";
            }

            try
            {
                label_Upcoming2.Text = EventBuffer.ElementAt<Event>(2).Player.name + ": " + EventBuffer.ElementAt<Event>(2).Text;
            }
            catch (Exception e)
            {
                label_Upcoming2.Text = "";
            }

            try
            {
                label_Upcoming3.Text = EventBuffer.ElementAt<Event>(3).Player.name + ": " + EventBuffer.ElementAt<Event>(3).Text;
            }
            catch (Exception e)
            {
                label_Upcoming3.Text = "";
            }

            try
            {
                label_Upcoming4.Text = EventBuffer.ElementAt<Event>(4).Player.name + ": " + EventBuffer.ElementAt<Event>(4).Text;
            }
            catch (Exception e)
            {
                label_Upcoming4.Text = "";
            }

            try
            {
                label_Upcoming5.Text = EventBuffer.ElementAt<Event>(5).Player.name + ": " + EventBuffer.ElementAt<Event>(5).Text;
            }
            catch (Exception e)
            {
                label_Upcoming5.Text = "";
            }

            try
            {
                label_Upcoming6.Text = EventBuffer.ElementAt<Event>(6).Player.name + ": " + EventBuffer.ElementAt<Event>(6).Text;
            }
            catch (Exception e)
            {
                label_Upcoming6.Text = "";
            }


        }

        private void frmGame_Load(object sender, EventArgs e)
        {
        }

        private void btn_NextAction_Click(object sender, EventArgs e)
        {
            EventBuffer.Dequeue();
            updateEventUI();
        }
        #endregion Form Methods

        
    }
}
