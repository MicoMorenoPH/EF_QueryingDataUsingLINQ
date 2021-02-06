QUERYING DATA USING LINQ

LINQ TO SQL TUTORIAL
1. ADD LINQ TO SQL ORM
https://www.completecsharptutorial.com/mvc-articles/add-missing-linq-sql-class-vs-2017-2019.php
2. SOURCE OF TUTORIAL
https://csharp-video-tutorials.blogspot.com/2014/09/linq-to-sql-tutorial.html
https://www.youtube.com/playlist?list=PL6n9fhu94yhXCHPed2Q9oBkgvzw9Re8hC

SET UP
public PlutoDBContext()
    : base("name=PlutoDBContext")
{
    Configuration.ProxyCreationEnabled = false;
}


1. CREATE

public ActionResult Save() {

    try {
        var context = new HPCOMMON2Entities();
        int i = 0;

        var department = new Department()
        {
            Name = "ASSET",
            Location = "Mico",
        };

        context.Departments.Add(department);
        context.SaveChanges();

        return Json("Done", JsonRequestBehavior.AllowGet);
    } catch (Exception e) {
        return Json("Failed", JsonRequestBehavior.AllowGet);
    }
}


2. READ ALL

2.1 READ FROM STORED PROCEDURE
public ActionResult SelectTest() {

   var context = new PlutoDBContext(); //..database connection
   var data = context.GetCourses(); // stored procedure function
   var retValue = data.Select(m => new { m.Title, m.Description }).ToList(); //..select defined columns
   var retValue = data.Select(m => m).ToList(); //..selectall columns
   return Json(retValue, JsonRequestBehavior.AllowGet);
}

2.2 READ FROM PHYSICAL TABLE
public ActionResult SelectFromTable()
{

    var context = new PlutoDBContext();
    var sysdata = context.Courses.Select(m => m).ToList();

    return Json(sysdata, JsonRequestBehavior.AllowGet);
}


2.1. READ WITH WHERE CLAUSE

public ActionResult SelectWithParam()
{

    var context = new PlutoDBContext();
    var table = context.Courses;
    var sysData = table.Where(c => c.Title.Contains("C# Advanced") && c.Price == 100).OrderBy(c => c.Description).ToList();
    return Json(sysData, JsonRequestBehavior.AllowGet);
}


3. UPDATE

4. DELETE
