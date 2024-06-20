namespace Biblioteca_MVC.Controllers;

using Biblioteca_MVC.Data;
using Biblioteca_MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class EmprestimoController : Controller
{
    private readonly ApplicationDbContext _dataBase;

    public EmprestimoController(ApplicationDbContext dataBase)
    {
        _dataBase = dataBase;
    }

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<EmprestimosModel> emprestimos = _dataBase.Emprestimos;
        return View(emprestimos);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(EmprestimosModel emprestimos)
    {
        if (ModelState.IsValid)
        {
            _dataBase.Emprestimos.Add(emprestimos);
            _dataBase.SaveChanges();

            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Editar(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        EmprestimosModel? emprestimo = _dataBase.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null)
        {
            return NotFound();
        }

        return View(emprestimo);
    }

    [HttpPost]
    public IActionResult Editar(EmprestimosModel emprestimo)
    {
        if (ModelState.IsValid)
        {
            _dataBase.Emprestimos.Update(emprestimo);
            _dataBase.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

            return RedirectToAction("Index");
        }
        return View(emprestimo);
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        EmprestimosModel? emprestimo = _dataBase.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null)
        {
            return NotFound();
        }

        return View(emprestimo);
    }

    [HttpPost]
    public IActionResult Excluir(EmprestimosModel emprestimo)
    {
        if (emprestimo == null)
        {
            return NotFound();
        }
        _dataBase.Emprestimos.Remove(emprestimo);
        _dataBase.SaveChanges();

        TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

        return RedirectToAction("Index");
    }
}