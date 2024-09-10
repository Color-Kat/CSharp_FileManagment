namespace MyFileManagment
{
    partial class FileManagmentF
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Convert = new Button();
            Open = new Button();
            carsGrid = new DataGridView();
            label1 = new Label();
            OpenFileDialog = new OpenFileDialog();
            Model = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            EngineCapacity = new DataGridViewTextBoxColumn();
            BodyType = new DataGridViewTextBoxColumn();
            HasABS = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)carsGrid).BeginInit();
            SuspendLayout();
            // 
            // Convert
            // 
            Convert.Location = new Point(22, 19);
            Convert.Name = "Convert";
            Convert.Size = new Size(242, 46);
            Convert.TabIndex = 0;
            Convert.Text = "Convert Carx.txt";
            Convert.UseVisualStyleBackColor = true;
            Convert.Click += Convert_Click;
            // 
            // Open
            // 
            Open.Location = new Point(270, 19);
            Open.Name = "Open";
            Open.Size = new Size(150, 46);
            Open.TabIndex = 1;
            Open.Text = "Open";
            Open.UseVisualStyleBackColor = true;
            Open.Click += Open_Click;
            // 
            // carsGrid
            // 
            carsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            carsGrid.Columns.AddRange(new DataGridViewColumn[] { Model, Price, EngineCapacity, BodyType, HasABS });
            carsGrid.Location = new Point(22, 121);
            carsGrid.Name = "carsGrid";
            carsGrid.RowHeadersWidth = 82;
            carsGrid.Size = new Size(1078, 736);
            carsGrid.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 86);
            label1.Name = "label1";
            label1.Size = new Size(63, 32);
            label1.TabIndex = 3;
            label1.Text = "Data";
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "cars.txt";
            // 
            // Model
            // 
            Model.HeaderText = "Column1";
            Model.MinimumWidth = 10;
            Model.Name = "Model";
            Model.Width = 200;
            // 
            // Price
            // 
            Price.HeaderText = "Column1";
            Price.MinimumWidth = 10;
            Price.Name = "Price";
            Price.Width = 200;
            // 
            // EngineCapacity
            // 
            EngineCapacity.HeaderText = "Column1";
            EngineCapacity.MinimumWidth = 10;
            EngineCapacity.Name = "EngineCapacity";
            EngineCapacity.Width = 200;
            // 
            // BodyType
            // 
            BodyType.HeaderText = "Column1";
            BodyType.MinimumWidth = 10;
            BodyType.Name = "BodyType";
            BodyType.Width = 200;
            // 
            // HasABS
            // 
            HasABS.HeaderText = "Column1";
            HasABS.MinimumWidth = 10;
            HasABS.Name = "HasABS";
            HasABS.Width = 200;
            // 
            // FileManagmentF
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1704, 944);
            Controls.Add(label1);
            Controls.Add(carsGrid);
            Controls.Add(Open);
            Controls.Add(Convert);
            Name = "FileManagmentF";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)carsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Convert;
        private Button Open;
        private DataGridView carsGrid;
        private Label label1;
        private OpenFileDialog OpenFileDialog;
        private DataGridViewTextBoxColumn Model;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn EngineCapacity;
        private DataGridViewTextBoxColumn BodyType;
        private DataGridViewTextBoxColumn HasABS;
    }
}
