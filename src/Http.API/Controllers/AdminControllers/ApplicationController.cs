using Definition.Share.Models.ApplicationDtos;
using OpenIdApplication = Definition.Entity.OpenId.Application;

namespace Http.API.Controllers.AdminControllers;

/// <summary>
/// Application
/// </summary>
/// <see cref="ApplicationManager"/>
public class ApplicationController(
    IUserContext user,
    ILogger<ApplicationController> logger,
    ApplicationManager manager
    ) : RestControllerBase<ApplicationManager>(manager, user, logger)
{

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ApplicationItemDto>>> FilterAsync(ApplicationFilterDto filter)
    {
        return await _manager.ToPageAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Guid?>> AddAsync(ApplicationAddDto dto)
    {
        return await _manager.AddAsync(dto);
    }

    /// <summary>
    /// 部分更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<bool>> UpdateAsync([FromRoute] Guid id, ApplicationUpdateDto dto)
    {
        var current = await _manager.GetCurrentAsync(id);
        if (current == null) { return NotFound("不存在的资源"); };
        return await _manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OpenIdApplication?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await _manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await _manager.GetCurrentAsync(id);
        if (entity == null) { return NotFound(); };
        // return Forbid();
        return await _manager.DeleteAsync(entity);
    }
}