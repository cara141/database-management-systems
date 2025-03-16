using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lab1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private string connection_string = ConfigurationManager.ConnectionStrings["MyRealEstateAgency"].ConnectionString;
    private SqlDataAdapter adapter;
    private DataSet data_set_parent = new DataSet();
    private DataSet data_set_child = new DataSet();

    /// <summary>
    ///  Clean up any resources being used.
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
        dataGridViewParent = new System.Windows.Forms.DataGridView();
        dataGridViewChild = new System.Windows.Forms.DataGridView();
        panel1 = new System.Windows.Forms.Panel();
        ImageIDLabel = new System.Windows.Forms.Label();
        PropertyIDLabel = new System.Windows.Forms.Label();
        ImageURLLabel = new System.Windows.Forms.Label();
        DescriptionLabel = new System.Windows.Forms.Label();
        ImageIDTextBox = new System.Windows.Forms.TextBox();
        PropertyIDTextBox = new System.Windows.Forms.TextBox();
        ImageURLTextBox = new System.Windows.Forms.TextBox();
        DescriptionTextBox = new System.Windows.Forms.TextBox();
        UpdateImageButton = new System.Windows.Forms.Button();
        DeleteImageButton = new System.Windows.Forms.Button();
        AddImageButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewParent).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewChild).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridViewParent
        // 
        dataGridViewParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewParent.Location = new System.Drawing.Point(25, 10);
        dataGridViewParent.Name = "dataGridViewParent";
        dataGridViewParent.RowHeadersWidth = 51;
        dataGridViewParent.Size = new System.Drawing.Size(530, 420);
        dataGridViewParent.TabIndex = 0;
        dataGridViewParent.Text = "dataGridView1";
        dataGridViewParent.SelectionChanged += dataGridViewParent_SelectionChanged;
        // 
        // dataGridViewChild
        // 
        dataGridViewChild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewChild.Location = new System.Drawing.Point(561, 10);
        dataGridViewChild.Name = "dataGridViewChild";
        dataGridViewChild.RowHeadersWidth = 51;
        dataGridViewChild.Size = new System.Drawing.Size(608, 420);
        dataGridViewChild.TabIndex = 1;
        dataGridViewChild.Text = "dataGridView2";
        dataGridViewChild.SelectionChanged += dataGridViewChild_SelectionChanged;
        // 
        // panel1
        // 
        panel1.Controls.Add(AddImageButton);
        panel1.Controls.Add(DeleteImageButton);
        panel1.Controls.Add(UpdateImageButton);
        panel1.Controls.Add(DescriptionTextBox);
        panel1.Controls.Add(ImageURLTextBox);
        panel1.Controls.Add(PropertyIDTextBox);
        panel1.Controls.Add(ImageIDTextBox);
        panel1.Controls.Add(DescriptionLabel);
        panel1.Controls.Add(ImageURLLabel);
        panel1.Controls.Add(PropertyIDLabel);
        panel1.Controls.Add(ImageIDLabel);
        panel1.Location = new System.Drawing.Point(1175, 15);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(621, 415);
        panel1.TabIndex = 2;
        // 
        // ImageIDLabel
        // 
        ImageIDLabel.Location = new System.Drawing.Point(13, 4);
        ImageIDLabel.Name = "ImageIDLabel";
        ImageIDLabel.Size = new System.Drawing.Size(67, 23);
        ImageIDLabel.TabIndex = 0;
        ImageIDLabel.Text = "ImageID";
        // 
        // PropertyIDLabel
        // 
        PropertyIDLabel.Location = new System.Drawing.Point(0, 37);
        PropertyIDLabel.Name = "PropertyIDLabel";
        PropertyIDLabel.Size = new System.Drawing.Size(80, 23);
        PropertyIDLabel.TabIndex = 1;
        PropertyIDLabel.Text = "PropertyID";
        // 
        // ImageURLLabel
        // 
        ImageURLLabel.Location = new System.Drawing.Point(3, 70);
        ImageURLLabel.Name = "ImageURLLabel";
        ImageURLLabel.Size = new System.Drawing.Size(77, 23);
        ImageURLLabel.TabIndex = 2;
        ImageURLLabel.Text = "ImageURL";
        // 
        // DescriptionLabel
        // 
        DescriptionLabel.Location = new System.Drawing.Point(0, 99);
        DescriptionLabel.Name = "DescriptionLabel";
        DescriptionLabel.Size = new System.Drawing.Size(86, 23);
        DescriptionLabel.TabIndex = 3;
        DescriptionLabel.Text = "Description";
        // 
        // ImageIDTextBox
        // 
        ImageIDTextBox.Location = new System.Drawing.Point(86, 0);
        ImageIDTextBox.Name = "ImageIDTextBox";
        ImageIDTextBox.Size = new System.Drawing.Size(530, 27);
        ImageIDTextBox.TabIndex = 4;
        ImageIDTextBox.Enabled = false;
        // 
        // PropertyIDTextBox
        // 
        PropertyIDTextBox.Location = new System.Drawing.Point(86, 33);
        PropertyIDTextBox.Name = "PropertyIDTextBox";
        PropertyIDTextBox.Size = new System.Drawing.Size(530, 27);
        PropertyIDTextBox.TabIndex = 5;
        // 
        // ImageURLTextBox
        // 
        ImageURLTextBox.Location = new System.Drawing.Point(86, 66);
        ImageURLTextBox.Name = "ImageURLTextBox";
        ImageURLTextBox.Size = new System.Drawing.Size(530, 27);
        ImageURLTextBox.TabIndex = 6;
        // 
        // DescriptionTextBox
        // 
        DescriptionTextBox.Location = new System.Drawing.Point(86, 99);
        DescriptionTextBox.Multiline = true;
        DescriptionTextBox.Name = "DescriptionTextBox";
        DescriptionTextBox.Size = new System.Drawing.Size(530, 240);
        DescriptionTextBox.TabIndex = 7;
        // 
        // UpdateImageButton
        // 
        UpdateImageButton.Location = new System.Drawing.Point(167, 345);
        UpdateImageButton.Name = "UpdateImageButton";
        UpdateImageButton.Size = new System.Drawing.Size(75, 34);
        UpdateImageButton.TabIndex = 8;
        UpdateImageButton.Text = "Update";
        UpdateImageButton.UseVisualStyleBackColor = true;
        UpdateImageButton.Click += UpdateImageButton_Click;
        // 
        // DeleteImageButton
        // 
        DeleteImageButton.Location = new System.Drawing.Point(86, 345);
        DeleteImageButton.Name = "DeleteImageButton";
        DeleteImageButton.Size = new System.Drawing.Size(75, 34);
        DeleteImageButton.TabIndex = 9;
        DeleteImageButton.Text = "Delete";
        DeleteImageButton.UseVisualStyleBackColor = true;
        DeleteImageButton.Click += DeleteImageButton_Click;
        // 
        // AddImageButton
        // 
        AddImageButton.Location = new System.Drawing.Point(248, 345);
        AddImageButton.Name = "AddImageButton";
        AddImageButton.Size = new System.Drawing.Size(75, 34);
        AddImageButton.TabIndex = 10;
        AddImageButton.Text = "Add";
        AddImageButton.UseVisualStyleBackColor = true;
        AddImageButton.Click += AddImageButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1902, 753);
        Controls.Add(panel1);
        Controls.Add(dataGridViewChild);
        Controls.Add(dataGridViewParent);
        Text = "Form1";
        WindowState = System.Windows.Forms.FormWindowState.Maximized;
        ((System.ComponentModel.ISupportInitialize)dataGridViewParent).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewChild).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label ImageIDLabel;
    private System.Windows.Forms.Label PropertyIDLabel;
    private System.Windows.Forms.Label ImageURLLabel;
    private System.Windows.Forms.Label DescriptionLabel;
    private System.Windows.Forms.TextBox ImageIDTextBox;
    private System.Windows.Forms.TextBox ImageURLTextBox;
    private System.Windows.Forms.TextBox DescriptionTextBox;
    private System.Windows.Forms.Button UpdateImageButton;
    private System.Windows.Forms.Button DeleteImageButton;
    private System.Windows.Forms.Button AddImageButton;
    
    private System.Windows.Forms.TextBox PropertyIDTextBox;

    private System.Windows.Forms.DataGridView dataGridViewParent;
    private System.Windows.Forms.DataGridView dataGridViewChild;

    #endregion
}