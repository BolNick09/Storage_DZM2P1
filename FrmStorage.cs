using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
namespace InsUpdDel_DZM2P1
{
    public partial class FrmStorage : Form
    {
        private enum Tasks
        {
            ShowAllProducts = 0,             // Отображение всей информации о товаре
            ShowAllProductTypes,             // Отображение всех типов товаров
            ShowAllSuppliers,                // Отображение всех поставщиков
            ShowProductWithMaxQuantity,      // Показать товар с максимальным количеством
            ShowProductWithMinQuantity = 4,  // Показать товар с минимальным количеством
            ShowProductWithMinCost,          // Показать товар с минимальной себестоимостью
            ShowProductWithMaxCost,          // Показать товар с максимальной себестоимостью
            ShowProductsByCategory = 7,      // Показать товары, заданной категории
            ShowProductsBySupplier,          // Показать товары, заданного поставщика
            ShowOldestProduct,               // Показать самый старый товар на складе
            ShowAverageQuantityByType = 10   // Показать среднее количество товаров по каждому типу товара
        }

        SqlConnection conn;
        public FrmStorage()
        {
            InitializeComponent();
            string connStr = @"Data Source=DESKTOP-ET8RJ3S;Initial Catalog=Storage;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;";
            conn = new SqlConnection(connStr);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open)
                return;
            conn.Open();
            MessageBox.Show("Соединение установлено");
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                return;
            conn.Close();
            MessageBox.Show("Соединение прервано");
        }

        private void btnExecSql_Click(object sender, EventArgs e)
        {
            if (conn.State != System.Data.ConnectionState.Open)
                return;
            rtbResult.Clear();
            ExecSql();
        }
        private void ExecSql()
        {
            Tasks taskIndex = (Tasks)cbbActions.SelectedIndex;
            switch (taskIndex)
            {
                case Tasks.ShowAllProducts:
                {
                    string sqlInput = @"SELECT * 
                                        FROM Products;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };
                    
                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowAllProductTypes:
                {
                    string sqlInput = @"SELECT * 
                                        FROM ProductTypes;";
                    string[] sqlOutput = { "Id", "TypeName" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowAllSuppliers:
                {
                    string sqlInput = @"SELECT * 
                                        FROM Suppliers;";
                    string[] sqlOutput = { "Id", "SupplierName" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowProductWithMaxQuantity:
                {
                    string sqlInput = @"SELECT TOP 1 * 
                                        FROM Products
                                        ORDER BY Quantity DESC;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowProductWithMinQuantity:
                {
                    string sqlInput = @"SELECT TOP 1 * 
                                        FROM Products
                                        ORDER BY Quantity ASC;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowProductWithMinCost:
                {
                    string sqlInput = @"SELECT TOP 1 * 
                                        FROM Products
                                        ORDER BY Cost ASC;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowProductWithMaxCost:
                {
                    string sqlInput = @"SELECT TOP 1 * 
                                        FROM Products
                                        ORDER BY Cost DESC;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowProductsByCategory:
                {                    
                    if (tbParam.Text.IsNullOrEmpty())
                        return;
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfoById(sqlOutput, true);
                    break;
                }
                case Tasks.ShowProductsBySupplier:
                {
                    if (tbParam.Text.IsNullOrEmpty())
                        return;
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfoById(sqlOutput, false);
                    break;
                }
                case Tasks.ShowOldestProduct:
                {
                    string sqlInput = @"SELECT TOP 1 * 
                                        FROM Products
                                        ORDER BY DeliveryDate ASC;";
                    string[] sqlOutput = { "Id", "Name", "TypeID", "SupplierID", "Quantity", "Cost", "DeliveryDate" };

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }
                case Tasks.ShowAverageQuantityByType:
                {
                    string sqlInput = @"SELECT 
                                            pt.TypeName,
                                            AVG(p.Quantity) AS AverageQuantity
                                        FROM 
                                            Products p
                                        JOIN 
                                            ProductTypes pt ON p.TypeID = pt.ID
                                        GROUP BY 
                                            pt.TypeName;";
                    string[] sqlOutput = { "TypeName", "AverageQuantity"};

                    GetInfo(sqlInput, sqlOutput);
                    break;
                }                
            }
        }
        private string sqlStrCommand = "";
        private void GetInfo(string sqlInput, string[] mSqlOutput)
        {
            sqlStrCommand = sqlInput;

            try
            {
                SqlCommand cmd = new SqlCommand(sqlStrCommand, conn);
                var reader = cmd.ExecuteReader();
                int lineCount = 0;
                while (reader.Read())
                {
                    if (lineCount == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rtbResult.Text += (reader.GetName(i) + " ");
                        }
                        rtbResult.Text += "\n";
                    }
                    string sqlOutput = "";

                    foreach (var item in mSqlOutput)
                    {
                        sqlOutput += $@"{reader[item]} ";
                    }
                    rtbResult.Text += sqlOutput + "\n";                  
                    lineCount++;                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetInfoById(string[] mSqlOutput,bool isByProd)
        {
            if (isByProd)
                sqlStrCommand = @"SELECT *
                FROM Products
                WHERE TypeID = @Param;";
            else
                sqlStrCommand = @"SELECT *
                FROM Products
                WHERE SupplierID = @Param;";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlStrCommand, conn);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Param";

                Int32.TryParse(tbParam.Text, out int id);
                param1.Value = id;
                cmd.Parameters.Add(param1);
                var reader = cmd.ExecuteReader();
                int lineCount = 0;
                while (reader.Read())
                {
                    if (lineCount == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rtbResult.Text += (reader.GetName(i) + " ");
                        }
                        rtbResult.Text += "\n";
                    }
                    string sqlOutput = "";

                    foreach (var item in mSqlOutput)
                    {
                        sqlOutput += $@"{reader[item]} ";
                    }
                    rtbResult.Text += sqlOutput + "\n";
                    lineCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}
