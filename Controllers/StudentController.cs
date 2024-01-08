using Microsoft.AspNetCore.Mvc; // Added with [ApiController]

namespace API_ControllersAndRoutes.Controllers;

[ApiController] // Telling dotnet to read this file as an Api Controller
[Route("[controller]")] // Removing the need to type controller to access this file

public class StudentController : ControllerBase
{
    public List<string> studentList = new(); // Creating a new List of strings

    public StudentController() // Constructor - runs first when the class is called
    {
        studentList.Add("Isaiah");
        studentList.Add("Jessie");
    }

    [HttpGet] // use Get to get/pull data
    [Route("FetchQuest/{studentName}")] // Route name does not have to match Method name, but Routes give a specific Address to each Method
    public string GetStudents(string studentName)
    {

        return "Hello, " + studentName + ".";
    }

    [HttpPost] // use Post to add Data
    [Route("AddStudent/{studentName}")] // To pass data through Routes add /{parameter name}
    public List<string> AddStudent(string studentName)
    {
        studentList.Add(studentName);
        return studentList;
    }

    [HttpDelete] // use Delete to delete data - not really don't do this
    [Route("DeleteStudent/{studentName}")]
    public List<string> DeleteStudent(string studentName)
    {
        studentList.Remove(studentName);
        return studentList;
    }

    [HttpPut] // use Put to update data
    [Route("EditStudent/{oldName}/{newName}")]
    public List<string> UpdateStudent(string oldName, string newName)
    {
        studentList[studentList.IndexOf(oldName)] = newName; // Getting the index of the old name, and using it to locate and edit the student
        return studentList;
    }
}
