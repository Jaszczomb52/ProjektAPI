using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjektAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("Employees")]
        public string GetEployees()
        {
            List<Models.Pracownicy> temp = CustomMethods.GetZlecenia();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpGet("GetGeneral")]
        public string GetGeneral()
        {
            List<Zlecenia> temp = CustomMethods.LoadGeneralData();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddEmployee")]
        public string AddEmployee(Models.Pracownicy employee)
        {
            //JsonConvert.DeserializeObject<Models.Pracownicy>(employee);
            Models.Pracownicy? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.InsertEmployee(temp);
            return check;
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(Models.Pracownicy employee)
        {
            Models.Pracownicy? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.UpdateEmployee(temp);
            return check;
        }

        [HttpDelete("DeleteEmployee/{i}")]
        public string DeleteEmployee(int i)
        {
            string check = CustomMethods.DeleteEmployee(i);
            return check;
        }

        [HttpGet("GetProducents")]
        public string GetProducents()
        {
            List<Models.Producent> temp = CustomMethods.GetProducents();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddProducent")]
        public string AddProducent(Models.Producent employee)
        {
            Models.Producent? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.AddProducent(temp);
            return check;
        }

        [HttpPut("UpdateProducent")]
        public string UpdateProducent(Models.Producent employee)
        {
            Models.Producent? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.ModifyProducent(temp);
            return check;
        }

        [HttpDelete("DeleteProducent/{i}")]
        public string DeleteProducent(int i)
        {
            string check = CustomMethods.DeleteProducent(i);
            return check;
        }

        [HttpGet("GetTypes")]
        public string GetTypes()
        {
            List<Models.TypCzesci> temp = CustomMethods.GetTypes();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddType")]
        public string AddType(Models.TypCzesci employee)
        {
            Models.TypCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.AddType(temp);
            return check;
        }

        [HttpPut("UpdateType")]
        public string UpdateType(Models.TypCzesci employee)
        {
            Models.TypCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.ModifyType(temp);
            return check;
        }

        [HttpDelete("DeleteType/{i}")]
        public string DeleteType(int i)
        {
            string check = CustomMethods.DeleteType(i);
            return check;
        }

        [HttpGet("GetModels")]
        public string GetModels()
        {
            List<Models.ModelCzesci> temp = CustomMethods.GetModels();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddModel")]
        public string AddModel(Models.ModelCzesci employee)
        {
            Models.ModelCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.AddModel(temp);
            return check;
        }

        [HttpPut("UpdateModel")]
        public string UpdateModel(Models.ModelCzesci employee)
        {
            Models.ModelCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = CustomMethods.ModifyModel(temp);
            return check;
        }

        [HttpDelete("DeleteModel/{i}")]
        public string DeleteModel(int i)
        {
            string check = CustomMethods.DeleteModel(i);
            return check;
        }

        [HttpGet("GetWarehouse")]
        public List<Models.CzescNaMagazynie> GetWarehouse()
        {
            return CustomMethods.GetWarehouse();
        }
    }
}
