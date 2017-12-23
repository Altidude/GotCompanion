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
    public partial class frmRevealOrders : Form
    {
        int stars, numOrders, pageNum, index, starsMax;
        Plot[] OrderPlots;
        Order[] OrderSet, OrderList;
        Button[] ClickOrder;

        frmGame gameForm;
        Scenario game;

        public frmRevealOrders(frmGame gameForm, Scenario game, Faction fac)
        {
            InitializeComponent();
            stars = numOrders = pageNum = index = 0;
            starsMax = fac.numStarredOrders;
            OrderSet = fac.OrderSet;
            this.gameForm = gameForm;
            this.game = game;

            //Gather information
            foreach(Plot p in game.map.MapPlots)
            {
                if (p.owner == fac && p.units.Count > 0) numOrders++;
            }

            OrderPlots = new Plot[numOrders];
            OrderList = new Order[numOrders];
            ClickOrder = new Button[numOrders];

            foreach(Plot p in game.map.MapPlots)
            {
                if (p.owner == fac && p.units.Count > 0)
                {
                    OrderPlots[index] = p;
                    index++;
                }
            }

            //Initial Form Setup
            this.Text = fac.name + ": Reveal Orders";
            label_PlotName.Text = OrderPlots[pageNum].name;
            label_StarredOrders.Text = "Starred Orders: (" + stars + "/" + starsMax + ")";
            btn_Next.Visible = btn_Previous.Visible = false;
            
            if(starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }

            
            btn_Finish.Enabled = false;

        }

        private void updateUI()
        {
            try
            {
                label_PlotName.Text = OrderPlots[pageNum].name;
            }catch(Exception e)
            {

            }

            
            label_StarredOrders.Text = "Starred Orders: (" + stars + "/" + starsMax + ")";
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            /*if(btn_Finish.Enabled)
            {
                btn_Finish.Enabled = false;

                btn_ConsolidatePower1.Enabled = true;
                btn_ConsolidatePower2.Enabled = true;
                btn_ConsolidatePower3.Enabled = true;
                btn_Defense1.Enabled = true;
                btn_Defense2.Enabled = true;
                btn_Defense3.Enabled = true;
                btn_March1.Enabled = true;
                btn_March2.Enabled = true;
                btn_March3.Enabled = true;
                btn_Raid1.Enabled = true;
                btn_Raid2.Enabled = true;
                btn_Raid3.Enabled = true;
                btn_Support1.Enabled = true;
                btn_Support2.Enabled = true;
                btn_Support3.Enabled = true;
            }

            for(int i = 0; i < numOrders; i++)
            {
                Button b = ClickOrder[i];
                if (b == null) break;
            }
      
            pageNum--;
            */
            

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {

        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < numOrders; i++)
            {
                OrderPlots[i].addOrder(OrderList[i]);
            }

            Close();
        }

        private void btn_Defense1_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[2];
            ClickOrder[pageNum] = btn_Defense1;
            btn_Defense1.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Defense2_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[1];
            ClickOrder[pageNum] = btn_Defense2;
            btn_Defense2.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Defense3_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[0];
            ClickOrder[pageNum] = btn_Defense3;
            btn_Defense3.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }

            stars++;
            updateUI();

            if (starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }
        }

        private void btn_March1_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[5];
            ClickOrder[pageNum] = btn_March1;
            btn_March1.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_March2_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[4];
            ClickOrder[pageNum] = btn_March2;
            btn_March2.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_March3_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[3];
            ClickOrder[pageNum] = btn_March3;
            btn_March3.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }

            stars++;
            updateUI();

            
            if (starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }

        }

        private void btn_Support1_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[8];
            ClickOrder[pageNum] = btn_Support1;
            btn_Support1.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Support2_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[7];
            ClickOrder[pageNum] = btn_Support2;
            btn_Support2.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Support3_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[6];
            ClickOrder[pageNum] = btn_Support3;
            btn_Support3.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            stars++;
            updateUI();

            if (starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }
        }

        private void btn_Raid1_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[11];
            ClickOrder[pageNum] = btn_Raid1;
            btn_Raid1.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Raid2_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[10];
            ClickOrder[pageNum] = btn_Raid2;
            btn_Raid2.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_Raid3_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[9];
            ClickOrder[pageNum] = btn_Raid3;
            btn_Raid3.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }

            stars++;
            updateUI();

            if (starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }
        }

        private void btn_ConsolidatePower1_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[14];
            ClickOrder[pageNum] = btn_ConsolidatePower1;
            btn_ConsolidatePower1.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_ConsolidatePower2_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[13];
            ClickOrder[pageNum] = btn_ConsolidatePower2;
            btn_ConsolidatePower2.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }
            updateUI();
        }

        private void btn_ConsolidatePower3_Click(object sender, EventArgs e)
        {
            OrderList[pageNum] = OrderSet[12];
            ClickOrder[pageNum] = btn_ConsolidatePower3;
            btn_ConsolidatePower3.Enabled = false;

            pageNum++;
            if (pageNum == numOrders)
            {
                btn_Finish.Enabled = true;

                btn_ConsolidatePower1.Enabled = false;
                btn_ConsolidatePower2.Enabled = false;
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense1.Enabled = false;
                btn_Defense2.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March1.Enabled = false;
                btn_March2.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid1.Enabled = false;
                btn_Raid2.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support1.Enabled = false;
                btn_Support2.Enabled = false;
                btn_Support3.Enabled = false;
            }

            stars++;
            updateUI();

            if (starsMax <= stars)
            {
                btn_ConsolidatePower3.Enabled = false;
                btn_Defense3.Enabled = false;
                btn_March3.Enabled = false;
                btn_Raid3.Enabled = false;
                btn_Support3.Enabled = false;
            }
        }
    }
}
