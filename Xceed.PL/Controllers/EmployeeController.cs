using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Xceed.BLL.Interfaces;
using Xceed.BLL.Repositories;
using Xceed.DAL.Entities;
using Xceed.PL.Models;

namespace Xceed.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public EmployeeController(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = _mapper;
        }
        public  async Task<IActionResult> Index()
        {
            //var data = await unitOfWork.GetRepository<Employee ,int>().GetAll();
            var data = await unitOfWork.EmployeeRep.GetAll();
            var model = mapper.Map<List<EmployeeVM>>(data);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            AddEditEmployeeVM employeeVM = new AddEditEmployeeVM();
            var accounts = await unitOfWork.AccountRep.GetAll();
            employeeVM.accountVMs = mapper.Map<List<AccountVM>>(accounts);
            var languages = await unitOfWork.LanguageRep.GetAll();
            employeeVM.languageVMs = mapper.Map<List<LanguageVM>>(languages);
            var languageLevels = await unitOfWork.LanguageLevelRep.GetAll();
            employeeVM.language_LevelVMs = mapper.Map<List<Language_levelVM>>(languageLevels);

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditEmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var data = mapper.Map<Employee>(employeeVM);
                Employee employee = new Employee();
                employee = await unitOfWork.EmployeeRep.Add(data);
                await unitOfWork.SaveChangesAsync();
                if (employeeVM.SelectedLanguageLevelIds != null && employeeVM.SelectedLanguageLevelIds.Count > 0)
                {
                    foreach (var level in employeeVM.SelectedLanguageLevelIds)
                    {
                        EmployeeLanguageLevels employeeLanguageLevels = new EmployeeLanguageLevels();
                        employeeLanguageLevels.EmployeeId = employee.id;
                        employeeLanguageLevels.LanguageId = employee.languageId;
                        employeeLanguageLevels.Language_LevelId = level;
                        await unitOfWork.EmployeeLanguageLevelsRep.Add(employeeLanguageLevels);
                    }
                    unitOfWork.SaveChanges();
                }
                return RedirectToAction("index");
            }
            var accounts = await unitOfWork.AccountRep.GetAll();
            employeeVM.accountVMs = mapper.Map<List<AccountVM>>(accounts);
            var languages = await unitOfWork.LanguageRep.GetAll();
            employeeVM.languageVMs = mapper.Map<List<LanguageVM>>(languages);
            var languageLevels = await unitOfWork.LanguageLevelRep.GetAll();
            employeeVM.language_LevelVMs = mapper.Map<List<Language_levelVM>>(languageLevels);
            return View(employeeVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await unitOfWork.EmployeeRep.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await unitOfWork.EmployeeRep.GetById(id);
            var employeeVM = mapper.Map<AddEditEmployeeVM>(data);
            var accounts = await unitOfWork.AccountRep.GetAll();
            employeeVM.accountVMs = mapper.Map<List<AccountVM>>(accounts);
            var languages = await unitOfWork.LanguageRep.GetAll();
            employeeVM.languageVMs = mapper.Map<List<LanguageVM>>(languages);
            var languageLevels = await unitOfWork.LanguageLevelRep.GetAll();
            employeeVM.language_LevelVMs = mapper.Map<List<Language_levelVM>>(languageLevels);

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditEmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    await unitOfWork.EmployeeRep.Update(data);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                var accounts = await unitOfWork.AccountRep.GetAll();
                employee.accountVMs = mapper.Map<List<AccountVM>>(accounts);
                var languages = await unitOfWork.LanguageRep.GetAll();
                employee.languageVMs = mapper.Map<List<LanguageVM>>(languages);
                var languageLevels = await unitOfWork.LanguageLevelRep.GetAll();
                employee.language_LevelVMs = mapper.Map<List<Language_levelVM>>(languageLevels);
                return View(employee);
            }
            catch (Exception ex)
            {
                var accounts = await unitOfWork.AccountRep.GetAll();
                employee.accountVMs = mapper.Map<List<AccountVM>>(accounts);
                var languages = await unitOfWork.LanguageRep.GetAll();
                employee.languageVMs = mapper.Map<List<LanguageVM>>(languages);
                var languageLevels = await unitOfWork.LanguageLevelRep.GetAll();
                employee.language_LevelVMs = mapper.Map<List<Language_levelVM>>(languageLevels);
                return View(employee);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await unitOfWork.EmployeeRep.GetById(id);
            
            var model = mapper.Map<EmployeeVM>(employee);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(EmployeeVM employeeVM)
        {
                var employee = await unitOfWork.EmployeeRep.GetById(employeeVM.id);
                
            try
            {
                await unitOfWork.EmployeeRep.Delete(employee);
                var data = await unitOfWork.EmployeeLanguageLevelsRep.GetByEmployeeId(employeeVM.id);
                foreach (var item in data)
                {
                    await unitOfWork.EmployeeLanguageLevelsRep.Delete(item);
                }
                await unitOfWork.SaveChangesAsync();

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View(employeeVM);
            }
        }


        [HttpPost]
        public  JsonResult GetLineOfBusinessDataByAccountId(int AccountId)
        {
            var data =  unitOfWork.LineOfBusinessRep.Get(l => l.accountBusinessLines.Any(abl => abl.accountId == AccountId));
            var model = mapper.Map<List<LineOfBusinessVM>>(data);
            return Json(model);
        }

    }
}
