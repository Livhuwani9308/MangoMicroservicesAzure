using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponAPIController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpGet("/api/coupon/list")]
        public ResponseDto GetList()
        {
            try
            {
                List<Coupon> res = _db.Coupons.ToList();

                return new ResponseDto()
                {
                    Result = _mapper.Map<List<CouponDto>>(res),
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

        [HttpGet("/api/coupon/getbyid/{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon res = _db.Coupons.First(c => c.CouponId == id);

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(res),
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

        [HttpGet("/api/coupon/getbycode/{code}")]
        public ResponseDto GetById(string code)
        {
            try
            {
                Coupon res = _db.Coupons.First(c => c.CouponCode == code);

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(res),
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

        [HttpPost("/api/coupon/create")]
        public ResponseDto Create([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);

                _db.Coupons.Add(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(obj),
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

        [HttpPut("/api/coupon/update")]
        public ResponseDto Update([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);

                _db.Coupons.Update(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(obj),
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

        [HttpDelete("/api/coupon/delete")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = null,
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
