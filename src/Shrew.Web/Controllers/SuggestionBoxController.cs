using System.Threading.Tasks;
using System.Web.Mvc;
using Fabrik.Common.Web;
using MediatR;
using Shrew.Web.Infrastructure.SuggestionsBox;

namespace Shrew.Web.Controllers
{
    /// <summary>
    /// In this controller I based the validation 
    /// in this post http://benfoster.io/blog/automatic-modelstate-validation-in-aspnet-mvc
    /// https://github.com/benfoster/Fabrik.Common/tree/master/src/Fabrik.Common.Web
    /// </summary>
    public class BoxController : Controller
    {
        private readonly IMediator mediator;

        public BoxController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // TODO: Review cache to improve it
        //[OutputCache(Duration = 10, VaryByParam = "none")]
        public async Task<ActionResult> Index()
        {
            var boxes = await mediator.SendAsync(new IndexQuery());
            return View(boxes);
        }

        [ImportModelStateFromTempData]
        public async Task<ActionResult> Details(int id)
        {
            return View(await mediator.SendAsync(new DetailsQuery(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public async Task<ActionResult> Details(DetailsModel detailsModel)
        {
            await mediator.SendAsync(new DetailsCommand(detailsModel));
            //var box = await mediator.SendAsync(new DetailsQuery(detailsModel.Id));
            //box.NewSuggestion = string.Empty;

            return RedirectToAction("Details", new { id = detailsModel.Id });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateModel createModel)
        {
            if (!ModelState.IsValid) return View();

            mediator.SendAsync(new CreateCommand(createModel));

            return RedirectToAction("Index");
        }
    }
}