namespace Server_Browser
{
    partial class ServerBrowser
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnTS = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DEBUG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.Players,
            this.Map,
            this.Password});
            this.dataGrid.Location = new System.Drawing.Point(43, 89);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(592, 221);
            this.dataGrid.TabIndex = 1;
            // 
            // ServerName
            // 
            this.ServerName.Frozen = true;
            this.ServerName.HeaderText = "Name";
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            this.ServerName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ServerName.Width = 400;
            // 
            // Players
            // 
            this.Players.Frozen = true;
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Players.ToolTipText = "Players on the server";
            this.Players.Width = 70;
            // 
            // Map
            // 
            this.Map.Frozen = true;
            this.Map.HeaderText = "Map";
            this.Map.Name = "Map";
            this.Map.ReadOnly = true;
            this.Map.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Map.ToolTipText = "the current map";
            this.Map.Width = 90;
            // 
            // Password
            // 
            this.Password.Frozen = true;
            this.Password.HeaderText = "PW";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Password.Width = 30;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(626, 391);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(42, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "about";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnTS
            // 
            this.btnTS.Location = new System.Drawing.Point(12, 391);
            this.btnTS.Name = "btnTS";
            this.btnTS.Size = new System.Drawing.Size(31, 23);
            this.btnTS.TabIndex = 3;
            this.btnTS.Text = "TS";
            this.btnTS.UseMnemonic = false;
            this.btnTS.UseVisualStyleBackColor = true;
            this.btnTS.Click += new System.EventHandler(this.btnTS_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(289, 316);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ServerBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 426);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnTS);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.button1);
            this.Name = "ServerBrowser";
            this.Text = "Mini\'s Inc Server Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnTS;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Map;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Password;
    }
}

