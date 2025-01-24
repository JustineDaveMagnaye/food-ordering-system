namespace Food_Ordering_System
{
    partial class AddProduct
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Icon = new System.Windows.Forms.PictureBox();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.cb_Status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_FoodName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ProductID = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Icon)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(755, 5);
            this.panel3.TabIndex = 4;
            // 
            // lbl_Icon
            // 
            this.lbl_Icon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_Icon.Location = new System.Drawing.Point(3, 3);
            this.lbl_Icon.Name = "lbl_Icon";
            this.lbl_Icon.Size = new System.Drawing.Size(189, 145);
            this.lbl_Icon.TabIndex = 0;
            this.lbl_Icon.TabStop = false;
            // 
            // cb_Category
            // 
            this.cb_Category.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Items.AddRange(new object[] {
            "Main Dish",
            "Appetizer",
            "Dessert",
            "Drinks",
            "Others"});
            this.cb_Category.Location = new System.Drawing.Point(98, 300);
            this.cb_Category.Name = "cb_Category";
            this.cb_Category.Size = new System.Drawing.Size(267, 28);
            this.cb_Category.TabIndex = 16;
            this.cb_Category.Text = "Choose";
            // 
            // btn_Generate
            // 
            this.btn_Generate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.btn_Generate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Generate.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate.ForeColor = System.Drawing.Color.White;
            this.btn_Generate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Generate.Location = new System.Drawing.Point(300, 266);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(65, 27);
            this.btn_Generate.TabIndex = 15;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = false;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // cb_Status
            // 
            this.cb_Status.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Items.AddRange(new object[] {
            "Available",
            "Unavailable",
            "Out of stock"});
            this.cb_Status.Location = new System.Drawing.Point(98, 399);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(267, 28);
            this.cb_Status.TabIndex = 14;
            this.cb_Status.Text = "Choose";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 28);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Price
            // 
            this.txt_Price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Price.Location = new System.Drawing.Point(98, 366);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(267, 27);
            this.txt_Price.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Food Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_FoodName
            // 
            this.txt_FoodName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FoodName.Location = new System.Drawing.Point(98, 332);
            this.txt_FoodName.Name = "txt_FoodName";
            this.txt_FoodName.Size = new System.Drawing.Size(267, 27);
            this.txt_FoodName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ProductID
            // 
            this.txt_ProductID.Enabled = false;
            this.txt_ProductID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProductID.Location = new System.Drawing.Point(98, 266);
            this.txt_ProductID.Name = "txt_ProductID";
            this.txt_ProductID.Size = new System.Drawing.Size(196, 27);
            this.txt_ProductID.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(112)))), ((int)(((byte)(159)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbl_exit);
            this.panel4.Controls.Add(this.btn_Add);
            this.panel4.Controls.Add(this.cb_Category);
            this.panel4.Controls.Add(this.btn_Generate);
            this.panel4.Controls.Add(this.cb_Status);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txt_Price);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txt_FoodName);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txt_ProductID);
            this.panel4.Controls.Add(this.btn_Browse);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(0, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(381, 493);
            this.panel4.TabIndex = 5;
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.White;
            this.lbl_exit.Location = new System.Drawing.Point(347, 14);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(18, 18);
            this.lbl_exit.TabIndex = 17;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Image = global::Food_Ordering_System.Properties.Resources.icons8_add_18;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(143, 444);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_Add.Size = new System.Drawing.Size(100, 25);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.ForeColor = System.Drawing.Color.White;
            this.btn_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Browse.Location = new System.Drawing.Point(96, 196);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_Browse.Size = new System.Drawing.Size(197, 28);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse Image";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lbl_Icon);
            this.panel5.Location = new System.Drawing.Point(96, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 153);
            this.panel5.TabIndex = 0;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Icon)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox lbl_Icon;
        private System.Windows.Forms.ComboBox cb_Category;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.ComboBox cb_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_FoodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ProductID;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_exit;
    }
}