namespace TrainTracking
{
    partial class AddTrainCat
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtId = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(27, 22);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(92, 18);
            this.radLabel2.TabIndex = 18;
            this.radLabel2.Text = "Train Category Id";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtId.Location = new System.Drawing.Point(144, 21);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(153, 20);
            this.txtId.TabIndex = 17;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(7, 48);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(112, 18);
            this.radLabel3.TabIndex = 20;
            this.radLabel3.Text = "Train Category Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gold;
            this.btnAdd.Location = new System.Drawing.Point(167, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAddTrain_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.radLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 145);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Train Category";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // AddTrainCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 170);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddTrainCat";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Train Category";
            this.Load += new System.EventHandler(this.AddTrainCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtId;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
