﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatRooms()
        {
            return View();
        }
    }
}
