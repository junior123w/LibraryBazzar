using LibraryBazzar.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBazzar.Components.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var menuItems = new List<MenuItem> {
                new MenuItem{Controller = "Home" , Action= "Index" , Label="Home"},

                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="Review" ,DropDownItems =new List<MenuItem>{
                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="List"},
                new MenuItem{Controller = "Reviews" , Action= "Create" , Label="Create"},
                } },
                new MenuItem{Controller = "Books" , Action= "Index" , Label="Book" ,DropDownItems =new List<MenuItem>{
                new MenuItem{Controller = "Books" , Action= "Index" , Label="List"},
                new MenuItem{Controller = "Books" , Action= "Create" , Label="Create"},
                } },
                new MenuItem{Controller = "Home" , Action= "Privacy" , Label="Privacy"},
            };
            return View(menuItems);

        }
    }
}
