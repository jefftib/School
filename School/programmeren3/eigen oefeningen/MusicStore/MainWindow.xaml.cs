using System.Windows;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Store _Store;
        private Employee Employee;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _Store = new Store();
            Employee = new Employee(_Store);
        }

        private void BtCall_Click(object sender, RoutedEventArgs e)
        {
            string name = TbCustomerName.Text;
            Person p = new Person() { Name = name };
            Employee.Todolist += new Todo(p.CallMe);
        }

        private void BtMail_Click(object sender, RoutedEventArgs e)
        {
            string name = TbCustomerName.Text;
            Person p = new Person() { Name = name };
            Employee.Todolist += new Todo(p.MailMe);
        }

        private void BtTruckArrives_Click(object sender, RoutedEventArgs e)
        {
            _Store.RaisTheEvent();
        }

        private void BtCompletedTasks_Click(object sender, RoutedEventArgs e)
        {
            LbCompletedTasks.ItemsSource = null;
            LbCompletedTasks.ItemsSource = Employee.Completed;
        }
    }
}
