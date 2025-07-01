using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponAPIController(AppDbContext _db) : ControllerBase
    {
        [HttpGet]
        public object GetList()
        {
            List<Coupon> repsonse = _db.Coupons.ToList();

            return repsonse;
        }

        [HttpGet("{id:int}")]
        public object GetById(int id)
        {
            Coupon repsonse = _db.Coupons.First(c => c.CouponId == id);

            return repsonse;
        }
    }
}
