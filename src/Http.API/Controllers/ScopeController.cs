using Definition.Share.Models.ApplicationDtos;

namespace Http.API.Controllers;

/// <summary>
/// Scope
/// </summary>
/// <param name="manager"></param>
/// <param name="scopeManager"></param>
/// <param name="user"></param>
/// <param name="logger"></param>
[AllowAnonymous]
public class ScopeController(
    OpenIdManager manager,
    IOpenIddictScopeManager scopeManager,
    IUserContext user,
    ILogger<ScopeController> logger) : RestControllerBase<OpenIdManager>(manager, user, logger)
{
    private readonly IOpenIddictScopeManager _manager = scopeManager;


    /// <summary>
    /// 获取应用列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<ApplicationItemDto>> GetOpenIddictScopeDescriptorList(int pageSize = 12, int pageIndex = 1)
    {
        var offset = (pageIndex - 1) * pageSize;
        var data = _manager.ListAsync(pageSize, offset > 0 ? offset : 0);
        return Ok(data);
    }

    /// <summary>
    /// 添加应用
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Scope>> AddOpenIddictScopeDescriptorAsync(Scope entity)
    {
        await _manager.CreateAsync(entity);
        return entity;
    }

    /// <summary>
    /// 更新应用
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<Scope>> UpdateOpenIddictScopeDescriptorAsync(Scope entity)
    {
        await _manager.UpdateAsync(entity);
        return entity;
    }

    /// <summary>
    /// 获取应用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationItemDto?>> GetOpenIddictScopeDescriptorAsync(Guid id)
    {
        var data = await _manager.FindByIdAsync(id.ToString());
        if (data == null)
        {
            return NotFound();
        }
        return data as ApplicationItemDto;
    }

    /// <summary>
    /// 删除应用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Scope>> DeleteOpenIddictScopeDescriptorAsync(Guid id)
    {
        var data = await _manager.FindByIdAsync(id.ToString());

        if (data == null)
        {
            return NotFound();
        }
        await _manager.DeleteAsync(id);
        return Ok(data);
    }
}
