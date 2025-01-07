namespace Food_Ordering_System.AdminPages
{
    partial class Products
    {
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Unavailable = new System.Windows.Forms.CheckBox();
            this.categoryFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.FilterButton = new System.Windows.Forms.Button();
            this.MainDish = new System.Windows.Forms.Button();
            this.Appetizer = new System.Windows.Forms.Button();
            this.Dessert = new System.Windows.Forms.Button();
            this.Drinks = new System.Windows.Forms.Button();
            this.Others = new System.Windows.Forms.Button();
            this.categoryfilterTimer = new System.Windows.Forms.Timer(this.components);
            this.all = new System.Windows.Forms.Button();
            this.outOfStock = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.categoryFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(70)))), ((int)(((byte)(92)))));
            this.flpProducts.Location = new System.Drawing.Point(180, 148);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(20);
            this.flpProducts.Size = new System.Drawing.Size(613, 477);
            this.flpProducts.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 73);
            this.panel2.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Food_Ordering_System.Resource1.logo__1_;
            this.pictureBox1.Location = new System.Drawing.Point(34, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(70)))), ((int)(((byte)(92)))));
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.txt_search);
            this.panel3.Location = new System.Drawing.Point(3, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(896, 60);
            this.panel3.TabIndex = 24;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.pictureBox2.Image = global::Food_Ordering_System.Resource1.search2;
            this.pictureBox2.Location = new System.Drawing.Point(277, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txt_search.Location = new System.Drawing.Point(34, 16);
            this.txt_search.Margin = new System.Windows.Forms.Padding(4);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(273, 27);
            this.txt_search.TabIndex = 7;
            this.txt_search.Tag = "";
            this.txt_search.Text = "Search Products.";
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flpProducts);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(899, 649);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(70)))), ((int)(((byte)(92)))));
            this.flowLayoutPanel2.Controls.Add(this.checkBox1);
            this.flowLayoutPanel2.Controls.Add(this.Unavailable);
            this.flowLayoutPanel2.Controls.Add(this.outOfStock);
            this.flowLayoutPanel2.Controls.Add(this.categoryFilter);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 148);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 501);
            this.flowLayoutPanel2.TabIndex = 25;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(10, 30);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(10, 30, 0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 2, 21, 2);
            this.checkBox1.Size = new System.Drawing.Size(132, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Available";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // Unavailable
            // 
            this.Unavailable.AutoSize = true;
            this.Unavailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.Unavailable.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unavailable.ForeColor = System.Drawing.Color.White;
            this.Unavailable.Location = new System.Drawing.Point(10, 69);
            this.Unavailable.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.Unavailable.Name = "Unavailable";
            this.Unavailable.Padding = new System.Windows.Forms.Padding(10, 2, 2, 2);
            this.Unavailable.Size = new System.Drawing.Size(129, 28);
            this.Unavailable.TabIndex = 27;
            this.Unavailable.Text = "Unavailable";
            this.Unavailable.UseVisualStyleBackColor = false;
            this.Unavailable.CheckedChanged += new System.EventHandler(this.Unavailable_CheckedChanged);
            // 
            // categoryFilter
            // 
            this.categoryFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.categoryFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoryFilter.Controls.Add(this.FilterButton);
            this.categoryFilter.Controls.Add(this.MainDish);
            this.categoryFilter.Controls.Add(this.Appetizer);
            this.categoryFilter.Controls.Add(this.Dessert);
            this.categoryFilter.Controls.Add(this.Drinks);
            this.categoryFilter.Controls.Add(this.Others);
            this.categoryFilter.Controls.Add(this.all);
            this.categoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryFilter.Location = new System.Drawing.Point(10, 142);
            this.categoryFilter.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.categoryFilter.MaximumSize = new System.Drawing.Size(150, 240);
            this.categoryFilter.MinimumSize = new System.Drawing.Size(129, 36);
            this.categoryFilter.Name = "categoryFilter";
            this.categoryFilter.Size = new System.Drawing.Size(150, 36);
            this.categoryFilter.TabIndex = 26;
            // 
            // FilterButton
            // 
            this.FilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.FilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterButton.ForeColor = System.Drawing.Color.White;
            this.FilterButton.Image = global::Food_Ordering_System.Resource1.panel;
            this.FilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FilterButton.Location = new System.Drawing.Point(2, 2);
            this.FilterButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(150, 30);
            this.FilterButton.TabIndex = 0;
            this.FilterButton.Text = "Category";
            this.FilterButton.UseVisualStyleBackColor = false;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click_1);
            // 
            // MainDish
            // 
            this.MainDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.MainDish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MainDish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainDish.ForeColor = System.Drawing.Color.White;
            this.MainDish.Location = new System.Drawing.Point(2, 36);
            this.MainDish.Margin = new System.Windows.Forms.Padding(2);
            this.MainDish.Name = "MainDish";
            this.MainDish.Size = new System.Drawing.Size(150, 30);
            this.MainDish.TabIndex = 1;
            this.MainDish.Text = "Main Dish";
            this.MainDish.UseVisualStyleBackColor = false;
            this.MainDish.Click += new System.EventHandler(this.MainDish_Click);
            // 
            // Appetizer
            // 
            this.Appetizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Appetizer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Appetizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appetizer.ForeColor = System.Drawing.Color.White;
            this.Appetizer.Location = new System.Drawing.Point(2, 70);
            this.Appetizer.Margin = new System.Windows.Forms.Padding(2);
            this.Appetizer.Name = "Appetizer";
            this.Appetizer.Size = new System.Drawing.Size(150, 30);
            this.Appetizer.TabIndex = 2;
            this.Appetizer.Text = "Appetizer";
            this.Appetizer.UseVisualStyleBackColor = false;
            this.Appetizer.Click += new System.EventHandler(this.Appetizer_Click);
            // 
            // Dessert
            // 
            this.Dessert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Dessert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Dessert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dessert.ForeColor = System.Drawing.Color.White;
            this.Dessert.Location = new System.Drawing.Point(2, 104);
            this.Dessert.Margin = new System.Windows.Forms.Padding(2);
            this.Dessert.Name = "Dessert";
            this.Dessert.Size = new System.Drawing.Size(150, 30);
            this.Dessert.TabIndex = 3;
            this.Dessert.Text = "Dessert";
            this.Dessert.UseVisualStyleBackColor = false;
            this.Dessert.Click += new System.EventHandler(this.Dessert_Click);
            // 
            // Drinks
            // 
            this.Drinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Drinks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Drinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drinks.ForeColor = System.Drawing.Color.White;
            this.Drinks.Location = new System.Drawing.Point(2, 138);
            this.Drinks.Margin = new System.Windows.Forms.Padding(2);
            this.Drinks.Name = "Drinks";
            this.Drinks.Size = new System.Drawing.Size(150, 30);
            this.Drinks.TabIndex = 4;
            this.Drinks.Text = "Drinks";
            this.Drinks.UseVisualStyleBackColor = false;
            this.Drinks.Click += new System.EventHandler(this.Drinks_Click);
            // 
            // Others
            // 
            this.Others.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Others.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Others.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Others.ForeColor = System.Drawing.Color.White;
            this.Others.Location = new System.Drawing.Point(2, 172);
            this.Others.Margin = new System.Windows.Forms.Padding(2);
            this.Others.Name = "Others";
            this.Others.Size = new System.Drawing.Size(150, 30);
            this.Others.TabIndex = 5;
            this.Others.Text = "Others";
            this.Others.UseVisualStyleBackColor = false;
            this.Others.Click += new System.EventHandler(this.Others_Click);
            // 
            // categoryfilterTimer
            // 
            this.categoryfilterTimer.Interval = 10;
            this.categoryfilterTimer.Tick += new System.EventHandler(this.categoryfilterTimer_Tick);
            // 
            // all
            // 
            this.all.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.all.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.all.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all.ForeColor = System.Drawing.Color.White;
            this.all.Location = new System.Drawing.Point(2, 206);
            this.all.Margin = new System.Windows.Forms.Padding(2);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(150, 30);
            this.all.TabIndex = 6;
            this.all.Text = "(ALL CATEGORY)";
            this.all.UseVisualStyleBackColor = false;
            this.all.Click += new System.EventHandler(this.all_Click);
            // 
            // outOfStock
            // 
            this.outOfStock.AutoSize = true;
            this.outOfStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.outOfStock.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outOfStock.ForeColor = System.Drawing.Color.White;
            this.outOfStock.Location = new System.Drawing.Point(10, 107);
            this.outOfStock.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.outOfStock.Name = "outOfStock";
            this.outOfStock.Padding = new System.Windows.Forms.Padding(10, 2, 2, 2);
            this.outOfStock.Size = new System.Drawing.Size(125, 25);
            this.outOfStock.TabIndex = 28;
            this.outOfStock.Text = "Out Of Stock";
            this.outOfStock.UseVisualStyleBackColor = false;
            this.outOfStock.CheckedChanged += new System.EventHandler(this.outOfStock_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(109, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Lists of Products";
            // 
            // Products
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Products";
            this.Size = new System.Drawing.Size(929, 660);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.categoryFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel categoryFilter;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Button MainDish;
        private System.Windows.Forms.Button Appetizer;
        private System.Windows.Forms.Button Dessert;
        private System.Windows.Forms.Button Drinks;
        private System.Windows.Forms.Button Others;
        private System.Windows.Forms.Timer categoryfilterTimer;
        private System.Windows.Forms.CheckBox Unavailable;
        private System.Windows.Forms.Button all;
        private System.Windows.Forms.CheckBox outOfStock;
        private System.Windows.Forms.Label label2;
    }
}
