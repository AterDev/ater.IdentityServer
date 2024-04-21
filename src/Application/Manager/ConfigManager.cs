using System.Text.Json;

using Definition.Share.Models.ConfigDtos;

namespace Application.Manager;
/// <summary>
/// 配置
/// </summary>
public class ConfigManager(
    DataAccessContext<Config> dataContext,
    ILogger<ConfigManager> logger,
    IUserContext userContext) : ManagerBase<Config, ConfigUpdateDto, ConfigFilterDto, ConfigItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Config> CreateNewEntityAsync(ConfigAddDto dto)
    {
        var entity = dto.MapTo<ConfigAddDto, Config>();

        entity.Value = JsonDocument.Parse(dto.Value);

        return await Task.FromResult(entity);
    }

    public override async Task<Config> UpdateAsync(Config entity, ConfigUpdateDto dto)
    {
        if (dto.Value != null)
        {
            entity.Value = JsonDocument.Parse(dto.Value);
        }

        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ConfigItemDto>> FilterAsync(ConfigFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Key, q => q.Key == filter.Key)
            .WhereNotNull(filter.Group, q => q.Group == filter.Group);
        return await Query.FilterAsync<ConfigItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }


    /// <summary>
    /// 唯一性判断
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsConflictAsync(string group, string key)
    {
        // 自定义唯一性验证参数和逻辑
        return await Command.Db.AnyAsync(q => q.Group == group && q.Key == key);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Config?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
