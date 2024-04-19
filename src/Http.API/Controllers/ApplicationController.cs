using Definition.Share.Models.ApplicationDtos;

namespace Http.API.Controllers;
/// <summary>
/// 应用
/// </summary>
/// <param name="manager"></param>
/// <param name="applicationManager"></param>
/// <param name="user"></param>
/// <param name="logger"></param>
[AllowAnonymous]
public class ApplicationController(
    OpenIdManager manager,
    IOpenIddictApplicationManager applicationManager,
    IUserContext user,
    ILogger<ApplicationController> logger) : RestControllerBase<OpenIdManager>(manager, user, logger)
{
    private readonly IOpenIddictApplicationManager _manager = applicationManager;


    /// <summary>
    /// 获取应用列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<ApplicationItemDto>> GetOpenIddictApplicationDescriptorList(int pageSize = 12, int pageIndex = 1)
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
    public async Task<ActionResult<Definition.Entity.Application>> AddOpenIddictApplicationDescriptorAsync(Definition.Entity.Application entity)
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
    public async Task<ActionResult<Definition.Entity.Application>> UpdateOpenIddictApplicationDescriptorAsync(Definition.Entity.Application entity)
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
    public async Task<ActionResult<ApplicationItemDto?>> GetOpenIddictApplicationDescriptorAsync(Guid id)
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
    public async Task<ActionResult<Definition.Entity.Application>> DeleteOpenIddictApplicationDescriptorAsync(Guid id)
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
