using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Entity_Framework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonViewClient_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var client = db.View_Client.OrderBy(p => p.last_name).ToList();
                View.dataGridView.ItemsSource = client;
                View.Show();
            }
        }
        /// <summary>
        /// connection tables by using the operator JOIN and Orderby and Projection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonViewClientFirm_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var clientFirm = from cf in db.Client_firm
                                 join p in db.Personal_info
       on cf.personal_info_confidant equals p.ID_personal_info
                                 join a in db.Address on cf.address_firm equals a.ID_address
                                 orderby cf.name_firm
                                 select new
                                 {
                                     cf.ID_firm, cf.name_firm,
                                     last_name_confidant = p.last_name,
                                     first_name_confidant = p.first_name,
                                     phone_confidant = p.phone,
                                     e_mail_firm = p.e_mail,
                                     city_firm = a.city,
                                     street = a.street,
                                     house = a.number_house,
                                     room = a.number_flat
                                 };
                View.dataGridView.ItemsSource = clientFirm.ToList();
                View.Show();
            }
        }
        /// <summary>
        /// select all rows from table (virtual table)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonViewManager_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var manager = db.View_Manager.ToList();
                View.dataGridView.ItemsSource = manager;
                View.Show();
            }
        }
        /// <summary>
        /// select from table using WHERE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetClient_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                string lastName = textBoxLastName.Text;
                var client = from View_Client in db.View_Client
                             where View_Client.last_name == lastName
                             select View_Client;
                             //select new
                             //{
                             //    ID_client = View_Client.ID_client,
                             //    last_name = View_Client.last_name,
                             //    first_name = View_Client.first_name,
                             //    phone = View_Client.phone,
                             //    e_mail = View_Client.e_mail,
                             //    city = View_Client.city,
                             //    street = View_Client.street,
                             //    house = View_Client.number_house,
                             //    flat = View_Client.number_flat
                             //};
                if (client.ToList().Capacity == 0) MessageBox.Show(String.Format("Клієнт {0} відсутній в базі даних", lastName));
                else
                {
                    View.dataGridView.ItemsSource = client.ToList();
                    View.Show();
                }
                
            }
            textBoxLastName.Text = "Input last name client";
        }

        private void textBoxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxLastName.Text = String.Empty;
        }

        private void buttonRaitingSoftware_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var raitingSoftware = db.RaitingSoftware();
                View.dataGridView.ItemsSource = raitingSoftware;
                View.Show();
            }
        }
        /// <summary>
        /// connection tables by using the method Join()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonListSoftware_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var priceList = db.Price_software.Join(db.List_software, p => p.software, c => c.ID_software, (p,c) => 
                new
                {
                    id = p.article,
                    software = c.name_software,
                    regularPrice = p.regular_price,
                    discount = p.discount,
                    actionPrice = p.action_price,
                    note = p.note_action,
                    decription = p.item
                });
                View.dataGridView.ItemsSource = priceList.ToList();
                View.Show();
            }
        }

        private void textBoxMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxMonth.Text = String.Empty;
        }

        private void buttonTopManager_Click(object sender, RoutedEventArgs e)
        {
            int month = Convert.ToInt32(textBoxMonth.Text.Substring(0,2));
            int year = Convert.ToInt32(textBoxMonth.Text.Substring(3));
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var topManager = db.TopManagerForMonth(month, 2016);
                View.dataGridView.ItemsSource = topManager;
                View.Show();
                
            }
            textBoxMonth.Text = "Input date in format: mm/yyyy";
        }
        /// <summary>
        /// Average request client (with invested request)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAverage_Click(object sender, RoutedEventArgs e)
        {
            using (zikratiy_dbEntities db = new zikratiy_dbEntities())
            {
                Window_view View = new Window_view();
                var averageRequest = from request in (from requestClient in db.Request where requestClient.client != null select requestClient)
                                     group request by request.client into clientRequest
                                     let averageOrder = clientRequest.Average(request => request.result_price)
                                     orderby averageOrder descending
                                     select new
                                     {
                                         client = clientRequest.Key,
                                         averageOrder
                                     };
                View.dataGridView.ItemsSource = averageRequest.ToList();
                View.Show();
            }
        }
    }
}
