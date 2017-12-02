namespace GotCompanion
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tlp_frmMain = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NewGame = new System.Windows.Forms.Button();
            this.btn_LoadGame = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.tlp_frmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_frmMain
            // 
            this.tlp_frmMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tlp_frmMain.AutoSize = true;
            this.tlp_frmMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tlp_frmMain.BackgroundImage")));
            this.tlp_frmMain.ColumnCount = 1;
            this.tlp_frmMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_frmMain.Controls.Add(this.btn_NewGame, 0, 1);
            this.tlp_frmMain.Controls.Add(this.btn_LoadGame, 0, 2);
            this.tlp_frmMain.Controls.Add(this.btnOptions, 0, 3);
            this.tlp_frmMain.Location = new System.Drawing.Point(12, 12);
            this.tlp_frmMain.Name = "tlp_frmMain";
            this.tlp_frmMain.RowCount = 5;
            this.tlp_frmMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_frmMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_frmMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_frmMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_frmMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_frmMain.Size = new System.Drawing.Size(743, 546);
            this.tlp_frmMain.TabIndex = 0;
            // 
            // btn_NewGame
            // 
            this.btn_NewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_NewGame.Location = new System.Drawing.Point(246, 138);
            this.btn_NewGame.Name = "btn_NewGame";
            this.btn_NewGame.Size = new System.Drawing.Size(250, 50);
            this.btn_NewGame.TabIndex = 0;
            this.btn_NewGame.Text = "New Game";
            this.btn_NewGame.UseVisualStyleBackColor = true;
            this.btn_NewGame.Click += new System.EventHandler(this.btn_NewGame_Click);
            // 
            // btn_LoadGame
            // 
            this.btn_LoadGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_LoadGame.Location = new System.Drawing.Point(246, 247);
            this.btn_LoadGame.Name = "btn_LoadGame";
            this.btn_LoadGame.Size = new System.Drawing.Size(250, 50);
            this.btn_LoadGame.TabIndex = 1;
            this.btn_LoadGame.Text = "Load Game";
            this.btn_LoadGame.UseVisualStyleBackColor = true;
            this.btn_LoadGame.Click += new System.EventHandler(this.btn_LoadGame_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOptions.Location = new System.Drawing.Point(246, 356);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(250, 50);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 570);
            this.Controls.Add(this.tlp_frmMain);
            this.Name = "frmMain";
            this.Text = "Game of Thrones";
            this.tlp_frmMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_frmMain;
        private System.Windows.Forms.Button btn_NewGame;
        private System.Windows.Forms.Button btn_LoadGame;
        private System.Windows.Forms.Button btnOptions;
    }
}

