﻿namespace Kursovaya_test
{
    partial class Form2
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
        /// 

        private void InitializeComponent()
        {
            this.sort_button = new System.Windows.Forms.Button();
            this.Comparison_btn = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Profit_sort = new System.Windows.Forms.RadioButton();
            this.Export_sort = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Back_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sort_button
            // 
            this.sort_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sort_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.sort_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.sort_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sort_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sort_button.Location = new System.Drawing.Point(755, 201);
            this.sort_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sort_button.Name = "sort_button";
            this.sort_button.Size = new System.Drawing.Size(195, 39);
            this.sort_button.TabIndex = 1;
            this.sort_button.Text = "Сортування";
            this.sort_button.UseVisualStyleBackColor = false;
            this.sort_button.Click += new System.EventHandler(this.sort_button_Click);
            // 
            // Comparison_btn
            // 
            this.Comparison_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Comparison_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Comparison_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Comparison_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comparison_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Comparison_btn.Location = new System.Drawing.Point(755, 438);
            this.Comparison_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Comparison_btn.Name = "Comparison_btn";
            this.Comparison_btn.Size = new System.Drawing.Size(167, 39);
            this.Comparison_btn.TabIndex = 4;
            this.Comparison_btn.Text = "Порівняння";
            this.Comparison_btn.UseVisualStyleBackColor = false;
            this.Comparison_btn.Click += new System.EventHandler(this.Comparison_btn_Click);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.Location = new System.Drawing.Point(824, 133);
            this.Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(195, 30);
            this.Search.TabIndex = 5;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(749, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Пошук";
            // 
            // Profit_sort
            // 
            this.Profit_sort.AutoSize = true;
            this.Profit_sort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Profit_sort.Location = new System.Drawing.Point(755, 247);
            this.Profit_sort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Profit_sort.Name = "Profit_sort";
            this.Profit_sort.Size = new System.Drawing.Size(249, 26);
            this.Profit_sort.TabIndex = 7;
            this.Profit_sort.TabStop = true;
            this.Profit_sort.Text = "Сортування за прибутком";
            this.Profit_sort.UseVisualStyleBackColor = true;
            // 
            // Export_sort
            // 
            this.Export_sort.AutoSize = true;
            this.Export_sort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Export_sort.Location = new System.Drawing.Point(755, 276);
            this.Export_sort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Export_sort.Name = "Export_sort";
            this.Export_sort.Size = new System.Drawing.Size(249, 26);
            this.Export_sort.TabIndex = 8;
            this.Export_sort.TabStop = true;
            this.Export_sort.Text = "Сортування за експортом";
            this.Export_sort.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(16, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 457);
            this.panel1.TabIndex = 9;
            // 
            // Back_btn
            // 
            this.Back_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Back_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Back_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back_btn.Location = new System.Drawing.Point(16, 4);
            this.Back_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(113, 39);
            this.Back_btn.TabIndex = 10;
            this.Back_btn.Text = "<< Назад";
            this.Back_btn.UseVisualStyleBackColor = false;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(323, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Export_sort);
            this.Controls.Add(this.Profit_sort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Comparison_btn);
            this.Controls.Add(this.sort_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Карта корисних копалин";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseEnter += new System.EventHandler(this.Form2_MouseEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sort_button;
        private System.Windows.Forms.Button Comparison_btn;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Profit_sort;
        private System.Windows.Forms.RadioButton Export_sort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.Label label2;
    }
}