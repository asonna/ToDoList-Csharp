// using Xunit;
// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
// using ToDo; // Not needed always
//
// namespace  ToDoList
// {
//   public class CategoryTest : IDisposable
//   {
//     public CategoryTest()
//     {
//       DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ToDo_test;Integrated Security=SSPI;";
//     }
//
//     [Fact]
//     public void GetAll_DatabaseEmptyAtFirst_0()
//     {
//       //Arrange, Act
//       int result = Category.GetAll().Count;
//
//       //Assert
//       Assert.Equal(0, result);
//     }
//
//     [Fact]
//     public void Equal_AreObjectsEquivalent_true()
//     {
//       //Arrange, Act
//       Category firstCategory = new Category("Veggies");
//       Category secondCategory = new Category("Veggies");
//
//       //Assert
//       Assert.Equal(firstCategory, secondCategory);
//     }
//
//     [Fact]
//     public void GetAll_SaveNewCategoryToDatabase_ListOfEnteredCategories()
//     {
//       //Arrange
//       Category testCategory = new Category("Meat");
//       testCategory.Save();
//
//       //Act
//       List<Category> result = Category.GetAll();
//       List<Category> testList = new List<Category>{testCategory};
//
//       //Assert
//       Assert.Equal(testList, result);
//     }
//
//     [Fact]
//     public void Save_SaveAssignsIdToObject_Id()
//     {
//       //Arrange
//       Category testCategory = new Category("Meat");
//       testCategory.Save();
//
//       //Act
//       Category savedCategory = Category.GetAll()[0];
//
//       int result = savedCategory.GetId();
//       int testId = testCategory.GetId();
//
//       //Assert
//       Assert.Equal(testId, result);
//     }
//
//     [Fact]
//     public void Find_FindsCategoryInDatabase_true()
//     {
//       //Arrange
//       Category testCategory = new Category("Meat");
//       testCategory.Save();
//
//       //Act
//       Category result = Category.Find(testCategory.Id);
//
//       //Assert
//       Assert.Equal(testCategory, result);
//     }
//
//     [Fact]
//   public void Delete_DeletesCategoryFromDatabase_{testCategory2}()
//     {
//       //Arrange
//       string name1 = "Home stuff";
//       Category testCategory1 = new Category(name1);
//       testCategory1.Save();
//
//       string name2 = "Work stuff";
//       Category testCategory2 = new Category(name2);
//       testCategory2.Save();
//
//       //Act
//       testCategory1.Delete();
//       List<Category> resultCategories = Category.GetAll();
//       List<Category> testCategoryList = new List<Category> {testCategory2};
//
//       //Assert
//       Assert.Equal(testCategoryList, resultCategories);
//     }
//
//     [Fact]
//     public void GetTasks_ReturnsAllCategoryTasks_taskList()
//     {
//       //Arrange
//       Category testCategory = new Category("Household chores");
//       testCategory.Save();
//
//       Task testTask1 = new Task("Mow the lawn");
//       testTask1.Save();
//
//       Task testTask2 = new Task("Buy plane ticket");
//       testTask2.Save();
//
//       //Act
//       testCategory.AddTask(testTask1);
//       List<Task> savedTasks = testCategory.GetTasks();
//       List<Task> testList = new List<Task> {testTask1};
//
//       //Assert
//       Assert.Equal(testList, savedTasks);
//     }
//
//     [Fact]
//     public void AddTask_AddsTaskToCategory_taskList()
//     {
//       //Arrange
//       Category testCategory = new Category("Household chores");
//       testCategory.Save();
//
//       Task testTask = new Task("Mow the lawn");
//       testTask.Save();
//
//       Task testTask2 = new Task("Water the garden");
//       testTask2.Save();
//
//       //Act
//       testCategory.AddTask(testTask);
//       testCategory.AddTask(testTask2);
//
//       List<Task> result = testCategory.GetTasks();
//       List<Task> testList = new List<Task>{testTask, testTask2};
//
//       //Assert
//       Assert.Equal(testList, result);
//     }
//
//     public void Dispose()
//     {
//       Task.DeleteAll();
//       Category.DeleteAll();
//     }
//   }
// }