As I understand it, the purpose of `Form2` is simply to collect the information to create a new book. Consider having `Form2` do _only_ that because there is no need for it to know anything about the `Import` class or really anything else. The benefit is that this greatly simplifies the input form, and you can also have it enable the [Save] button only when the inputs are complete and valid.

[![Disable save until input is valid][1]][1]

```csharp
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
                // Prevents the text box from obtaining focus 
                // so that the placeholder text remains visible.
                BeginInvoke(() => ActiveControl = null);
            }
        }
        public string BookTitle => textBoxTitle.Text;
        public string Author => textBoxAuthor.Text;
        public BookType? BookType => (BookType?)comboBoxBookType.SelectedItem;
        public bool Available => checkBoxAvailable.Checked;
    }
```
 
___

Making a new `Form2` instance in the handler for `buttonAdd_Click` resets the placeholder text providing a "fresh start" every time a new book is added. The `using` block ensures proper disposal of the form handle when the dialog closes. Make sure to inspect the `DialogResult` of the `ShowDialog` method before leaving the `using` block, and if the operation hasn't been cancelled then the main form - which has everything it requires in terms of the list of books and the ability to save it - can proceed to do the heavy lifting without the need to subscribe to events or pass references.

Here's some example code for the `ShowDialog` call that retrieves the necessary properties to create a new book and adds it to the list in memory. You should be able to easily adapt this to use the `Import` class that you say is required by the assignment.

```csharp
    public partial class Form1 : Form
    {
        public Random rnd = new Random();
        public int? lastResult = null;
        public string JsonPath { get; } =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                Assembly.GetEntryAssembly()?.GetName().Name!,
                "library.json");

        List<Book> Books;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.PlaceholderText = "Click for Suggestion";
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;
            Directory.CreateDirectory(Path.GetDirectoryName(JsonPath)!);
        }

        // using Newtonsoft.Json
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (File.Exists(JsonPath))
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(JsonPath))!;
            }
            else
            {
                Books = new List<Book>();
            }
            switch (Books.Count)
            {
                case 0:
                    buttonSuggest.Enabled = false;
                    break;
                case 1:
                    textBox1.Text = Books.Single().ToString();
                    buttonSuggest.Enabled = false;
                    break;
                default:
                    buttonSuggest.Enabled = true;
                    break;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var form2 = new Form2())
            {
                switch (form2.ShowDialog(this))
                {
                    case DialogResult.OK:
                        var book = new Book
                        {
                            Title = form2.BookTitle,
                            Author = form2.Author,
                            BookType = form2.BookType,
                            Available = form2.Available,
                        };
                        Books.Add(book);
                        textBox1.Text = book.ToString();
                        lastResult = Books.Count;
                        File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Books, Formatting.Indented));
                        buttonSuggest.Enabled = Books.Count > 1;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void buttonSuggest_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            switch (Books.Count)
            {
                case 0:
                    textBox1.Clear();
                    break;
                case 1:
                    textBox1.Text = Books.Single().ToString();
                    break;
                default:
                    while (true)
                    {
                        int result = rnd.Next(0, Books.Count);
                        if (result != lastResult)
                        {
                            textBox1.Text = Books[result].ToString();
                            lastResult = result;
                            return;
                        }
                    }
            }
        }
    }
```

___

Simplified `Book` class.

```csharp
   internal class Book
   {
       public string Title { get; set; } = string.Empty;
       public string Author { get; set; } = string.Empty;
       public bool Available { get; set; }
       public BookType? BookType {get; set; }
       public override string ToString() =>
           Available ?
               $"{Title} av {Author}{Environment.NewLine}({BookType}){Environment.NewLine}Boken finns tillgänglig!" :
               $"{Title} av {Author}{Environment.NewLine}({BookType}){Environment.NewLine}Boken är tyvärr inte tillgänglig!";
   }
```


  [1]: https://i.sstatic.net/65WzmOmB.png