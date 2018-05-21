namespace DrawingForm
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonTable = new System.Windows.Forms.TableLayoutPanel();
            this._arrow = new System.Windows.Forms.Button();
            this._saveToGoogleDrive = new System.Windows.Forms.Button();
            this._ellipse = new System.Windows.Forms.Button();
            this._rectangle = new System.Windows.Forms.Button();
            this._line = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this._delete = new System.Windows.Forms.Button();
            this._buttonTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonTable
            // 
            this._buttonTable.ColumnCount = 7;
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this._buttonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this._buttonTable.Controls.Add(this._delete, 4, 0);
            this._buttonTable.Controls.Add(this._arrow, 3, 0);
            this._buttonTable.Controls.Add(this._saveToGoogleDrive, 6, 0);
            this._buttonTable.Controls.Add(this._ellipse, 0, 0);
            this._buttonTable.Controls.Add(this._rectangle, 1, 0);
            this._buttonTable.Controls.Add(this._line, 2, 0);
            this._buttonTable.Controls.Add(this._clear, 5, 0);
            this._buttonTable.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonTable.Location = new System.Drawing.Point(0, 0);
            this._buttonTable.Name = "_buttonTable";
            this._buttonTable.RowCount = 1;
            this._buttonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonTable.Size = new System.Drawing.Size(1350, 43);
            this._buttonTable.TabIndex = 0;
            // 
            // _arrow
            // 
            this._arrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._arrow.Enabled = false;
            this._arrow.Location = new System.Drawing.Point(579, 3);
            this._arrow.Name = "_arrow";
            this._arrow.Size = new System.Drawing.Size(186, 37);
            this._arrow.TabIndex = 5;
            this._arrow.Text = "Arrow";
            this._arrow.UseVisualStyleBackColor = true;
            this._arrow.Click += new System.EventHandler(this.HandleArrowButtonClick);
            // 
            // _saveToGoogleDrive
            // 
            this._saveToGoogleDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveToGoogleDrive.Enabled = false;
            this._saveToGoogleDrive.Location = new System.Drawing.Point(1155, 3);
            this._saveToGoogleDrive.Name = "_saveToGoogleDrive";
            this._saveToGoogleDrive.Size = new System.Drawing.Size(192, 37);
            this._saveToGoogleDrive.TabIndex = 4;
            this._saveToGoogleDrive.Text = "Save to Google Drive";
            this._saveToGoogleDrive.UseVisualStyleBackColor = true;
            this._saveToGoogleDrive.Click += new System.EventHandler(this.HandleSaveToGoogleDriveButtonClick);
            // 
            // _ellipse
            // 
            this._ellipse.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ellipse.Location = new System.Drawing.Point(3, 3);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(186, 37);
            this._ellipse.TabIndex = 3;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.HandleEllipseButtonClick);
            // 
            // _rectangle
            // 
            this._rectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangle.Location = new System.Drawing.Point(195, 3);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(186, 37);
            this._rectangle.TabIndex = 0;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _line
            // 
            this._line.Dock = System.Windows.Forms.DockStyle.Fill;
            this._line.Location = new System.Drawing.Point(387, 3);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(186, 37);
            this._line.TabIndex = 1;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _clear
            // 
            this._clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clear.Location = new System.Drawing.Point(963, 3);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(186, 37);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _delete
            // 
            this._delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this._delete.Location = new System.Drawing.Point(771, 3);
            this._delete.Name = "_delete";
            this._delete.Size = new System.Drawing.Size(186, 37);
            this._delete.TabIndex = 6;
            this._delete.Text = "Delete";
            this._delete.UseVisualStyleBackColor = true;
            this._delete.Click += new System.EventHandler(this.HandleDeleteButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this._buttonTable);
            this.Name = "MainForm";
            this.Text = "Drawing";
            this._buttonTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _buttonTable;
        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _saveToGoogleDrive;
        private System.Windows.Forms.Button _arrow;
        private System.Windows.Forms.Button _delete;
    }
}

