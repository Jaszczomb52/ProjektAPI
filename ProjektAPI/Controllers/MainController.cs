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
            Models.Pracownicy? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.Pracownicy>.Add(temp);
            return check;
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(Models.Pracownicy employee)
        {
            Models.Pracownicy? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.Pracownicy>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteEmployee/{i}")]
        public string DeleteEmployee(int i)
        {
            string check = Methods<Models.Pracownicy>.Delete(i);
            return check;
        }

        [HttpGet("GetProducents")]
        public string GetProducents()
        {
            List<Models.Producent> temp = Methods < Models.Producent>.Get();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddProducent")]
        public string AddProducent(Models.Producent employee)
        {
            Models.Producent? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.Producent>.Add(temp);
            return check;
        }

        [HttpPut("UpdateProducent")]
        public string UpdateProducent(Models.Producent employee)
        {
            Models.Producent? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.Producent>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteProducent/{i}")]
        public string DeleteProducent(int i)
        {
            string check = Methods<Models.Producent>.Delete(i);
            return check;
        }

        [HttpGet("GetTypes")]
        public string GetTypes()
        {
            List<Models.TypCzesci> temp = Methods<Models.TypCzesci>.Get();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddType")]
        public string AddType(Models.TypCzesci employee)
        {
            Models.TypCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.TypCzesci>.Add(temp);
            return check;
        }

        [HttpPut("UpdateType")]
        public string UpdateType(Models.TypCzesci employee)
        {
            Models.TypCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.TypCzesci>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteType/{i}")]
        public string DeleteType(int i)
        {
            string check = Methods<Models.TypCzesci>.Delete(i);
            return check;
        }

        [HttpGet("GetModels")]
        public string GetModels()
        {
            List<Models.ModelCzesci> temp = Methods<Models.ModelCzesci>.Get();
            var result = JsonConvert.SerializeObject(temp);
            return result;
        }

        [HttpPost("AddModel")]
        public string AddModel(Models.ModelCzesci employee)
        {
            Models.ModelCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.ModelCzesci>.Add(temp);
            return check;
        }

        [HttpPut("UpdateModel")]
        public string UpdateModel(Models.ModelCzesci employee)
        {
            Models.ModelCzesci? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.ModelCzesci>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteModel/{i}")]
        public string DeleteModel(int i)
        {
            string check = Methods<Models.ModelCzesci>.Delete(i);
            return check;
        }

        [HttpGet("GetWarehouse")]
        public List<Models.CzescNaMagazynie> GetWarehouse()
        {
            return CustomMethods.GetWarehouse();
        }

        [HttpPost("AddSpec")]
        public string InsertSpec(Models.SpecjalizacjePracownika employee)
        {
            Models.SpecjalizacjePracownika? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.SpecjalizacjePracownika>.Add(temp);
            return check;
        }

        [HttpPut("UpdateSpec")]
        public string UpdateSpec(Models.SpecjalizacjePracownika employee)
        {
            Models.SpecjalizacjePracownika? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.SpecjalizacjePracownika>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteSpec/{i}")]
        public string DeleteSpec(int i)
        {
            string check = Methods<Models.SpecjalizacjePracownika>.Delete(i);
            return check;
        }

        [HttpPost("AddCzesc")]
        public string InsertCzesc(Models.CzescNaMagazynie employee)
        {
            Models.CzescNaMagazynie? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.CzescNaMagazynie>.Add(temp);
            return check;
        }

        [HttpPut("UpdateCzesc")]
        public string UpdateCzesc(Models.CzescNaMagazynie employee)
        {
            Models.CzescNaMagazynie? temp = employee;
            if (temp == null)
                return "Null";
            string check = Methods<Models.CzescNaMagazynie>.Modify(temp);
            return check;
        }

        [HttpDelete("DeleteCzesc/{i}")]
        public string DeleteCzesc(int i)
        {
            string check = Methods<Models.CzescNaMagazynie>.Delete(i);
            return check;
        }
    }
}
