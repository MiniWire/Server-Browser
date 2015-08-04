namespace Server_Browser
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSonly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DEBUG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.Players,
            this.Map,
            this.HSonly});
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(425, 176);
            this.dataGridView1.TabIndex = 1;
            // 
            // ServerName
            // 
            this.ServerName.Frozen = true;
            this.ServerName.HeaderText = "Name";
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            this.ServerName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ServerName.Width = 200;
            // 
            // Players
            // 
            this.Players.Frozen = true;
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Players.ToolTipText = "Players on the server";
            this.Players.Width = 50;
            // 
            // Map
            // 
            this.Map.Frozen = true;
            this.Map.HeaderText = "Map";
            this.Map.Name = "Map";
            this.Map.ReadOnly = true;
            this.Map.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Map.ToolTipText = "the current map";
            // 
            // HSonly
            // 
            this.HSonly.Frozen = true;
            this.HSonly.HeaderText = "HS";
            this.HSonly.Name = "HSonly";
            this.HSonly.ReadOnly = true;
            this.HSonly.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HSonly.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HSonly.Width = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 426);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Mini\'s Inc Server Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Map;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HSonly;
    }
}

