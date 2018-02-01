[HttpPost]
public ActionResult Index (HttpPostedFileBase file) {

    if (file.ContentLength > 0) {
        var fileName = Path.GetFileName (file.FileName);
        var path = Path.Combine (Server.MapPath ("~/App_Data/uploads"), fileName);
        file.SaveAs (path);
    }

    return RedirectToAction ("Index");
}


var file = MockRepository.GenerateStub<HttpPostedFileBase> ();
file.Expect (f => f.ContentLength).Return (1);
file.Expect (f => f.FileName).Return ("myFileName");
controller.Index (file);