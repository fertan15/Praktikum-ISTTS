namespace MateriW3
{
    partial class inventory
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
            this.uang = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mys = new System.Windows.Forms.Label();
            this.mah = new System.Windows.Forms.Label();
            this.oak = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diamond = new System.Windows.Forms.RadioButton();
            this.iron = new System.Windows.Forms.RadioButton();
            this.stone = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uang
            // 
            this.uang.AutoSize = true;
            this.uang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uang.Location = new System.Drawing.Point(34, 36);
            this.uang.Name = "uang";
            this.uang.Size = new System.Drawing.Size(86, 32);
            this.uang.TabIndex = 0;
            this.uang.Text = "Uang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mys);
            this.groupBox1.Controls.Add(this.mah);
            this.groupBox1.Controls.Add(this.oak);
            this.groupBox1.Location = new System.Drawing.Point(40, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wood";
            // 
            // mys
            // 
            this.mys.AutoSize = true;
            this.mys.Location = new System.Drawing.Point(23, 146);
            this.mys.Name = "mys";
            this.mys.Size = new System.Drawing.Size(44, 16);
            this.mys.TabIndex = 2;
            this.mys.Text = "label3";
            // 
            // mah
            // 
            this.mah.AutoSize = true;
            this.mah.Location = new System.Drawing.Point(23, 98);
            this.mah.Name = "mah";
            this.mah.Size = new System.Drawing.Size(44, 16);
            this.mah.TabIndex = 1;
            this.mah.Text = "label2";
            // 
            // oak
            // 
            this.oak.AutoSize = true;
            this.oak.Location = new System.Drawing.Point(23, 52);
            this.oak.Name = "oak";
            this.oak.Size = new System.Drawing.Size(44, 16);
            this.oak.TabIndex = 0;
            this.oak.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.diamond);
            this.groupBox2.Controls.Add(this.iron);
            this.groupBox2.Controls.Add(this.stone);
            this.groupBox2.Location = new System.Drawing.Point(379, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 280);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Axes";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // diamond
            // 
            this.diamond.AutoSize = true;
            this.diamond.Location = new System.Drawing.Point(23, 144);
            this.diamond.Name = "diamond";
            this.diamond.Size = new System.Drawing.Size(81, 20);
            this.diamond.TabIndex = 2;
            this.diamond.TabStop = true;
            this.diamond.Text = "diamond";
            this.diamond.UseVisualStyleBackColor = true;
            this.diamond.CheckedChanged += new System.EventHandler(this.diamond_CheckedChanged);
            // 
            // iron
            // 
            this.iron.AutoSize = true;
            this.iron.Location = new System.Drawing.Point(23, 96);
            this.iron.Name = "iron";
            this.iron.Size = new System.Drawing.Size(50, 20);
            this.iron.TabIndex = 1;
            this.iron.TabStop = true;
            this.iron.Text = "Iron";
            this.iron.UseVisualStyleBackColor = true;
            this.iron.CheckedChanged += new System.EventHandler(this.iron_CheckedChanged);
            // 
            // stone
            // 
            this.stone.AutoSize = true;
            this.stone.Location = new System.Drawing.Point(23, 50);
            this.stone.Name = "stone";
            this.stone.Size = new System.Drawing.Size(63, 20);
            this.stone.TabIndex = 0;
            this.stone.TabStop = true;
            this.stone.Text = "Stone";
            this.stone.UseVisualStyleBackColor = true;
            this.stone.CheckedChanged += new System.EventHandler(this.stone_CheckedChanged);
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uang);
            this.Name = "inventory";
            this.Text = "inventory";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label mys;
        private System.Windows.Forms.Label mah;
        private System.Windows.Forms.Label oak;
        private System.Windows.Forms.RadioButton diamond;
        private System.Windows.Forms.RadioButton iron;
        private System.Windows.Forms.RadioButton stone;
    }
}