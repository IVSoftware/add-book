using System.Reflection;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace add_book
{
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
            Form2 = new Form2();
            Disposed += (sender, e) => Form2.Dispose();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.PlaceholderText = "Click for Suggestion";
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;
            Directory.CreateDirectory(Path.GetDirectoryName(JsonPath)!);
        }
        Form2 Form2;

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
            switch (Form2.ShowDialog(this))
            {
                case DialogResult.OK:
                    var book = new Book
                    {
                        Title = Form2.BookTitle,
                        Author = Form2.Author,
                        BookType = Form2.BookType,
                        Available = Form2.Available,
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
}
