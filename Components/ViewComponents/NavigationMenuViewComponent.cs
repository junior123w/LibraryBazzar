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
                new MenuItem{ Controller="Shop" , Action="Index", Label="Shop",},
                new MenuItem { Controller = "Shop", Action = "ViewMyCart", Label = "Cart", Authorized = true },
                new MenuItem { Controller = "Shop", Action = "Orders", Label = "My Orders", Authorized = true },
                  new MenuItem { Controller = "Orders", Action = "Orders", Label = "Admin", Authorized = true, AllowedRoles = new List<string> { "Administrator" },
                      DropDownItems = new List<MenuItem> {
                          new MenuItem { Controller = "Orders", Action = "Index", Label = "Orders" },
                          new MenuItem { Controller = "Carts", Action = "Index", Label = "Carts" },
                        new MenuItem { Controller = "Reviews", Action = "Index", Label = "Review" },
                        new MenuItem { Controller = "Books", Action = "Index", Label = "Books" },

                      } 
                  },
                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="Review" ,DropDownItems =new List<MenuItem>{
                new MenuItem{Controller = "Reviews" , Action= "Index" , Label="List"},
                new MenuItem{Controller = "Reviews" , Action= "Create" , Label="Create"},
                } , Authorized=true },
                new MenuItem { Controller = "Home", Action = "Contact", Label = "Contact" },
                new MenuItem{Controller = "Home" , Action= "Privacy" , Label="Privacy"},
            };
            return View(menuItems);
        }
    }
}

