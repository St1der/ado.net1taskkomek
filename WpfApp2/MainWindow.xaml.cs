using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        string cs = "";
        DataTable table;
        SqlDataReader reader;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            //using (conn=new SqlConnection())
            //{
            //    var da = new SqlDataAdapter();
            //    conn.ConnectionString = cs;
            //    conn.Open();
            //    var set = new DataSet();
            //    SqlCommand command = new SqlCommand("SELECT * FROM Authors", conn);
            //    da.SelectCommand = command;
            //    da.Fill(set,"AuthorsSet");
            //    mydataGrid1.ItemsSource = set.Tables[0].DefaultView;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //#region DataTable
            //using(var conn=new SqlConnection())
            //{


            //    conn.ConnectionString = cs;
            //    conn.Open();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "SELECT * FROM Authors";
            //    command.Connection = conn;  
            //    table = new DataTable();    
                
            //    bool hasColumnAdded=false;
            //    using (reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            if (!hasColumnAdded)
            //            {
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    table.Columns.Add(reader.GetName(i));

            //                }
            //                hasColumnAdded = true;
            //            }
            //            DataRow row = table.NewRow();
            //            for (int i = 0; i < reader.FieldCount; i++)
            //            {
            //                row[i] = reader[i];
            //            }
            //            table.Rows.Add(row);
            //        }
            //        mydataGrid1.ItemsSource = table.DefaultView;


            //    }



            //}



            //#endregion

            #region Dataset And SqlDataAdaTer
            using (conn=new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();
                var set = new DataSet();
                var da = new SqlDataAdapter("SELECT * FROM Authors; SELECT *FROM Books",conn);
                da.Fill(set);
                mydataGrid1.ItemsSource = set.Tables[0].DefaultView;
                mydataGrid2.ItemsSource = set.Tables[0].DefaultView;
            }


            #endregion
        }
    }
}
