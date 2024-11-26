using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;
using Lab4.Service;

namespace Lab4.Controllers
{
    public class PerformedServicesController : Controller
    {
        private readonly CachedDataService _cachedDataService;

        public PerformedServicesController(CachedDataService cachedDataService)
        {
            _cachedDataService = cachedDataService;
        }

        // GET: PerformedServices
        public async Task<IActionResult> Index()
        {
            return View(_cachedDataService.GetPerformedServices());
        }
    }
}
