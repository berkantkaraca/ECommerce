﻿using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutRenderBodyHeaderComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
