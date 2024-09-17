namespace MyFileManagment
{
    public partial class FileManagmentF : Form
    {
        FileViewer FileViewer = new FileViewer();
        SortingCars SortingCars = new SortingCars();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public FileManagmentF()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Car> cars = FileViewer.Load(openFileDialog.FileName, "cars.dat");
                FileViewer.Show(cars, carsGrid);
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                FileViewer.UploadFile(openFileDialog.FileName, "cars.dat");
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Car> cars = FileViewer.Get(openFileDialog.FileName);
                FileViewer.Show(cars, carsGrid);
            }
        }

        private void sort_Click(object sender, EventArgs e)
        {
            List<Car> cars = FileViewer.Get("cars.dat");
            List<Car> sortedCars = SortingCars.InsertingSort(cars);

            FileViewer.Show(sortedCars, carsGrid);
        }
    }
}
