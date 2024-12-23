using contosopizza.data;
using contosopizza.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace contosopizza.Controllers;

[ApiController]
[Route("[Controller]")]
public class CouponController : ControllerBase
{

    PromotionsContext _context;
    public CouponController(PromotionsContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all coupons
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Coupon> GetAll()
    {

        return _context.Coupons.AsNoTracking().ToList();
    }


}