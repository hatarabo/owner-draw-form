namespace HataRabo.UIGadget.Forms
{
    partial class FormBase
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
            this.clientAreaPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientAreaPanel
            // 
            this.clientAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientAreaPanel.Location = new System.Drawing.Point(8, 32);
            this.clientAreaPanel.Margin = new System.Windows.Forms.Padding(0);
            this.clientAreaPanel.Name = "clientAreaPanel";
            this.clientAreaPanel.Size = new System.Drawing.Size(332, 176);
            this.clientAreaPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::HataRabo.UIGadget.Properties.Resources.ノーマルの太さのバツアイコン;
            this.closeButton.Location = new System.Drawing.Point(308, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 32);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 216);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.clientAreaPanel);
            this.Name = "FormBase";
            this.Padding = new System.Windows.Forms.Padding(8, 32, 8, 8);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel clientAreaPanel;
        private System.Windows.Forms.Button closeButton;
    }
}