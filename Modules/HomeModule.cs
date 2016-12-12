using Nancy;
using System.Collections.Generic;
using System;
using ToDoList;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["ToDo.cshtml"];
      };

    }
  }
}
