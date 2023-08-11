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
                new MenuItem{ Controller="Shop" , Action="Index", Label="Shop"},
                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="Review" ,DropDownItems =new List<MenuItem>{
                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="List"},
                new MenuItem{Controller = "Reviews" , Action= "Create" , Label="Create"},
                } , Authorized=true },
                new MenuItem{Controller = "Books" , Action= "Index" , Label="Book" ,DropDownItems =new List<MenuItem>{
                new MenuItem{Controller = "Books" , Action= "Index" , Label="List"},
                new MenuItem{Controller = "Books" , Action= "Create" , Label="Create"},
                }, Authorized=true ,AllowedRoles = new List<string> { "Administrator" } },
                new MenuItem{Controller = "Home" , Action= "Privacy" , Label="Privacy"},
            };
            return View(menuItems);

        }
    }
}
