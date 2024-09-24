using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Voter.Interfaces;
using Voter.Models;
using Voter.Repository;

namespace Voter.Controllers
{
    public class VoterController : Controller
    {
        private IVOTERRepository IVOTERRepository;
        public VoterController(IVOTERRepository VoterRepository)
        {
            IVOTERRepository = VoterRepository;
        }


        public IActionResult Index()
        {

            //----For State-----
            List<VoterModel> statelist = IVOTERRepository.getState(0);  // create  a list to store rhe state name and ids

            List<SelectListItem> statedropdown = new List<SelectListItem>();
            statedropdown.Add(new SelectListItem { Text = "Select State", Value = "" });
            foreach (var st in statelist)
            {
                statedropdown.Add(new SelectListItem { Text = st.STATE_NAME, Value = st.STATE_ID.ToString() });
            }
            ViewBag.state = new SelectList(statedropdown, "Value", "Text");





            //----For Gender-----
            List<VoterModel> genderlist = IVOTERRepository.getGender(0);
            ViewBag.genderlist = genderlist;



            List<VoterModel> Vote = IVOTERRepository.GetVote(0);
            ViewBag.Vote = Vote;
            return View();
        }

        public async Task<IActionResult> SaveVote(VoterModel model)
        {



            if (model.VOTER_KEY == 0)
            {
                int r = IVOTERRepository.SaveVote(model, "INSERT");

            }
            else
            {
                int r = IVOTERRepository.SaveVote(model, "UPDATE");


            }
            
            return Redirect("/Voter/Index");
        }

        [HttpPost]
        public IActionResult DeleteVote(int id)
        {
            VoterModel model = new VoterModel();
            model.VOTER_KEY = id;
            int r = IVOTERRepository.DeleteVote(model, "DELETE");

            return Json(new { res = r });
        }


        [HttpGet]
        public async Task<JsonResult> EditVote(int id)
        {

            var lstobj = IVOTERRepository.GetVote(id);
            if (lstobj.Count == 1)
            {
                return Json(lstobj[0]);
            }

            return null;

            //List<VoterModel> lstobj = IVOTERRepository.GetVote(id);

            //if (lstobj.Count == 1)
            //{
            //    return Json(lstobj.FirstOrDefault());
            //}

            //return null;
        }
    }
}
