using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Data;

namespace AtesBocegi.App.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BaseAdminPanelController : Controller
    {
        public DAO db = new DAO();
    }
}