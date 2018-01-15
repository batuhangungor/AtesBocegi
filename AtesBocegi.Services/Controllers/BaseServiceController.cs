using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Data;

namespace AtesBocegi.Services.Controllers
{
    public class BaseServiceController : Controller
    {
        public DAO db = new DAO();
    }
}