namespace TestowanieOprogramowania
{
    public partial class Form1 : Form
    {
        private bool drag = false;
        private Point startPoint = new Point(0, 0);


        public Form1()
        {
            InitializeComponent();

            // Dodaj obs³ugê zdarzeñ dla ca³ego formularza
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);

        }


        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        void Form_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("HelloWorld");
        }
    }
}