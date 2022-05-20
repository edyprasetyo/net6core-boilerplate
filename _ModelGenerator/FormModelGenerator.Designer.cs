namespace ModelGenerator
{
    partial class FormModelGenerator
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
            this.txtResult1 = new System.Windows.Forms.TextBox();
            this.txtResult2 = new System.Windows.Forms.TextBox();
            this.txtResult3 = new System.Windows.Forms.TextBox();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.txtResult4 = new System.Windows.Forms.TextBox();
            this.btnGenerateMsLookupHdrMapping = new System.Windows.Forms.Button();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.btnGenerateModelController = new System.Windows.Forms.Button();
            this.btnGenerateAllModel = new System.Windows.Forms.Button();
            this.btnGenerateModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult1
            // 
            this.txtResult1.Location = new System.Drawing.Point(22, 131);
            this.txtResult1.Multiline = true;
            this.txtResult1.Name = "txtResult1";
            this.txtResult1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult1.Size = new System.Drawing.Size(324, 389);
            this.txtResult1.TabIndex = 3;
            // 
            // txtResult2
            // 
            this.txtResult2.Location = new System.Drawing.Point(371, 131);
            this.txtResult2.MaxLength = 99999999;
            this.txtResult2.Multiline = true;
            this.txtResult2.Name = "txtResult2";
            this.txtResult2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult2.Size = new System.Drawing.Size(304, 389);
            this.txtResult2.TabIndex = 4;
            // 
            // txtResult3
            // 
            this.txtResult3.Location = new System.Drawing.Point(697, 131);
            this.txtResult3.Multiline = true;
            this.txtResult3.Name = "txtResult3";
            this.txtResult3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult3.Size = new System.Drawing.Size(301, 389);
            this.txtResult3.TabIndex = 10;
            // 
            // cboTable
            // 
            this.cboTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(65, 46);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(233, 28);
            this.cboTable.TabIndex = 11;
            // 
            // txtResult4
            // 
            this.txtResult4.Location = new System.Drawing.Point(1019, 131);
            this.txtResult4.Multiline = true;
            this.txtResult4.Name = "txtResult4";
            this.txtResult4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult4.Size = new System.Drawing.Size(284, 389);
            this.txtResult4.TabIndex = 13;
            // 
            // btnGenerateMsLookupHdrMapping
            // 
            this.btnGenerateMsLookupHdrMapping.Location = new System.Drawing.Point(1035, 86);
            this.btnGenerateMsLookupHdrMapping.Name = "btnGenerateMsLookupHdrMapping";
            this.btnGenerateMsLookupHdrMapping.Size = new System.Drawing.Size(247, 23);
            this.btnGenerateMsLookupHdrMapping.TabIndex = 14;
            this.btnGenerateMsLookupHdrMapping.Text = "Generate MsLookupHdr Mapping";
            this.btnGenerateMsLookupHdrMapping.UseVisualStyleBackColor = true;
            this.btnGenerateMsLookupHdrMapping.Click += new System.EventHandler(this.btnGenerateMsLookupHdrMapping_Click);
            // 
            // cboLanguage
            // 
            this.cboLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(65, 12);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(233, 28);
            this.cboLanguage.TabIndex = 15;
            // 
            // btnGenerateModelController
            // 
            this.btnGenerateModelController.Location = new System.Drawing.Point(722, 86);
            this.btnGenerateModelController.Name = "btnGenerateModelController";
            this.btnGenerateModelController.Size = new System.Drawing.Size(214, 23);
            this.btnGenerateModelController.TabIndex = 9;
            this.btnGenerateModelController.Text = "Generate Model Controller";
            this.btnGenerateModelController.UseVisualStyleBackColor = true;
            this.btnGenerateModelController.Click += new System.EventHandler(this.btnGenerateModelController_Click);
            // 
            // btnGenerateAllModel
            // 
            this.btnGenerateAllModel.Location = new System.Drawing.Point(416, 86);
            this.btnGenerateAllModel.Name = "btnGenerateAllModel";
            this.btnGenerateAllModel.Size = new System.Drawing.Size(214, 23);
            this.btnGenerateAllModel.TabIndex = 17;
            this.btnGenerateAllModel.Text = "Generate All Model";
            this.btnGenerateAllModel.UseVisualStyleBackColor = true;
            this.btnGenerateAllModel.Click += new System.EventHandler(this.btnGenerateAllModel_Click);
            // 
            // btnGenerateModel
            // 
            this.btnGenerateModel.Location = new System.Drawing.Point(102, 86);
            this.btnGenerateModel.Name = "btnGenerateModel";
            this.btnGenerateModel.Size = new System.Drawing.Size(159, 23);
            this.btnGenerateModel.TabIndex = 18;
            this.btnGenerateModel.Text = "Generate Model";
            this.btnGenerateModel.UseVisualStyleBackColor = true;
            this.btnGenerateModel.Click += new System.EventHandler(this.btnGenerateModel_Click);
            // 
            // FormModelGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 532);
            this.Controls.Add(this.btnGenerateModel);
            this.Controls.Add(this.btnGenerateAllModel);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.btnGenerateMsLookupHdrMapping);
            this.Controls.Add(this.txtResult4);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.txtResult3);
            this.Controls.Add(this.btnGenerateModelController);
            this.Controls.Add(this.txtResult2);
            this.Controls.Add(this.txtResult1);
            this.Name = "FormModelGenerator";
            this.Text = "Model Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtResult1;
        private System.Windows.Forms.TextBox txtResult2;
        private System.Windows.Forms.TextBox txtResult3;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.TextBox txtResult4;
        private System.Windows.Forms.Button btnGenerateMsLookupHdrMapping;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Button btnGenerateModelController;
        private System.Windows.Forms.Button btnGenerateAllModel;
        private System.Windows.Forms.Button btnGenerateModel;
    }
}

