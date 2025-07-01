using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponAPIController(AppDbContext _db) : ControllerBase
    {
        [HttpGet]
        public ResponseDto GetList()
        {
            try
            {
                List<Coupon> res = _db.Coupons.ToList();

                return new ResponseDto()
                {
                    Result = res,
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        [HttpGet("{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon res = _db.Coupons.First(c => c.CouponId == id);

                return new ResponseDto()
                {
                    Result = res,
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }
    }
}
