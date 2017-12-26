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
    public partial class frmMessengerRaven : Form
    {
        Order newOrder;
        Plot pickedPlot;

        Order bannedOrder;
        Faction fac;
        Scenario game;

        int numStars;
        int numStarredPlaced;

        public frmMessengerRaven(Scenario game, Faction fac, Order banned)
        {
            InitializeComponent();

            this.game = game;
            this.fac = fac;
            bannedOrder = banned;

            numStars = fac.numStarredOrders;
            numStarredPlaced = 0;

            btn_ConsolidatePower1.Enabled = false;
            btn_ConsolidatePower2.Enabled = false;
            btn_ConsolidatePower3.Enabled = false;
            btn_Defense1.Enabled = false;
            btn_Defense2.Enabled = false;
            btn_Defense3.Enabled = false;
            btn_Finish.Enabled = false;
            btn_March1.Enabled = false;
            btn_March2.Enabled = false;
            btn_March3.Enabled = false;
            btn_Raid1.Enabled = false;
            btn_Raid2.Enabled = false;
            btn_Raid3.Enabled = false;
            btn_Support1.Enabled = false;
            btn_Support2.Enabled = false;
            btn_Support3.Enabled = false;

            btn_Pass.Enabled = true;

            foreach(Plot p in game.map.MapPlots)
            {
                if(p.order != null && p.owner == fac)
                {
                    cbo_Plots.Items.Add(p.name);
                    if (p.order.isStarred) numStarredPlaced++;
                }
            }

            label_StarredOrders.Text = "Starred Orders: (" + numStarredPlaced + "/" + numStars + ")";

        }

        private void cbo_Plots_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Plot p in game.map.MapPlots)
            {
                if(p.name.Equals(cbo_Plots.Text))
                {
                    pickedPlot = p;
                    break;
                }
            }

            #region Activate Reserve Orders

            if (fac.OrderSet[0].location == null && CanPlaceStarred()) btn_Defense3.Enabled = true;
            else btn_Defense3.Enabled = false;

            if (fac.OrderSet[3].location == null && CanPlaceStarred()) btn_March3.Enabled = true;
            else btn_March3.Enabled = false;

            if (fac.OrderSet[6].location == null && CanPlaceStarred()) btn_Support3.Enabled = true;
            else btn_Support3.Enabled = false;

            if (fac.OrderSet[9].location == null && CanPlaceStarred()) btn_Raid3.Enabled = true;
            else btn_Raid3.Enabled = false;

            if (fac.OrderSet[12].location == null && CanPlaceStarred()) btn_ConsolidatePower3.Enabled = true;
            else btn_ConsolidatePower3.Enabled = false;

            if (fac.OrderSet[1].location == null) btn_Defense2.Enabled = true;
            if (fac.OrderSet[2].location == null) btn_Defense1.Enabled = true;

            if (fac.OrderSet[4].location == null) btn_March2.Enabled = true;
            if (fac.OrderSet[5].location == null) btn_March1.Enabled = true;

            if (fac.OrderSet[7].location == null) btn_Support2.Enabled = true;
            if (fac.OrderSet[8].location == null) btn_Support1.Enabled = true;

            if (fac.OrderSet[10].location == null) btn_Raid2.Enabled = true;
            if (fac.OrderSet[11].location == null) btn_Raid1.Enabled = true;

            if (fac.OrderSet[13].location == null) btn_ConsolidatePower2.Enabled = true;
            if (fac.OrderSet[14].location == null) btn_ConsolidatePower1.Enabled = true;

            #endregion Activate Reserve Orders

            //Ban certain orders
            if (bannedOrder == null)
            {
                //do nothing
            }
            else if (bannedOrder.March)
            {
                btn_March3.Enabled = false;
            }
            else if (bannedOrder.Defense)
            {
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
            }
            else if (bannedOrder.Raid)
            {
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
            }
            else if (bannedOrder.ConsolidatePower)
            {
                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
            }
            else if (bannedOrder.Support)
            {
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            else throw new Exception("Invalid Order is being banned this round!");
        }

        private bool CanPlaceStarred()
        {
            if (pickedPlot.order.isStarred) return true;
            else
            {
                if (numStars > numStarredPlaced) return true;
                else return false;
            }
        }

        private void PerformStandardUIButtonAction()
        {
            btn_ConsolidatePower1.Enabled = false;
            btn_ConsolidatePower2.Enabled = false;
            btn_ConsolidatePower3.Enabled = false;
            btn_Defense1.Enabled = false;
            btn_Defense2.Enabled = false;
            btn_Defense3.Enabled = false;
            btn_Pass.Enabled = false;
            btn_March1.Enabled = false;
            btn_March2.Enabled = false;
            btn_March3.Enabled = false;
            btn_Raid1.Enabled = false;
            btn_Raid2.Enabled = false;
            btn_Raid3.Enabled = false;
            btn_Support1.Enabled = false;
            btn_Support2.Enabled = false;
            btn_Support3.Enabled = false;

            btn_Finish.Enabled = true;
        }

        private void btn_Pass_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
        }

        private void btn_Defense1_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[2]);
        }

        private void btn_Defense2_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[1]);
        }

        private void btn_Defense3_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[0]);
        }

        private void btn_March1_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[5]);
        }

        private void btn_March2_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[4]);
        }

        private void btn_March3_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[3]);
        }

        private void btn_Support1_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[8]);
        }

        private void btn_Support2_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[7]);
        }

        private void btn_Support3_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[6]);
        }

        private void btn_Raid1_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[11]);
        }

        private void btn_Raid2_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[10]);
        }

        private void btn_Raid3_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[9]);
        }

        private void btn_ConsolidatePower1_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[14]);
        }

        private void btn_ConsolidatePower2_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[13]);
        }

        private void btn_ConsolidatePower3_Click(object sender, EventArgs e)
        {
            PerformStandardUIButtonAction();
            pickedPlot.addOrder(fac.OrderSet[12]);
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
