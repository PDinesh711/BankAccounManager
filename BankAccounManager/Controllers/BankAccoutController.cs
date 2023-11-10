using BankAccounManager.Database;
using BankAccounManager.DTO;
using BankAccounManager.Migrations;
using BankAccounManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounManager.Controllers
{
    [Route("api/bankAccount")]
    [ApiController]
    public class BankAccoutController : ControllerBase
    {

        private readonly BankAccountDbContext _dbcontext;

        public BankAccoutController(BankAccountDbContext _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }

        [HttpPost("save")]
        public ActionResult<CreateBankAccount> CreateBank([FromBody] CreateBankAccount bankAccount)
        {
            BankAccount bank = new BankAccount();
            bank.AccountHolderName = bankAccount.AccountHolderName;
            bank.AccountNumber = bankAccount.AccountNumber;
            bank.IFSCCode = bankAccount.IFSCCode;
            bank.AccountType = bankAccount.AccountType;
            bank.BranchLocation = bankAccount.BranchLocation;
            _dbcontext.bankAccounts.Add(bank);
            _dbcontext.SaveChanges();
            return Ok(bank);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<GetBankAccount>> GetAllBankAccounts()
        {
            var bank = _dbcontext.bankAccounts.ToList();
            return Ok(bank);
        }


        [HttpGet("get/{id:int}")]
        public ActionResult<GetBankAccount> GetById(int id)
        {
            var bank = _dbcontext.bankAccounts.Find(id);
            if (id != 0)
            {
                if(bank!= null)
                {
                    return Ok(bank);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id:int}")]
        public ActionResult<UpdateBankAccount> UpdateBankAccount(int id , [FromBody] UpdateBankAccount bankAccount)
        {
            var bank = _dbcontext.bankAccounts.Find(id);
            if (id != 0)
            {
                if(bank!= null)
                {
                    bank.AccountHolderName = bankAccount.AccountHolderName;
                    bank.AccountNumber = bankAccount.AccountNumber;
                    bank.AccountType = bankAccount.AccountType;
                    bank.IFSCCode = bankAccount.IFSCCode;
                    bank.BranchLocation = bankAccount.BranchLocation;
                    _dbcontext.SaveChanges();
                    return Ok(bank);
                }
                else
                {
                    return NoContent() ;
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult deleteBankAccount(int id)
        {
            var bank = _dbcontext.bankAccounts.FirstOrDefault(del=>del.AccountId == id);
            if(id!=0)
            {
                if( bank!= null)
                {
                    _dbcontext.bankAccounts.Remove(bank);
                    _dbcontext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    
    }
}
