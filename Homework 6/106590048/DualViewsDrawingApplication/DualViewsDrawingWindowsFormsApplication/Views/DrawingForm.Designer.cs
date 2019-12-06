﻿namespace DualViewsDrawingWindowsFormsApplication.Views
{
    partial class DrawingForm
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
            if ( disposing && ( components != null ) )
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
            this._canvas = new WindowsFormsCustomComponents.DoubleBufferedPanel();
            this._formTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._buttonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._rectangleButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._formTableLayout.SuspendLayout();
            this._buttonsTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _canvas
            // 
            this._canvas.AccessibleName = "CanvasPanel";
            this._canvas.BackColor = System.Drawing.SystemColors.Info;
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(3, 48);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(794, 399);
            this._canvas.TabIndex = 0;
            // 
            // _formTableLayout
            // 
            this._formTableLayout.ColumnCount = 1;
            this._formTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._formTableLayout.Controls.Add(this._canvas, 0, 1);
            this._formTableLayout.Controls.Add(this._buttonsTableLayout, 0, 0);
            this._formTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._formTableLayout.Location = new System.Drawing.Point(0, 0);
            this._formTableLayout.Name = "_formTableLayout";
            this._formTableLayout.RowCount = 2;
            this._formTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._formTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._formTableLayout.Size = new System.Drawing.Size(800, 450);
            this._formTableLayout.TabIndex = 1;
            // 
            // _buttonsTableLayout
            // 
            this._buttonsTableLayout.ColumnCount = 3;
            this._buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTableLayout.Controls.Add(this._rectangleButton, 0, 0);
            this._buttonsTableLayout.Controls.Add(this._lineButton, 1, 0);
            this._buttonsTableLayout.Controls.Add(this._clearButton, 2, 0);
            this._buttonsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTableLayout.Location = new System.Drawing.Point(3, 3);
            this._buttonsTableLayout.Name = "_buttonsTableLayout";
            this._buttonsTableLayout.RowCount = 1;
            this._buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._buttonsTableLayout.Size = new System.Drawing.Size(794, 39);
            this._buttonsTableLayout.TabIndex = 1;
            // 
            // _rectangleButton
            // 
            this._rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangleButton.Location = new System.Drawing.Point(20, 3);
            this._rectangleButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(224, 33);
            this._rectangleButton.TabIndex = 0;
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.UseVisualStyleBackColor = true;
            // 
            // _lineButton
            // 
            this._lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lineButton.Location = new System.Drawing.Point(284, 3);
            this._lineButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(224, 33);
            this._lineButton.TabIndex = 1;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            // 
            // _clearButton
            // 
            this._clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearButton.Location = new System.Drawing.Point(548, 3);
            this._clearButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(226, 33);
            this._clearButton.TabIndex = 2;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // DrawingForm
            // 
            this.AccessibleName = "DrawingForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._formTableLayout);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this._formTableLayout.ResumeLayout(false);
            this._buttonsTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsCustomComponents.DoubleBufferedPanel _canvas;
        private System.Windows.Forms.TableLayoutPanel _formTableLayout;
        private System.Windows.Forms.TableLayoutPanel _buttonsTableLayout;
        private System.Windows.Forms.Button _rectangleButton;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _clearButton;
    }
}