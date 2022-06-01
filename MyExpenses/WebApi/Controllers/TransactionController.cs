using Database.Data;
using Database.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ApiController
{

    private readonly ITransactionRepository _transactionRepository;

    public TransactionController(ITransactionRepository transactionRepository, ExpanseContext db) : base(db)
    {
        _transactionRepository = transactionRepository;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Post([FromBody] TransactionVm transaction)
    {
        if (transaction.Amount < 0 || transaction.Title == null)
        {
            return BadRequest("Invalid Inputs!!");
        }

        _transactionRepository.Add(new Transaction(transaction.Amount, transaction.Title, transaction.Date));
        return Ok();
    }

    [Authorize]
    [HttpGet("ById")]
    public IActionResult GetById(Guid id)
    {
        var transaction = _transactionRepository.GetById(id);
        if (transaction == null)
        {
            return NotFound();
        }

        return Ok(transaction);

    }

    [Authorize]
    [HttpPut("ById")]
    public IActionResult Put(Guid id, [FromBody] TransactionVm vm)
    {
        var transaction = _transactionRepository.GetById(id);
        if (transaction == null)
        {
            return NotFound();
        }

        transaction.Amount = vm.Amount;
        transaction.Date = vm.Date;
        transaction.Title = vm.Title;
        transaction.UpdatedAt = DateTime.UtcNow;

        var isSaved = _transactionRepository.Update(transaction);

        if (!isSaved)
            return Conflict();

        return Ok(transaction);

    }

    [Authorize]
    [HttpDelete("ById")]
    public IActionResult DeleteById(Guid id)
    {
        var deleted = _transactionRepository.ForceDelete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var allTransactions = _transactionRepository.GetAll();
        return Ok(allTransactions);
    }
}

