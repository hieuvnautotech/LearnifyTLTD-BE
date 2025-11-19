using Microsoft.AspNetCore.Mvc;
using API.Dtos.Course;
using Core.Interfaces; // nếu dùng repository interface từ Core
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        // ... rest of controller
    }
}
