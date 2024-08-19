namespace add_book
{
    partial class Form1
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
            textBox1 = new TextBox();
            buttonAdd = new Button();
            buttonSuggest = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(191, 35);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(336, 286);
            textBox1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(56, 199);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 34);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSuggest
            // 
            buttonSuggest.Location = new Point(56, 35);
            buttonSuggest.Name = "buttonSuggest";
            buttonSuggest.Size = new Size(112, 34);
            buttonSuggest.TabIndex = 1;
            buttonSuggest.Text = "Suggest";
            buttonSuggest.UseVisualStyleBackColor = true;
            buttonSuggest.Click += buttonSuggest_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 344);
            Controls.Add(buttonSuggest);
            Controls.Add(buttonAdd);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonAdd;
        private Button buttonSuggest;
    }
}
