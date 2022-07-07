
namespace Storage
{
    partial class EditForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonShipper = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonDeleteShipper = new System.Windows.Forms.Button();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.buttonModer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(346, 183);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Who do you want to delete?";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(337, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(18, 20);
            this.buttonBack.TabIndex = 17;
            this.buttonBack.Text = "❌";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonShipper
            // 
            this.buttonShipper.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonShipper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShipper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShipper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShipper.Location = new System.Drawing.Point(12, 52);
            this.buttonShipper.Name = "buttonShipper";
            this.buttonShipper.Size = new System.Drawing.Size(121, 23);
            this.buttonShipper.TabIndex = 18;
            this.buttonShipper.Text = "Shipper";
            this.buttonShipper.UseVisualStyleBackColor = false;
            this.buttonShipper.Click += new System.EventHandler(this.buttonShipper_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClient.Location = new System.Drawing.Point(234, 52);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(121, 23);
            this.buttonClient.TabIndex = 19;
            this.buttonClient.Text = "Client";
            this.buttonClient.UseVisualStyleBackColor = false;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonDeleteShipper
            // 
            this.buttonDeleteShipper.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonDeleteShipper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteShipper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteShipper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteShipper.Location = new System.Drawing.Point(12, 293);
            this.buttonDeleteShipper.Name = "buttonDeleteShipper";
            this.buttonDeleteShipper.Size = new System.Drawing.Size(121, 23);
            this.buttonDeleteShipper.TabIndex = 20;
            this.buttonDeleteShipper.Text = "Delete";
            this.buttonDeleteShipper.UseVisualStyleBackColor = false;
            this.buttonDeleteShipper.Click += new System.EventHandler(this.buttonDeleteShipper_Click);
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonDeleteClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteClient.Location = new System.Drawing.Point(234, 293);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(121, 23);
            this.buttonDeleteClient.TabIndex = 21;
            this.buttonDeleteClient.Text = "Delete";
            this.buttonDeleteClient.UseVisualStyleBackColor = false;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // buttonModer
            // 
            this.buttonModer.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonModer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonModer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonModer.Location = new System.Drawing.Point(12, 12);
            this.buttonModer.Name = "buttonModer";
            this.buttonModer.Size = new System.Drawing.Size(18, 20);
            this.buttonModer.TabIndex = 22;
            this.buttonModer.Text = "❌";
            this.buttonModer.UseVisualStyleBackColor = false;
            this.buttonModer.Click += new System.EventHandler(this.buttonModer_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(370, 345);
            this.Controls.Add(this.buttonModer);
            this.Controls.Add(this.buttonDeleteClient);
            this.Controls.Add(this.buttonDeleteShipper);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonShipper);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonShipper;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonDeleteShipper;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button buttonModer;
    }
}