using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Controllers.MVC_Controller;
using Task_Management_System.Entities.Api;
using Task_Management_System.Entities.Data;

namespace Task_Management_System.Controllers.API_Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DM_Project_ApiController : ControllerBase
    {
        DM_Project_Controller objCtrl_Project = new DM_Project_Controller();

        // Lấy danh sách dự án 
        [HttpGet]
        public IActionResult Get_Projects() 
        {
            Thread.Sleep(10000);

            List<DM_Project> lstProjects = objCtrl_Project.Get_All_Project();
            List<Response_Project> lstRes = new List<Response_Project>();
            foreach (DM_Project p in lstProjects)
            {
                Response_Project objRes = new Response_Project();
                objRes.Id = p.Id;
                objRes.Project_Name = p.Project_Name;
                objRes.Project_Description = p.Project_Description;
                objRes.Deleted = p.Deleted;
                lstRes.Add(objRes);
            }
            

            return Ok(lstRes);

        }

        // Lấy thông tin dự án theo Id
        [HttpGet("{id}")]
        public IActionResult Get_Project_By_Id(int id)
        {
            DM_Project objProject = objCtrl_Project.Get_Project_By_Id(id);

            if (objProject == null)
                return NotFound("Không tìm thấy dự án!");

            return Ok(objProject);
        }

        // Thêm dự án mới
        [HttpPost]
        public IActionResult Create_Project([FromBody] DM_Project newProject)
        {
            objCtrl_Project.Insert_Project(newProject);

            return NoContent();
        }

        // Cập nhật dự án
        [HttpPut]
        public IActionResult Update_Project([FromBody] DM_Project updatedProject)
        {
            objCtrl_Project.Update_Project(updatedProject);

            return NoContent();
        }

        // Xoá dự án
        [HttpDelete("{id}")]
        public IActionResult Delete_Project(int id)
        {
            objCtrl_Project.Delete_Project(id);

            return NoContent();
        }

    }
}
