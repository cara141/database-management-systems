using Microsoft.Data.SqlClient;

namespace Lab1;

public partial class Form1 : Form
{
    void LoadParentData()
    {
        using (SqlConnection connection = new SqlConnection())
        {
            connection.ConnectionString = connection_string;
            connection.Open();
            data_set_parent.Clear();
            adapter = new SqlDataAdapter("SELECT * FROM Properties", connection);
            adapter.Fill(data_set_parent, "Properties");
            dataGridViewParent.DataSource = data_set_parent.Tables["Properties"];
        }
    }
    
    void LoadChildData()
    {
        using (SqlConnection connection = new SqlConnection())
        {
            connection.ConnectionString = connection_string;
            connection.Open();
            data_set_child.Clear();
            adapter = new SqlDataAdapter("SELECT * FROM PropertyImages", connection);
            adapter.Fill(data_set_child, "PropertyImages");
            dataGridViewChild.DataSource = data_set_child.Tables["PropertyImages"];
        }
    }
    
    void LoadChildData(int parentId)
    {
        using (SqlConnection connection = new SqlConnection(connection_string))
        {
            data_set_child.Clear();
            adapter = new SqlDataAdapter($"SELECT * FROM PropertyImages WHERE PropertyID = {parentId}", connection);
            adapter.Fill(data_set_child, "PropertyImages");
            dataGridViewChild.DataSource = data_set_child.Tables["PropertyImages"];
        }
    }

    void LoadUpdateForm()
    {
        if (dataGridViewChild.SelectedRows.Count > 0)
        {
            if(dataGridViewChild.SelectedRows[0].Cells["ImageID"].Value == DBNull.Value)
            {
                ImageIDTextBox.Text = "";
                PropertyIDTextBox.Text = "";
                ImageURLTextBox.Text = "";
                DescriptionTextBox.Text = "";
                
                return;
            }
            
            ImageIDTextBox.Text = dataGridViewChild.SelectedRows[0].Cells["ImageID"].Value?.ToString();
            PropertyIDTextBox.Text = dataGridViewChild.SelectedRows[0].Cells["PropertyID"].Value?.ToString();
            ImageURLTextBox.Text = dataGridViewChild.SelectedRows[0].Cells["ImageURL"].Value?.ToString();
            DescriptionTextBox.Text = dataGridViewChild.SelectedRows[0].Cells["Description"].Value?.ToString();
        }
        
        
    }
    
    public Form1()
    {
        InitializeComponent();
        LoadChildData();
        LoadParentData();
    }

    private void dataGridViewParent_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridViewParent.SelectedRows.Count <= 0) return;
        if (dataGridViewParent.SelectedRows[0].Cells["PropertyID"].Value != DBNull.Value)
        {
            LoadChildData((int)dataGridViewParent.SelectedRows[0].Cells["PropertyID"].Value);
        }
    }

    private void dataGridViewChild_SelectionChanged(object sender, EventArgs e)
    {
        LoadUpdateForm();
    }
    
    private void UpdateImageButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connection_string))
        {
            connection.Open();
            string query = $"UPDATE PropertyImages SET PropertyID = {PropertyIDTextBox.Text}, ImageURL = '{ImageURLTextBox.Text}', Description = '{DescriptionTextBox.Text}' WHERE ImageID = {ImageIDTextBox.Text}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            LoadChildData();
        }
        
    }

    private void DeleteImageButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connection_string))
        {
            connection.Open();
            string query = $"DELETE FROM PropertyImages WHERE ImageID = {ImageIDTextBox.Text}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            LoadChildData();
        }
        
    }
    
    private void AddImageButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connection_string))
        {
            connection.Open();
            string query = $"INSERT INTO PropertyImages (PropertyID, ImageURL, Description) VALUES ({PropertyIDTextBox.Text}, '{ImageURLTextBox.Text}', '{DescriptionTextBox.Text}')";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            LoadChildData();
        }
        
    }
}