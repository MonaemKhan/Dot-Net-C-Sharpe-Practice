using Employee.Core.CQRS.State.Command;
using Employee.Core.CQRS.State.Query;
using Employee.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers;

[Route("State")]
public class StateController : APIController
{
    [HttpGet]
    public async Task<ActionResult<StateVM>> GetAll()
    {
        return await HandleQueryAsync(new GetAllState());
    }
    [HttpGet("int:Id")]
    public async Task<ActionResult<StateVM>> GetById(int Id)
    {
        return await HandleQueryAsync(new GetStateById(Id));
    }
    [HttpPost]
    public async Task<ActionResult<StateVM>> PostData(StateVM _data)
    {
        return await HandleCommandAsync(new CreateStateCommand(_data));
    }
    [HttpPut("int: Id")]
    public async Task<ActionResult<StateVM>> UpdateData(int Id,StateVM _data)
    {
        return await HandleCommandAsync(new UpdateStateCommand(Id, _data));
    }
    [HttpDelete("int: Id")]
    public async Task<ActionResult<StateVM>> DeleteData(int Id)
    {
        return await HandleCommandAsync(new  DeleteStateCommand(Id));
    }
}
