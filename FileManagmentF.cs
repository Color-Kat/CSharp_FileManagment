namespace MyFileManagment
{
    public partial class FileManagmentF : Form
    {
        FileViewer FileViewer = new FileViewer();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public FileManagmentF()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                FileViewer.LoadAndSaveFile(openFileDialog.FileName);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                FileViewer.Load(openFileDialog.FileName, carsGrid);
        }
    }
}
