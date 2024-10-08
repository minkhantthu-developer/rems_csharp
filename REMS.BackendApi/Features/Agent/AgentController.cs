﻿namespace REMS.BackendApi.Features.Agent;

[Route("api/v1/agents")]
[ApiController]
public class AgentController : ControllerBase
{
    private readonly BL_Agent _blAgent;

    public AgentController(BL_Agent blAgent)
    {
        _blAgent = blAgent;
    }

    [HttpPost]
    public async Task<IActionResult> PostAgent(AgentRequestModel requestModel)
    {
        try
        {
            var response = await _blAgent.CreateAgentAsync(requestModel);
            if (response.IsError) return BadRequest(response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAgent(int userId)
    {
        try
        {
            var response = await _blAgent.DeleteAgentAsync(userId);
            if (response.IsError) return BadRequest(response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAgent(int userId, AgentRequestModel requestModel)
    {
        try
        {
            var response = await _blAgent.UpdateAgentAsync(userId, requestModel);
            if (response.IsError) return BadRequest(response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpGet("{id}", Name = "SearchUser")]
    public async Task<IActionResult> SearchUser(int id)
    {
        var agentList = await _blAgent.SearchAgentAsync(id);

        return Ok(agentList);
    }

    [HttpGet("{name}/{pageNo}/{pageSize}", Name = "SearchUserByName")]
    public async Task<IActionResult> SearchUserByName(string name, int pageNumber, int pageSize)
    {
        var agentList = await _blAgent.SearchAgentByNameAsync(name, pageNumber, pageSize);

        return Ok(agentList);
    }

    [HttpPost("location", Name = "SearchAgentByNameAndLocation")]
    public async Task<IActionResult> SearchAgentByNameAndLocation(SearchAgentRequestModel _searchAgentReqeustModel)
    {
        var agentList = await _blAgent.SearchAgentByNameAndLocationAsync(_searchAgentReqeustModel);

        return Ok(agentList);
    }

    [HttpGet("{pageNumber}/{pageSize}", Name = "AgentAll")]
    public async Task<IActionResult> AgentAll(int pageNumber, int pageSize)
    {
        var agentList = await _blAgent.AgentAll(pageNumber, pageSize);

        return Ok(agentList);
    }
}