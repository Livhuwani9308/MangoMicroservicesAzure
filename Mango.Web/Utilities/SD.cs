namespace Mango.Web.Utilities
{
    public class SD // StaticDetail
    {
        public static string CouponAPIBase { get; set; } = string.Empty;

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
