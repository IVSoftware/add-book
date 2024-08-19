using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace add_book
{
    public enum BookType { Novel, Magazine, ShortStories, NonFiction,  }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CancelButton = buttonCancel;
            AcceptButton = buttonSave;
            buttonSave.DialogResult = DialogResult.OK;
            textBoxTitle.PlaceholderText = "Title";
            textBoxAuthor.PlaceholderText = "Author";
            comboBoxBookType.Items.AddRange(
                Enum
                .GetValues(typeof(BookType))
                .OfType<object>()
                .ToArray());
            StartPosition = FormStartPosition.CenterScreen;

            // Validate to conditionally enable the Save button
            textBoxTitle.TextChanged += EnableSaveButtonIfValid;
            textBoxAuthor.TextChanged += EnableSaveButtonIfValid;
            comboBoxBookType.SelectionChangeCommitted += EnableSaveButtonIfValid;
        }

        private void EnableSaveButtonIfValid(object? sender, EventArgs e) =>
            buttonSave.Enabled = 
                !string.IsNullOrWhiteSpace(BookTitle) &&
                !string.IsNullOrWhiteSpace(Author) &&
                BookType is BookType;

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if(Visible)
            {
                // Initialize
                textBoxTitle.Clear();
                textBoxAuthor.Clear();
                comboBoxBookType.SelectedIndex = -1;
                checkBoxAvailable.Checked = false;
                buttonSave.Enabled = false;
                BeginInvoke(() => ActiveControl = null);
            }
        }
        public string BookTitle => textBoxTitle.Text;
        public string Author => textBoxAuthor.Text;
        public BookType? BookType => (BookType?)comboBoxBookType.SelectedItem;
        public bool Available => checkBoxAvailable.Checked;
    }
}
