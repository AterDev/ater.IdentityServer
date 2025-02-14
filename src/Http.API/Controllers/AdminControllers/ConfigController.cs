using Definition.Share.Models.ConfigDtos;
namespace Http.API.Controllers.AdminControllers;

/// <summary>
/// 配置
/// </summary>
/// <see cref="Application.Manager.ConfigManager"/>
public class ConfigController(
    IUserContext user,
    ILogger<ConfigController> logger,
    ConfigManager manager
    ) : RestControllerBase<ConfigManager>(manager, user, logger)
{

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ConfigItemDto>>> FilterAsync(ConfigFilterDto filter)
    {
        return await _manager.ToPageAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Guid?>> AddAsync(ConfigAddDto dto)
    {
        if (await _manager.IsConflictAsync(dto.Group, dto.Key))
        {
            return Conflict(dto.Group + ":" + dto.Key);
        }
        return await _manager.AddAsync(dto);
    }

    /// <summary>
    /// 部分更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<bool>> UpdateAsync([FromRoute] Guid id, ConfigUpdateDto dto)
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
    public async Task<ActionResult<Config?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await _manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// 获取enums信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("enums")]
    public Dictionary<string, List<EnumDictionary>> GetEnums()
    {
        return _manager.GetEnums();
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