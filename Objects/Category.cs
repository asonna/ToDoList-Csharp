using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ToDoList
{
  public class Category // Same name as TABLE name but starting with Cap letter and without "s"
  {

    public int Id {get; set;}
    public string Name {get; set;}

    public Category(string description, int id = 0)
    {
      this.Id = id;
      this.Name = description;
    }

    public override bool Equals(System.Object otherCategory)
    {
      if (!(otherCategory is Category))
      {
        return false;
      }
      else
      {
        Category newCategory = (Category) otherCategory;
        bool idEquality = (this.Id == newCategory.Id);
        bool descriptionEquality = (this.Name == newCategory.Name);
        return (idEquality && descriptionEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.Name.GetHashCode();
    }

    public static List<Category> GetAll()
    {
      List<Category> AllCategories = new List<Category>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int categoryId = rdr.GetInt32(0);
        string categoryName = rdr.GetString(1);
        Category newCategory = new Category(categoryName, categoryId);
        AllCategories.Add(newCategory);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return AllCategories;
    }

// Save() - In the cmd variable, we use the parameter placeholder @CategoryName. We want to use parameter placeholders whenever we are entering data that a user enters. Information stored to a parameter is treated as field data and not part of the SQL statement, which helps to protect our application from SQL injection (nicely illustrated in this comic).
    public void Save()

    {
      SqlConnection conn = DB.Connection(); // A SqlConnection object basically represents the database using the connection information that we set it to
      conn.Open();  // Thi open the connection to the database so that the code can execute

      SqlCommand cmd = new SqlCommand("INSERT INTO categories (description) OUTPUT INSERTED.id VALUES (@CategoryName);", conn); // SqlCommand objects are used to send SQL statements to the database. It takes two arguments: the command we want to execute, and the database connection the statement is being sent to. In this case they are (categoryId, CategoryName). - see C# database basics To do list with databases part 3 - working with data with ADO.NET

      SqlParameter descriptionParam = new SqlParameter();
      descriptionParam.ParameterName = "@CategoryName";
      descriptionParam.Value = this.Name;

      cmd.Parameters.Add(descriptionParam);

      SqlDataReader rdr = cmd.ExecuteReader(); // This command is actually executed when we use the ExecuteReader() method on cmd. The result set is the table

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close(); // This closes the connection to the database so that the code can execute
      }
    }

//Find() - Here we are using a SELECT query using WHERE id = @CategoryId. We set @CategoryId equal to the id that we pass into the Find() method, and convert it to a string so that it can be used in the query string. Then we read the result of the query to create a new Category named foundCategory and return it.
    public static Category Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories WHERE id = @CategoryId;", conn);
      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@CategoryId";
      categoryIdParameter.Value = id.ToString();
      cmd.Parameters.Add(categoryIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundCategoryId = 0;
      string foundCategoryName = null;
      while(rdr.Read())
      {
        foundCategoryId = rdr.GetInt32(0);
        foundCategoryName = rdr.GetString(1);
      }
      Category foundCategory = new Category(foundCategoryName, foundCategoryId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundCategory;
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM categories WHERE id = @CategoryId;", conn);

      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@CategoryId";
      categoryIdParameter.Value = this.Id;

      cmd.Parameters.Add(categoryIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public void AddTask(Task newTask)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO categories_tasks (category_id, task_id) VALUES (@CategoryId, @TaskId);", conn);
      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@CategoryId";
      categoryIdParameter.Value = this.GetId();
      cmd.Parameters.Add(categoryIdParameter);

      SqlParameter taskIdParameter = new SqlParameter();
      taskIdParameter.ParameterName = "@TaskId";
      taskIdParameter.Value = newTask.GetId();
      cmd.Parameters.Add(taskIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM categories;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
