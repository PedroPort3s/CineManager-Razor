using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Services.IdentityMultifator
{
    public class ModelAdmin : PageModel
    {
        public IActionResult OnGet()
        {
            var twoFactorEnabled = User.Claims.FirstOrDefault(x => x.Type == "amr");

            if (twoFactorEnabled != null && "mfa".Equals(twoFactorEnabled.Value))
            {

            }
            else
            {
                return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
