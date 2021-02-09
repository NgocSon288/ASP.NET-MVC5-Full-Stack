using FShop.Common;
using FShop.Common.ModelSession;
using FShop.Model.Models;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var member = GetMemberSession();

            if (member == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index",
                    Area = "Admin"
                }));
            }

            base.OnActionExecuting(filterContext);
        }

        public void SetMemberSession(Member member)
        {
            Session.Add(Constants.MEMBER_SESSION, AutoMapper.Mapper.Map<MemberSession>(member));
        }

        public MemberSession GetMemberSession()
        {
            return Session[Constants.MEMBER_SESSION] as MemberSession;
        }

        public void DeleteMemberSession()
        {
            Session[Constants.MEMBER_SESSION] = null;
        }
    }
}