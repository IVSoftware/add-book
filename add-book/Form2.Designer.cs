namespace add_book
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
        private void InitializeComponent()
        {
            textBoxTitle = new TextBox();
            textBoxAuthor = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            checkBoxAvailable = new CheckBox();
            comboBoxBookType = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(60, 43);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(316, 31);
            textBoxTitle.TabIndex = 0;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Location = new Point(60, 80);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(316, 31);
            textBoxAuthor.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(60, 194);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(264, 194);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxAvailable
            // 
            checkBoxAvailable.AutoSize = true;
            checkBoxAvailable.Location = new Point(60, 154);
            checkBoxAvailable.Name = "checkBoxAvailable";
            checkBoxAvailable.Size = new Size(109, 29);
            checkBoxAvailable.TabIndex = 2;
            checkBoxAvailable.TabStop = false;
            checkBoxAvailable.Text = "Available";
            checkBoxAvailable.UseVisualStyleBackColor = true;
            // 
            // comboBoxBookType
            // 
            comboBoxBookType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBookType.FormattingEnabled = true;
            comboBoxBookType.Location = new Point(162, 117);
            comboBoxBookType.Name = "comboBoxBookType";
            comboBoxBookType.Size = new Size(214, 33);
            comboBoxBookType.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 120);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 4;
            label1.Text = "Book Type";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(label1);
            Controls.Add(comboBoxBookType);
            Controls.Add(checkBoxAvailable);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxAuthor);
            Controls.Add(textBoxTitle);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitle;
        private TextBox textBoxAuthor;
        private Button buttonSave;
        private Button buttonCancel;
        private CheckBox checkBoxAvailable;
        private ComboBox comboBoxBookType;
        private Label label1;
    }
}