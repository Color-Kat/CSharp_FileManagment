using static System.Windows.Forms.LinkLabel;

namespace MyFileManagment
{
    public partial class FileManagmentF : Form
    {
        FileViewer FileViewer = new FileViewer();
        SortingCars SortingCars = new SortingCars();
        Search Search = new Search();

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

        private void button1_Click(object sender, EventArgs e)
        {
            string searchString = SearchInput.Text;
            // List<Car> searchResult = 
            List<Car> cars = FileViewer.Get("cars.dat");
            List<Car> sortedCars = SortingCars.InsertingSort(cars);

            Car targetCar = new Car();
            targetCar.Model = searchString;

            //int i = SortingCars.BinarySearch(sortedCars, targetCar, errorTextBox);
            int i = SortingCars.BinarySearchSubstring(sortedCars, searchString, errorTextBox);

            if (i == -1)
            {
                // Not found
                MessageBox.Show("Not found");
            } else
            {
                // Found
                FileViewer.Show([sortedCars[i]], carsGrid);
            }
        }
    }
}
