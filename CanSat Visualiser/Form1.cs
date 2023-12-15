namespace CanSat_Visualiser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }


        private void importToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            // browse for the CSV file
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CSV files|*.csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(dlg.FileName);
                List<double> xValues = new List<double>();
                List<double> yValues = new List<double>();
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    double x = double.Parse(parts[0]);
                    double y = double.Parse(parts[1]);

                    xValues.Add(x);
                    yValues.Add(y);
                }

                if (dlg.FileName == "altitude.csv")
                {
                   // altGraph.Plot.AddScatter(xValues)
                }

            }
        }

        private void altGraph_Load(object sender, EventArgs e)
        {

        }
    }
}