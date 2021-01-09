using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Lab7
{
    public partial class MainWindow : Form
    {
        private List<String> tablesNames;
        private List<String> tablesColumns;
        private Dictionary<String, DataTable> loadedTables;
        private Dictionary<String, List<String>> primaryKeys;

        public MainWindow()
        {
            InitializeComponent();
            tablesNames = new List<String>();
            tablesColumns = new List<String>();
            loadedTables = new Dictionary<String, DataTable>();
            primaryKeys = new Dictionary<String, List<String>>();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private List<String> LoadTablesNames(Database db) {
            var names = new List<String>();
            DataTable dt = db.GetConnection().GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow row in dt.Rows)
                names.Add(row["TABLE_NAME"].ToString());
            return names;
        }

        private List<String> LoadTablesColumns(Database db) {
            var columns = new List<String>();
            DataTable dt = db.GetConnection().GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
            foreach (DataRow row in dt.Rows)
                columns.Add(row["COLUMN_NAME"].ToString());
            return columns;
        }

        private List<String> LoadPrimaryKeys(Database db, String tableName) {
            var primaryKeys = new List<String>();
            DataTable dt = db.GetConnection().GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, new object[] { null, null, tableName });
            int columnNameToIndex = dt.Columns["COLUMN_NAME"].Ordinal;
            foreach (DataRow row in dt.Rows)
                primaryKeys.Add(row.ItemArray[columnNameToIndex].ToString());
            return primaryKeys;
        }

        DataTable LoadTable(Database db, String tableName) {
            DataTable dt = new DataTable();
            OleDbCommand command = new OleDbCommand($"SELECT * FROM [{tableName}]", db.GetConnection());
            OleDbDataAdapter dbAdapter = new OleDbDataAdapter(command);
            dbAdapter.Fill(dt);
            return dt;
        }

        private void UpdateTables(Database db) {
            foreach (String tableName in tablesNames)
            {
                loadedTables[tableName] = LoadTable(db, tableName);
            }
            DisplayCurrentTable(currentTableName.Text);
        }

        private void UpdateTable(Database db, String tableName) {
            loadedTables[tableName] = LoadTable(db, tableName);
            DisplayCurrentTable(currentTableName.Text);
        }

        private void DisplayCurrentTable(String tableName) {
            dataGridView1.DataSource = loadedTables[tableName];
            currentTableName.Text = tableName;
        }
        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = tablesListBox.SelectedItem;
            if (selectedItem != null)
                DisplayCurrentTable((String)selectedItem);
        }

        private void LoadTables()
        {
            Database db = new Database();
            db.OpenConnection();
            tablesListBox.Items.Clear();
            tablesNames.Clear();
            tablesColumns.Clear();
            loadedTables.Clear();
            primaryKeys.Clear();
            try
            {
                tablesNames = LoadTablesNames(db);
                tablesColumns = LoadTablesColumns(db);
                foreach (String name in tablesNames)
                {
                    tablesListBox.Items.Add(name);
                    loadedTables.Add(name, LoadTable(db, name));
                    primaryKeys.Add(name, LoadPrimaryKeys(db, name));
                }
                DisplayCurrentTable(tablesNames[0]);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Wrong database. Message:" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void requestsButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            try
            {
                var requests = new List<String>();
                DataTable dt = db.GetConnection().GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "VIEW" });
                foreach (DataRow row in dt.Rows)
                    requests.Add(row["TABLE_NAME"].ToString());

                RequestsCall requestsWindow = new RequestsCall(requests);
                DialogResult res = requestsWindow.ShowDialog();
                if (res != DialogResult.OK)
                    return;
                String selectedReq = requestsWindow.GetSelected();

                RequestsResult result = new RequestsResult(selectedReq, LoadTable(db, selectedReq));
                result.Show();
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private List<String> getAllParametersFromProcedure(String procedure)
        {
            List<String> pars = new List<string>();
            var BegIndexes = new List<int>();
            var EndIndexes = new List<int>();

            for (int i = procedure.IndexOf('['); i > -1; i = procedure.IndexOf('[', i + 1))
                BegIndexes.Add(i);
            for (int i = procedure.IndexOf(']'); i > -1; i = procedure.IndexOf(']', i + 1))
                EndIndexes.Add(i);

            if (BegIndexes.Count != EndIndexes.Count || BegIndexes.Count == 0)
                return pars;

            for (int i = 0; i < EndIndexes.Count; i++)
            {
                int b = BegIndexes[i] + 1;
                int e = EndIndexes[i] - b;
                String param = procedure.Substring(b, e);
                if (param.ToLower().IndexOf("count") != -1)
                    continue;
                pars.Add(param);
            }
            return pars;
        }

        private void proceduresButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Dictionary<String, String> proceduresRepresentation = new Dictionary<String, String>();
            db.OpenConnection();
            try
            {
                DataTable dt = db.GetConnection().GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, null);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["PROCEDURE_NAME"].ToString().IndexOf("~") == 0)
                        continue;
                    proceduresRepresentation.Add(row["PROCEDURE_NAME"].ToString(), row["PROCEDURE_DEFINITION"].ToString());
                }
                RequestsCall requestsWindow = new RequestsCall(new List<String>(proceduresRepresentation.Keys));
                DialogResult res = requestsWindow.ShowDialog();
                if (res != DialogResult.OK)
                    return;
                String selectedReq = requestsWindow.GetSelected();

                String query = "EXEC [" + selectedReq + "] ";

                OleDbCommand command = db.GetConnection().CreateCommand();
                int i = 0; // нужен будет для порядка входящих параметров.
                foreach (String param in
                         getAllParametersFromProcedure(proceduresRepresentation[selectedReq])) {
                    if (!tablesColumns.Contains(param)) {
                        InputParam inputParam = new InputParam(param);
                        inputParam.ShowDialog();
                        String data = inputParam.GetInputData();
                        query += $" \'@param{i}'";
                        command.Parameters.AddWithValue($"@param{i}", data);
                        if (inputParam.DialogResult != DialogResult.OK)
                            return;
                        i++;
                    }
                }
                command.CommandText = query.Substring(0, query.Length - 1);

                OleDbDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    DataTable schemaTable = reader.GetSchemaTable();
                    DataTable data = new DataTable();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string colName = row.Field<string>("ColumnName");
                        Type t = row.Field<Type>("DataType");
                        data.Columns.Add(colName, t);
                    }
                    while (reader.Read())
                    {
                        var newRow = data.Rows.Add();
                        foreach (DataColumn col in data.Columns)
                        {
                            newRow[col.ColumnName] = reader[col.ColumnName];
                        }
                    }
                    RequestsResult requestResult = new RequestsResult(selectedReq, data);
                    requestResult.Show();                
                }
                UpdateTables(db);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DynamicInputParamBox inputFields;
            int i;

            db.OpenConnection();
            try
            {
                inputFields = new DynamicInputParamBox("ADD", currentTableName.Text, (DataTable)dataGridView1.DataSource);
                if (inputFields.ShowDialog() != DialogResult.OK)
                    return;

                String insertString = $"INSERT INTO [{currentTableName.Text}] VALUES(";
                bool isFirstParam = true;
                i = 0;
                foreach (DataColumn column in ((DataTable)dataGridView1.DataSource).Columns) {
                    if (!isFirstParam)
                        insertString += ", ";
                    else
                        isFirstParam = false;
                    insertString += $"@{i}";
                    i++;
                }
                insertString += ")";

                OleDbCommand command = new OleDbCommand(insertString, db.GetConnection());
                List<String> inputs = inputFields.getFieldsData();
                i = 0;
                foreach (DataColumn column in ((DataTable)dataGridView1.DataSource).Columns)
                {
                    if (column.DataType == typeof(int))
                    {
                        int result = int.Parse(inputs[i]);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(double))
                    {
                        double result = double.Parse(inputs[i]);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTime result = DateTime.Parse(inputs[i]);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(short)) {
                        short result = short.Parse(inputs[i]);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{i}", inputs[i]);
                    }
                    i++;
                }

                if (command.ExecuteNonQuery() == 1)
                    UpdateTable(db, currentTableName.Text);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DynamicInputParamBox inputFields;

            db.OpenConnection();
            try 
            {
                OleDbCommand command = new OleDbCommand();
                DataRow defaultRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;
                inputFields = new DynamicInputParamBox("UPDATE", currentTableName.Text, (DataTable)dataGridView1.DataSource, 
                                                       primaryKeys[currentTableName.Text], defaultRow);
                if (inputFields.ShowDialog() != DialogResult.OK)
                    return;

                String setPart = "", wherePart = "";
                String updateString = $"UPDATE [{currentTableName.Text}]";
                List<String> inputs = inputFields.getFieldsData();

                int i = 0; // для присваивания параметров внутри команды.
                int j = 0; // для хождения по коллекции возвращённых результатов.
                bool setBeginFlag = true, whereBeginFlag = true; // флаги, обозначающие начала конструкций частей SET и WHERE.
                foreach (DataColumn column in ((DataTable)(dataGridView1.DataSource)).Columns) {
                    if (primaryKeys[currentTableName.Text].Contains(column.ColumnName))
                        continue;

                    String argument = inputs[j++];
                    if (!setBeginFlag)
                        setPart += ", ";
                    else
                        setBeginFlag = false;

                    setPart += $"[{column.ColumnName}]=@{i}";

                    if (column.DataType == typeof(int))
                    {
                        int result = int.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(double))
                    {
                        double result = double.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTime result = DateTime.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(short))
                    {
                        short result = short.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{i}", argument);
                    }
                    i++;
                }

                j = 0;
                foreach (DataColumn column in ((DataTable)(dataGridView1.DataSource)).Columns)
                {
                    if (!primaryKeys[currentTableName.Text].Contains(column.ColumnName))
                        continue;

                    String argument = inputs[j++];
                    if (!whereBeginFlag)
                        wherePart += "AND ";
                    else
                        whereBeginFlag = false;

                    wherePart += $"[{column.ColumnName}]=@{i} ";

                    if (column.DataType == typeof(int))
                    {
                        int result = int.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(double))
                    {
                        double result = double.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTime result = DateTime.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(short))
                    {
                        short result = short.Parse(argument);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{i}", argument);
                    }
                    i++;                 
                }

                if (setPart.Length == 0 || wherePart.Length == 0)
                {
                    MessageBox.Show("You can't update this element. Delete this and create a new element.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }

                updateString += " SET " + setPart + " WHERE " + wherePart;
                command.Connection = db.GetConnection();
                command.CommandText = updateString;

                if (command.ExecuteNonQuery() == 1)
                    UpdateTable(db, currentTableName.Text);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            try 
            {
                DialogResult res = MessageBox.Show("Do you want to delete this row?", "Warning",
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button1,
                                   MessageBoxOptions.DefaultDesktopOnly);
                if (res != DialogResult.Yes)
                    return;

                DataRow defaultRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;
                OleDbCommand command = new OleDbCommand();

                String deleteString = $"DELETE FROM [{currentTableName.Text}] WHERE ";
                int i = 0; // для присваивания параметров внутри команды.
                bool whereBeginFlag = true; // флаг, что это первый параметр в конструкции WHERE.
                foreach (DataColumn column in ((DataTable)(dataGridView1.DataSource)).Columns) {
                    if (!primaryKeys[currentTableName.Text].Contains(column.ColumnName))
                        continue;

                    if (!whereBeginFlag)
                        deleteString += "AND";
                    else
                        whereBeginFlag = false;
                    deleteString += $"[{column.ColumnName}]=@{i}";

                    String fieldData = defaultRow[column].ToString();
                    if (column.DataType == typeof(int))
                    {
                        int result = int.Parse(fieldData);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(double))
                    {
                        double result = double.Parse(fieldData);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTime result = DateTime.Parse(fieldData);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else if (column.DataType == typeof(short))
                    {
                        short result = short.Parse(fieldData);
                        command.Parameters.AddWithValue($"@{i}", result);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{i}", fieldData);
                    }
                    i++;
                }
                command.Connection = db.GetConnection();
                command.CommandText = deleteString;

                if (command.ExecuteNonQuery() == 1)
                    UpdateTable(db, currentTableName.Text);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
