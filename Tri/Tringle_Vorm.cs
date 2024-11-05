using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Tringle
{
    public partial class Tringle_Vorm : Form
    {
        private Triangle triangle;

        public Tringle_Vorm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Side();

            triangle = new Triangle(3, 4, 5);
            DisplayTriangleInfo();
        }

        private void InitializeCustomComponents()
        {
            // Change background color and font style
            this.BackColor = Color.LightBlue;

            Button startButton = new Button();
            startButton.Text = "Alusta";
            startButton.Font = new Font("Verdana", 28, FontStyle.Regular);
            startButton.Size = new Size(150, 80);
            startButton.BackColor = Color.Pink;
            startButton.ForeColor = Color.White;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderColor = Color.Black;
            startButton.Location = new Point(550, 50);
            startButton.Click += StartButton_Click;

            Controls.Add(startButton);
        }

        private void DisplayTriangleInfo()
        {
            DataGridView dataGridView = new DataGridView
            {
                ColumnCount = 2,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                ColumnHeadersVisible = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                ScrollBars = ScrollBars.None
            };

            dataGridView.Size = new System.Drawing.Size(400, 250);
            dataGridView.Location = new System.Drawing.Point(10, 10);

            dataGridView.Columns[0].Name = "Valdkond";
            dataGridView.Columns[1].Name = "Väärtus";
            dataGridView.DefaultCellStyle.Padding = new Padding(5);

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.LightGray,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView.ColumnHeadersHeight = 40;

            Controls.Add(dataGridView);
        }

        private void Side()
        {
            // UI setup for input fields and labels
            AddTriangleInputControls("A", 270);
            AddTriangleInputControls("B", 310);
            AddTriangleInputControls("C", 350);
        }

        private void AddTriangleInputControls(string side, int yLocation)
        {
            Label label = new Label
            {
                Text = $"Küljel {side}:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(10, yLocation),
                AutoSize = true
            };
            Controls.Add(label);

            TextBox textBox = new TextBox
            {
                Name = $"textBox{side}",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(150, yLocation),
                Size = new Size(100, 30)
            };
            Controls.Add(textBox);
        }

        private void StartButton_Click(object? sender, EventArgs e)
        {
            double a, b, c;

            if (double.TryParse(Controls["textBoxA"].Text, out a) &&
                double.TryParse(Controls["textBoxB"].Text, out b) &&
                double.TryParse(Controls["textBoxC"].Text, out c))
            {
                triangle = new Triangle(a, b, c);

                Controls.OfType<DataGridView>().FirstOrDefault()?.Rows.Clear();

                DataGridView dataGridView = Controls.OfType<DataGridView>().FirstOrDefault();
                if (dataGridView != null)
                {
                    // Reversing order of displayed information
                    dataGridView.Rows.Add("Spetsifikatsioon", triangle.TriangleType);
                    dataGridView.Rows.Add("Eksisteerib?", triangle.ExistTriangle ? "Eksisteerib" : "Ei eksisteeri");
                    dataGridView.Rows.Add("Pindala", triangle.Area());
                    dataGridView.Rows.Add("Perimeeter", triangle.Perimeter());
                    dataGridView.Rows.Add("Küljel c", triangle.GetSetC);
                    dataGridView.Rows.Add("Küljel b", triangle.GetSetB);
                    dataGridView.Rows.Add("Küljel a", triangle.GetSetA);
                }

                SaveTriangleDataToXml(triangle);
            }
            else
            {
                MessageBox.Show("Palun sisestage korrektne väärtus külgede jaoks.");
            }
        }

        private void SaveTriangleDataToXml(Triangle triangle)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Triangle));
            using (FileStream fileStream = new FileStream("kolmnurgad.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, triangle);
            }
        }

        private void Tringle_Vorm_Load(object sender, EventArgs e)
        {

        }
    }
}
