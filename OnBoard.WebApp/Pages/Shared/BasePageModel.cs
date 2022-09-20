using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnBoard.WebApp.Pages.Shared
{
    public class BasePageModel : PageModel
    {
        public BasePageModel() { }

        public bool IsAdmin()
        {
            if (User.IsInRole("Administrator"))
                return true;
            else
                return false;
        }

        public bool IsAdminOrManager()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Manager"))
                return true;
            else
                return false;
        }
    }
}
