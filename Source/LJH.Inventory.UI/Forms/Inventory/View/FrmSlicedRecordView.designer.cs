namespace LJH.Inventory.UI.Forms.Inventory.View
{
    partial class FrmSlicedRecordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlicedRecordView));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.colSlicedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfterLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlicer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 289);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1005, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(990, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "总共 0 项";
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.BackgroundColor = System.Drawing.Color.White;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlicedDateTime,
            this.colCategoryID,
            this.colSpecification,
            this.colSlicedTo,
            this.colBeforeWeight,
            this.colBeforeLength,
            this.colLength,
            this.colWeight,
            this.colAmount,
            this.colTotalWeight,
            this.colTotalLength,
            this.colAfterWeight,
            this.colAfterLength,
            this.colSlicer});
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(0, 0);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.RowTemplate.Height = 23;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(1005, 289);
            this.GridView.TabIndex = 22;
            // 
            // colSlicedDateTime
            // 
            this.colSlicedDateTime.HeaderText = "加工日期";
            this.colSlicedDateTime.Name = "colSlicedDateTime";
            this.colSlicedDateTime.ReadOnly = true;
            // 
            // colCategoryID
            // 
            this.colCategoryID.HeaderText = "类别";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            this.colCategoryID.Visible = false;
            // 
            // colSpecification
            // 
            this.colSpecification.HeaderText = "规格(厚*宽)";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.ReadOnly = true;
            this.colSpecification.Visible = false;
            // 
            // colSlicedTo
            // 
            this.colSlicedTo.HeaderText = "小件类型";
            this.colSlicedTo.Name = "colSlicedTo";
            this.colSlicedTo.ReadOnly = true;
            this.colSlicedTo.Visible = false;
            // 
            // colBeforeWeight
            // 
            this.colBeforeWeight.HeaderText = "加工前重量";
            this.colBeforeWeight.Name = "colBeforeWeight";
            this.colBeforeWeight.ReadOnly = true;
            // 
            // colBeforeLength
            // 
            this.colBeforeLength.HeaderText = "加工前长度";
            this.colBeforeLength.Name = "colBeforeLength";
            this.colBeforeLength.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "小件长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "小件重量";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "加工数量";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colTotalWeight
            // 
            this.colTotalWeight.HeaderText = "加工重量";
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.ReadOnly = true;
            // 
            // colTotalLength
            // 
            this.colTotalLength.HeaderText = "加工长度";
            this.colTotalLength.Name = "colTotalLength";
            this.colTotalLength.ReadOnly = true;
            // 
            // colAfterWeight
            // 
            this.colAfterWeight.HeaderText = "加工后重量";
            this.colAfterWeight.Name = "colAfterWeight";
            this.colAfterWeight.ReadOnly = true;
            // 
            // colAfterLength
            // 
            this.colAfterLength.HeaderText = "加工后长度";
            this.colAfterLength.Name = "colAfterLength";
            this.colAfterLength.ReadOnly = true;
            // 
            // colSlicer
            // 
            this.colSlicer.HeaderText = "加工人员";
            this.colSlicer.Name = "colSlicer";
            this.colSlicer.ReadOnly = true;
            // 
            // FrmSlicedRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 311);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSlicedRecordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "铁皮卷加工记录";
            this.Load += new System.EventHandler(this.FrmSlicedRecords_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        protected System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAfterLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlicer;
    }
}